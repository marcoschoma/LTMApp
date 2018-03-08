using LTM.Domain.Commands.Results;
using LTM.Domain.Entities;
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
        private readonly LTMDataContext _context;

        public UserRepository(IUnitOfWork uow, LTMDataContext context) : base(uow, context)
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

        public async Task<NotificationResult> InsertAsync(UserInfo item)
        {
            var result = new NotificationResult();
            try
            {
                await _context.User.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
                throw;
            }
            return result;
        }
    }
}
