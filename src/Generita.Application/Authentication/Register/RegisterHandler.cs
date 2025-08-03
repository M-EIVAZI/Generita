using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;
using Generita.Domain.Common.Interfaces;
using Generita.Domain.Models;

namespace Generita.Application.Authentication.Register
{
    internal class RegisterHandler : ICommandHandler<RegisterCommand, RegisterResponse>
    {
        private ITokenGenerator _tokenGenerator;
        private IUserRepository _userRepository;
        private IPasswordHasher _passwordHasher;
        private IUnitOfWork _unitOfWork;
        public RegisterHandler(ITokenGenerator tokenGenerator, IUserRepository userRepository, IPasswordHasher passwordHasher, IUnitOfWork unitOfWork)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.IsExistsByEmail(request.registerDto.email))
                return Error.Conflict(description: "Email Exists!");
            var hashedpassword = _passwordHasher.HashPassword(request.registerDto.password);
            if(hashedpassword.IsError)
                return Error.Failure(description:hashedpassword.FirstError.Description);
            //maybe change that in future
            var user = new User(Guid.NewGuid())
            {
                Password = hashedpassword.Value,
                Email = request.registerDto.email,
                CreateAt = DateTime.UtcNow,
                UpdateAt=DateTime.UtcNow,
                Name=request.registerDto.name,
            };
            await _userRepository.Add(user);
            await _unitOfWork.CommitAsync(cancellationToken);
            var registereduser =await _userRepository.GetUserByEmail(request.registerDto.email);
            var token = _tokenGenerator.GenerateToken(registereduser);
            return new RegisterResponse() { Message=token};

        }
    }
}
