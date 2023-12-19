using AutoMapper;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Entities;
using BookStore.WebApi.Models.UserModels;
using System;
using System.Linq;

namespace BookStore.WebApi.Application.UserOperations
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        public void Handle()
        {
            var user=_context.Users.SingleOrDefault(x=>x.Email==Model.Email);
            if(user is not null) throw new InvalidOperationException("Kullanıcı zaten var.");

           user=_mapper.Map<User>(Model);
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        
    }
}