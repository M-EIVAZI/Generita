using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Common.Interfaces;
using Generita.Domain.Models;

namespace Generita.Application.Authentication.Login
{
    internal class LoginHandler : ICommandHandler<LoginCommand, LoginResponse>
    {
        private IUserRepository _userRepository;
        private IPasswordHasher _passwordHasher;
        private ITokenGenerator _tokenGenerator;
        private IUnitOfWork _unitOfWork;
        private IRefreshTokenRepository _refreshTokenRepository;
        private IAuthorRepository _authorRepository;

        public LoginHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator, IUnitOfWork unitOfWork, IRefreshTokenRepository refreshTokenRepository, IAuthorRepository authorRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
            _unitOfWork = unitOfWork;
            _refreshTokenRepository = refreshTokenRepository;
            _authorRepository = authorRepository;
        }

        public async  Task<ErrorOr<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var role = (RoleDto)Enum.Parse(typeof(RoleDto), request.LoginDto.Role);
            if(role==RoleDto.reader)
            {
                if (!await _userRepository.IsExistsByEmail(request.LoginDto.email))
                {
                    return Error.Unauthorized(description: "Email Doesn't Exists");
                }
                var user = await _userRepository.GetUserByEmail(request.LoginDto.email);
                if (!_passwordHasher.IsCorrectPassword(request.LoginDto.password, user.Password))
                {
                    return Error.Conflict(description: "Password is incorrect");
                }
                var token = _tokenGenerator.GenerateToken(user);
                var refreshtoken = _tokenGenerator.RefreshToken();
                RefreshTokens rtmodel = new(Guid.NewGuid())
                {
                    ExpiresOnUtc = DateTime.UtcNow.AddDays(7),
                    UserId = user.Id,
                    Token = refreshtoken,
                };
                await _refreshTokenRepository.Add(rtmodel);
                await _unitOfWork.CommitAsync();
                return new LoginResponse() { accessToken = token, refreshToken = refreshtoken };
            }
            else if (role == RoleDto.author)
            {
                if (!await _authorRepository.IsExistsByEmail(request.LoginDto.email))
                    return Error.Unauthorized(description: "There is no registered author with this email");
                var author = await _authorRepository.GetAuthorByEmail(request.LoginDto.email);
                if(!_passwordHasher.IsCorrectPassword(request.LoginDto.password, author.Password))
                    return Error.Conflict(description: "Password is incorrect");
                var token=_tokenGenerator.GenerateToken(author);
                var refreshtoken = _tokenGenerator.RefreshToken();
                RefreshTokens rtmodel = new(Guid.NewGuid())
                {
                    ExpiresOnUtc = DateTime.UtcNow.AddDays(7),
                    AuthorId = author.Id,
                    Token = refreshtoken,
                };
                await _refreshTokenRepository.Add(rtmodel);
                await _unitOfWork.CommitAsync();
                return new LoginResponse() { accessToken = token,refreshToken = refreshtoken };
            }
            return Error.Unauthorized(description: "There is no registred email with this output");

        }
    }
}
