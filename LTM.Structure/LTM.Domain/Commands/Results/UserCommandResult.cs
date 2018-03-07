using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Domain.Commands.Results
{
    public class UserCommandResult
    {
        public Guid? IdUser { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
