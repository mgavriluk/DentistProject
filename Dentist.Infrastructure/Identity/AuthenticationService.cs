using Dentist.Application.Common.Interfaces;
using Dentist.Domain.Auth;
using Microsoft.AspNetCore.Identity;

namespace Dentist.Infrastructure.Identity
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<User> _signInManager;

        public AuthenticationService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> PasswordSignInAsync(string userName, string password)
        {
            var checkingPasswordResult = await _signInManager.PasswordSignInAsync(
                userName, password, false, false);

            return checkingPasswordResult.Succeeded;
        }
    }
}
