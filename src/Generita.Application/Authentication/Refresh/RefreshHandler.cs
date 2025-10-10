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
        private IAuthorRepository _authorRepository;

        public RefreshHandler(IRefreshTokenRepository refreshRepository, ITokenGenerator tokenGenerator, IUserRepository userRepository, IAuthorRepository authorRepository)
        {
            _refreshRepository = refreshRepository;
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
            _authorRepository = authorRepository;
        }

        public async Task<ErrorOr<RefreshResponse>> Handle(RefreshCommand request, CancellationToken cancellationToken)
        {
            var savedtoken =await  _refreshRepository.GetByToken(request.refreshRequest.refreshToken);
            if (savedtoken == null || savedtoken.ExpiresOnUtc < DateTime.UtcNow)
            {
                return Error.Unauthorized(description: "Refresh Token is invalid");
            }
            var  user =await _userRepository.GetById(savedtoken.UserId ?? Guid.Empty);
            var author=await _authorRepository.GetById(savedtoken.AuthorId ?? Guid.Empty);
            if (user == null && author==null)
            {
                return Error.Unauthorized(description: "User Not found");
            }
            string newtoken=string.Empty;
            if(author == null && user!=null)
               newtoken=_tokenGenerator.GenerateToken(user);
            else if(author !=null && user==null)
                newtoken=_tokenGenerator.GenerateToken(author);
            return new RefreshResponse() { accessToken = newtoken };

        }
    }
}
