using AutoMapper;
using FluentValidation;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Business.Validations.DirectorValidations;
using MovieStore.WebApi.Data.Abstract;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.DirectorViewModels;
using System.Linq.Expressions;

namespace MovieStore.WebApi.Business.Concrete
{
    public class DirectorManager : IDirectorService
    {
        private readonly IDirectorRepo _directorRepo;
        private readonly IMapper _mapper;
        public DirectorManager(IDirectorRepo directorRepo, IMapper mapper)
        {
            _directorRepo = directorRepo;
            _mapper = mapper;
        }
        public List<Director> GetAll(Expression<Func<Director, bool>> Filter = null)
        {
            return _directorRepo.GetAll(Filter);
        }

        public Director GetByFilter(Expression<Func<Director, bool>> Filter)
        {
            return _directorRepo.GetByFilter(Filter);
        }

        public Director Update(Director entity)
        {
            return _directorRepo.Update(entity);
        }

        public List<GetAllDirectorsModel>GetAllDirectors()
        {
            var movies = _directorRepo.GetAll();

            List<GetAllDirectorsModel> vm = _mapper.Map<List<GetAllDirectorsModel>>(movies);
            return vm;
        }

        public GetDirectorModel GetDirectorByFullName(string firstName,string lastName)
        {
            var director = _directorRepo.GetByFilter(x => x.FirstName == firstName && x.LastName == lastName);
            if (director is null) throw new InvalidOperationException("Not found the director");

            return _mapper.Map<GetDirectorModel>(director);
        }

        public void AddDirector(CreateDirectorModel model)
        {
            var director = _directorRepo.GetByFilter(x => x.FirstName == model.FirstName && x.LastName == model.LastName);
            if (director is not null) throw new InvalidOperationException("There is already the director");

            CreateDirectorValidator validator = new CreateDirectorValidator();
            validator.ValidateAndThrow(model);

            director = _mapper.Map<Director>(model);
            _directorRepo.Add(director);
        }

        public void UpdateDirector(UpdateDirectorModel model,int directorId)
        {
            var director = _directorRepo.GetByFilter(x => x.DirectorID == directorId);
            if (director is null) throw new InvalidOperationException("There is no director for updating");

            UpdateDirectorValidator validator = new UpdateDirectorValidator();
            validator.ValidateAndThrow(model);

            director.FirstName = model.FirstName != default ? model.FirstName : director.FirstName;
            director.LastName = model.LastName != default ? model.LastName : director.LastName;
            _directorRepo.Update(director);

        }

        public void Delete(int id)
        {
            var director = _directorRepo.GetByFilter(x => x.DirectorID == id);
            if (director is null) throw new InvalidOperationException("There is no director for deleting");
            else _directorRepo.Delete(id);

        }
    }
}
