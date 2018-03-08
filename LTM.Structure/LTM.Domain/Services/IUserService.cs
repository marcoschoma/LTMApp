using LTM.Domain.Commands.Input;
using LTM.Domain.Commands.Results;
using LTM.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Domain.Services
{
    public interface IUserService
    {
        Task<NotificationResult> IsValidUsernameAndPasswordAsync(string username, string password);
        Task<NotificationResult> IsValidUsernameAndTokenAsync(string username, Guid? idUser);
        Task<UserCommandResult> GetUserByLoginAsync(string username);
        Task<NotificationResult> InsertAsync(InsertUserCommand insertUserCommand);
    }
}
