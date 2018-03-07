using LTM.Domain.Commands.Results;
using LTM.Domain.Repositories;
using LTM.Domain.Specs;
using LTM.Infra.Data.Base;
using LTM.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Infra.Data
{
    public class UserRepository : Repository, IUserRepository
    {
        private readonly SecurityDataContext _context;

        public UserRepository(IUnitOfWork uow, SecurityDataContext context) : base(uow, context)
        {
            _context = context;
        }

        public async Task<UserCommandResult> GetUserByLoginAsync(string username)
        {
            return await _context.User.AsNoTracking()
                .Where(u => u.Username == username)
                .Select(UserSpecs.AsUserCommandResult)
                .FirstOrDefaultAsync();
        }
    }
}
