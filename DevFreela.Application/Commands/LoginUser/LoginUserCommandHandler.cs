using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Use the same algorithm to create hash of this password
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
           
            // Look on database a user with email and same hash password
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);
            
            // If user does not exist login will fail. 
            if (user == null)
            {
                return null;
            }

            // if user exists, generate toke with user data
            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            var loginUserViewModel = new LoginUserViewModel(user.Email, token);

            return loginUserViewModel;

            /*
             {
                  "email": "test1@mail.com",
                  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6InRlc3QxQG1haWwuY29tIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiY2xpZW50IiwiZXhwIjoxNzIxNDMzNTQzLCJpc3MiOiJEZXZGcmVlbGEiLCJhdWQiOiJDbGllbnRGcmVlbGFuY2VycyJ9.f7CZ_3kV5i94vlUP7qQZMIZy5TRi4EZ7yoXHWxfz3-8"
                }
             */

        }
    }
}
