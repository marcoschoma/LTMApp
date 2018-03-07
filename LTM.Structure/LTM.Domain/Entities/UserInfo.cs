using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Domain.Entities
{
    public class UserInfo : EntityInfo
    {
        public Guid IdUser { get; private set; }

        public string Username { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
