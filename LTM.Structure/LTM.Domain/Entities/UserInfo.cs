using System;
using System.Collections.Generic;
using System.Text;
using LTM.Domain.Commands.Input;
using LTM.Domain.Commands.Input.User;

namespace LTM.Domain.Entities
{
    public class UserInfo : EntityInfo
    {
        public UserInfo(InsertUserCommand userCommand)
        {
            FirstName = userCommand.FirstName;
            LastName = userCommand.LastName;
            Username = userCommand.Username;
            Password = userCommand.Password;
            Email = userCommand.Email;
        }

        public Guid IdUser { get; private set; }

        public string Username { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
