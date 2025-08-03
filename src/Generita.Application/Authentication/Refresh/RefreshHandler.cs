using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Authentication.Refresh
{
    public class RefreshHandler : ICommandHandler<RefreshCommand, RefreshResponse>
    {
        private IRefreshTokenRepository _refreshRepository;
        private ITokenGenerator _tokenGenerator;
        private IUserRepository _userRepository;

        public RefreshHandler(IRefreshTokenRepository refreshRepository, ITokenGenerator tokenGenerator, IUserRepository userRepository)
        {
            _refreshRepository = refreshRepository;
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<RefreshResponse>> Handle(RefreshCommand request, CancellationToken cancellationToken)
        {
            var savedtoken =await  _refreshRepository.GetByToken(request.refreshRequest.refreshToken);
            if (savedtoken == null || savedtoken.ExpiresAt < DateTime.UtcNow)
            {
                return Error.Unauthorized(description: "Refresh Token is invalid");
            }
            var  user =await _userRepository.GetById(savedtoken.Id);
            if (user == null)
            {
                return Error.Unauthorized(description: "User Not found");
            }
            var newtoken=_tokenGenerator.GenerateToken(user);
            return new RefreshResponse() { accessToken = newtoken };

        }
    }
}
