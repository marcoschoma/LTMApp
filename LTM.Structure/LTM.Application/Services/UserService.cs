using LTM.Domain;
using LTM.Domain.Commands.Handlers;
using LTM.Domain.Commands.Input;
using LTM.Domain.Commands.Results;
using LTM.Domain.Repositories;
using LTM.Domain.Services;
using LTM.Infra;
using LTM.Infra.Data.Base;
using LTM.Infra.Service;
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

        public UserService(IUnitOfWork uow, IUserRepository repository, UserCommandHandler handler) : base(uow)
        {
            _repository = repository;
            _handler = handler;
        }

        public async Task<UserCommandResult> GetUserByLoginAsync(string username)
        {
            return await _repository.GetUserByLoginAsync(username);
        }

        public async Task<NotificationResult> InsertAsync(InsertUserCommand insertUserCommand)
        {
            BeginTransaction();
            var result = await _handler.InsertAsync(insertUserCommand);
            return Commit(result);
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
