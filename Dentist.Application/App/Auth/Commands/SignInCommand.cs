using Dentist.Application.App.Auth.Responces;
using Dentist.Application.Common.Interfaces;
using MediatR;

namespace Dentist.Application.App.Auth.Commands
{
    public class SignInCommand : IRequest<SignInDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInDto>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;

        public SignInCommandHandler(IAuthenticationService authenticationService, ITokenService tokenService)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }

        public async Task<SignInDto> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var passwordSignInResult = await _authenticationService.PasswordSignInAsync(
                request.UserName, request.Password);

            string? accessToken = null;

            if (passwordSignInResult)
            {
                accessToken = _tokenService.GenerateAccessToken();
            }

            return new SignInDto()
            {
                Successed = passwordSignInResult,
                AccessToken = accessToken
            };
        }
    }
}
