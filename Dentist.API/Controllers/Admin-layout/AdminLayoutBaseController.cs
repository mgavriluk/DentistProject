using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.API.Controllers.Admin_layout
{
    [Authorize]
    [ApiController]
    public abstract class AdminLayoutBaseController : ControllerBase
    {
    }
}
