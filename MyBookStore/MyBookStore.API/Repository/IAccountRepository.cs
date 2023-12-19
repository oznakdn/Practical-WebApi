using Microsoft.AspNetCore.Identity;
using MyBookStore.API.Models;

namespace MyBookStore.API.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}
