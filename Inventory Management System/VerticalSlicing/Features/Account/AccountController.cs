using FoodApp.Api.VerticalSlicing.Common;
using FoodApp.Api.VerticalSlicing.Features.Account.ForgotPassword;
using FoodApp.Api.VerticalSlicing.Features.Account.ForgotPassword.Commands;
using FoodApp.Api.VerticalSlicing.Features.Account.Login;
using FoodApp.Api.VerticalSlicing.Features.Account.Login.Commands;
using FoodApp.Api.VerticalSlicing.Features.Account.Register;
using FoodApp.Api.VerticalSlicing.Features.Account.Register.Orchestrator;

namespace FoodApp.Api.VerticalSlicing.Features.Account
{
    public class AccountController : BaseController
    {
        public AccountController(ControllerParameters controllerParameters) : base(controllerParameters) { }

        [HttpPost("Register")]
        public async Task<Result> Register(RegisterRequest viewModel)
        {
            var command = viewModel.Map<RegisterOrchestrator>();
            var result = await _mediator.Send(command);
            return result;

        }
        [HttpPost("VerifyAccount")]
        public async Task<Result<bool>> Verify(VerifyAccountRequest request)
        {
            var command = request.Map<VerifyOTPCommand>();
            var result = await _mediator.Send(command);
            return result;

        }
        [HttpPost("ResendVerificationCode")]
        public async Task<Result<bool>> ResendVerificationCode(ResendVerificationCodeRequest requset)
        {
            var command = requset.Map<SendVerificationOTP>();
            var result = await _mediator.Send(command);
            return result;

        }

        [HttpPost("Login")]
        public async Task<Result<LoginResponse>> Login(LoginRequest request)
        {
            var command = request.Map<LoginCommand>();
            var result = await _mediator.Send(command);
            if (result.Data == null)
            {
                return Result.Failure<LoginResponse>(UserErrors.InvalidCredentials);
            }

            return result;
        }

        [HttpPost("ForgotPassword")]
        public async Task<Result<bool>> ForgotPassword(ForgetPasswordRequest request)
        {
            var command = request.Map<ForgotPasswordCommand>();

            var response = await _mediator.Send(command);

            return response;
        }

        [HttpPost("ResetPassword")]
        public async Task<Result<bool>> ResetPassword(ResetPasswordRequest request)
        {
            var command = request.Map<ResetPasswordCommand>();
            var response = await _mediator.Send(command);

            return response;
        }
    }
}
