using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LTM.Domain.Commands.Results;
using LTM.Infra;

namespace LTM.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<UserCommandResult> GetUserByLoginAsync(string username);
    }
}
