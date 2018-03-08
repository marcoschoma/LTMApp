using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Domain.Commands.Input
{
    public class InsertUserCommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
