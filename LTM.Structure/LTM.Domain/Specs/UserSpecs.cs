using LTM.Domain.Commands.Results;
using LTM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LTM.Domain.Specs
{
    public class UserSpecs
    {
        public static readonly Expression<Func<UserInfo, UserCommandResult>> AsUserCommandResult = x => new UserCommandResult
        {
            IdUser = x.IdUser,
            Username = x.Username,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
        };
    }
}
