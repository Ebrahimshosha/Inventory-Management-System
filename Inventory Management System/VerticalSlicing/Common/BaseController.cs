﻿
namespace FoodApp.Api.VerticalSlicing.Common
{
    [Route("api")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly UserState _userState;

        public BaseController(ControllerParameters controllerParameters)
        {
            _mediator = controllerParameters.Mediator;
            _userState = controllerParameters.UserState;

            var loggedUser = new HttpContextAccessor().HttpContext!.User;

            _userState.Role = loggedUser.FindFirst("RoleID")?.Value ?? string.Empty;
            _userState.ID = loggedUser.FindFirst("UserId")?.Value ?? string.Empty;
            _userState.Name = loggedUser.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
        }
    }
}
