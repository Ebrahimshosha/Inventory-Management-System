

namespace FoodApp.Api.VerticalSlicing.Features.Account.Login.Commands
{
    public record LoginCommand(string Email, string Password) : IRequest<Result<LoginResponse>>;

    public class LoginCommandHandler : BaseRequestHandler<LoginCommand, Result<LoginResponse>>
    {
        public LoginCommandHandler(RequestParameters requestParameters) : base(requestParameters) { }

        public override async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return Result.Failure<LoginResponse>(UserErrors.InvalidCredentials);
            }

            var userResult = await _mediator.Send(new GetUserByEmailQuery(request.Email));

            if (!userResult.IsSuccess)
            {
                return Result.Failure<LoginResponse>(UserErrors.InvalidCredentials);
            }

            var user = userResult.Data;
            if (!PasswordHasher.checkPassword(request.Password, user.PasswordHash) /*|| !user.IsEmailVerified*/)
            {
                return Result.Failure<LoginResponse>(UserErrors.InvalidCredentials);
            }

            var token = TokenGenerator.GenerateToken(user);


            var loginResponse = new LoginResponse(user.Id, user.Email, token);

            var userRepo = _unitOfWork.Repository<User>();
            return Result.Success(loginResponse);
        }
    }
}
