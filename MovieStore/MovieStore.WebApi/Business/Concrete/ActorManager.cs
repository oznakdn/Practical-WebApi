using AutoMapper;
using FluentValidation;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Business.Validations.ActorValidations;
using MovieStore.WebApi.Data.Abstract;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.ActorViewModels;
using System.Linq.Expressions;

namespace MovieStore.WebApi.Business.Concrete
{
    public class ActorManager : IActorService
    {
        private readonly IActorRepo _actorRepo;
        private readonly IMapper _mapper;
        public ActorManager(IActorRepo actorRepo, IMapper mapper)
        {
            _actorRepo = actorRepo;
            _mapper = mapper;

        }
        public Actor Add(Actor entity)
        {
            return _actorRepo.Add(entity);
        }

        public List<Actor> GetAll(Expression<Func<Actor, bool>> Filter = null)
        {
            return _actorRepo.GetAll(Filter);
        }

        public Actor GetByFilter(Expression<Func<Actor, bool>> Filter)
        {
            return _actorRepo.GetByFilter(Filter);
        }

        public Actor Update(Actor entity)
        {
            return _actorRepo.Update(entity);
        }

        public List<GetAllActorsModel> GetAllActors()
        {
            var actors = _actorRepo.GetAll();

            List<GetAllActorsModel> mode = _mapper.Map<List<GetAllActorsModel>>(actors);
            return mode;
        }

        public GetActorModel GetActorById(int id)
        {
            var actor = _actorRepo.GetByFilter(x => x.ActorID == id);
            if (actor is null) throw new InvalidOperationException("There is no the actor");

            return _mapper.Map<GetActorModel>(actor);
        }

        public void AddActor(CreateActorModel model)
        {
            var actor = _actorRepo.GetByFilter(x => x.FirstName == model.FirstName && x.lastName == model.lastName);
            if (actor is not null) throw new InvalidOperationException($"There is already {actor.FirstName} {actor.lastName} !");

            CreateActorValidator validator = new CreateActorValidator();
            validator.ValidateAndThrow(model);

            actor = _mapper.Map<Actor>(model);
            _actorRepo.Add(actor);
        }

        /// <summary>
        /// This method edits not the same actor's firstname and lastname.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void UpdateActor(UpdateActorModel model, int id)
        {
            var actor = _actorRepo.GetByFilter(x => x.ActorID == id);
            var theSameActor = _actorRepo.GetAll(x => x.FirstName == model.FirstName && x.lastName == model.lastName);
            if (actor == null) throw new InvalidOperationException($"There is no {id} Id number actor!");
            else if (theSameActor.Count >0) throw new InvalidOperationException($"There is already {model.FirstName} {model.lastName}");


            UpdateActorValidator validator = new UpdateActorValidator();
            validator.ValidateAndThrow(model);

            actor.FirstName = model.FirstName != default ? model.FirstName : actor.FirstName;
            actor.lastName = model.lastName != default ? model.lastName : actor.lastName;
            _actorRepo.Update(actor);


        }

        public void Delete(int Id)
        {
            var actor = _actorRepo.GetByFilter(x => x.ActorID == Id);
            if (actor is null) throw new InvalidOperationException($"There is no {Id} number actor!");


            _actorRepo.Delete(Id);
        }
    }
}
