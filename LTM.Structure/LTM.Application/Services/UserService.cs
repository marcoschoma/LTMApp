using LTM.Domain;
using LTM.Domain.Commands.Handlers;
using LTM.Domain.Commands.Results;
using LTM.Domain.Repositories;
using LTM.Domain.Services;
using LTM.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Application.Services
{
    public class UserService : ApplicationService, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly UserCommandHandler _handler;

        public UserService(IUserRepository repository, UserCommandHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        public async Task<UserCommandResult> GetUserByLoginAsync(string username)
        {
            return await _repository.GetUserByLoginAsync(username);
        }

        public async Task<NotificationResult> IsValidUsernameAndPasswordAsync(string username, string password)
        {
            return await _handler.ValidateUsernameAndPasswordAsync(username, password);
        }

        public async Task<NotificationResult> IsValidUsernameAndTokenAsync(string username, Guid? idUser)
        {
            return await _handler.ValidateUsernameAndTokenAsync(username, idUser);
        }
    }
}
