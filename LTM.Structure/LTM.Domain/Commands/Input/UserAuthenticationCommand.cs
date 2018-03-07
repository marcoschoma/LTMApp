using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Domain.Commands.Input
{
    public class UserAuthenticationCommand
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
