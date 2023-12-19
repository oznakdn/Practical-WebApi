using AutoMapper;
using BooksStore.WebApi.TokenOperations;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.TokenOperations.TokenModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace BookStore.WebApi.Application.UserOperations
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        
        private readonly BookStoreDbContext _context;
        private readonly IConfiguration _configuraiton;

        public RefreshTokenCommand(BookStoreDbContext context, IConfiguration configuration)
        {
            _context=context;
            _configuraiton=configuration;
        }

        public Token Handle()
        {
             var user=_context.Users.FirstOrDefault(x=>x.RefreshToken==RefreshToken);
             if(user is not null)
             {
                 TokenHandler handler=new TokenHandler(_configuraiton);
                 Token token=handler.CreateAccessToken(user);

                 user.RefreshToken=token.RefreshToken;
                 user.RefreshTokenExpireDate=token.Expiration.AddMinutes(5);
                 _context.SaveChanges();
                 return token;
             }
             else
             {
                 throw new InvalidOperationException("Valid bir refresh token bulunamadı.");
             }
        }
    }
}