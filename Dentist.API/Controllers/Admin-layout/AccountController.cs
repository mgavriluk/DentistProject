using MediatR;
using Microsoft.AspNetCore.Authorization;
using Dentist.Application.App.Auth.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.API.Controllers.Admin_layout
{
    [Route("api/account")]
    public class AccountController : AdminLayoutBaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(SignInCommand passwordSignInCommand)
        {
            var responce = await _mediator.Send(passwordSignInCommand);

            if (responce.Successed)
            {
                return Ok(new {responce.AccessToken});
            }

            return Unauthorized();
        }
    }
}
