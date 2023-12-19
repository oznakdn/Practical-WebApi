using AutoMapper;
using BooksStore.WebApi.TokenOperations;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Models.UserModels;
using BookStore.WebApi.TokenOperations.TokenModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace BookStore.WebApi.Application.UserOperations
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuraiton;

        public CreateTokenCommand(BookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context=context;
            _mapper=mapper;
            _configuraiton=configuration;
        }

        public Token Handle()
        {
             var user=_context.Users.FirstOrDefault(x=>x.Email==Model.Email && x.Password==Model.Password);
             if(user is not null)
             {
                 // Token oluştur
                 TokenHandler handler=new TokenHandler(_configuraiton);
                 Token token=handler.CreateAccessToken(user);

                 user.RefreshToken=token.RefreshToken;
                 user.RefreshTokenExpireDate=token.Expiration.AddMinutes(5);
                 _context.SaveChanges();
                 return token;
             }
             else
             {
                 throw new InvalidOperationException("Kullanıcı Adı - Şifre hatalı.");
             }
        }
    }
}