using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Common.Interfaces;

namespace Generita.Application.Authentication.Login
{
    internal class LoginHandler : ICommandHandler<LoginCommand, LoginResponse>
    {
        private IUserRepository _userRepository;
        private IPasswordHasher _passwordHasher;
        private ITokenGenerator _tokenGenerator;
        private IUnitOfWork _unitOfWork;

        public LoginHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
            _unitOfWork = unitOfWork;
        }

        public async  Task<ErrorOr<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (!await _userRepository.IsExistsByEmail(request.LoginDto.email))
            {
                return Error.Unauthorized(description: "Email Doesn't Exists");
            }
            var user=await _userRepository.GetUserByEmail(request.LoginDto.email);
            if(_passwordHasher.IsCorrectPassword(request.LoginDto.password,user.Password))
            {
                return Error.Conflict(description: "Password is incorrect");
            }
            var token = _tokenGenerator.GenerateToken(user);
            return 

        }
    }
}
