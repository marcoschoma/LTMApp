﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Domain.Commands.Input
{
    public class UserRefreshTokenCommand
    {
        public string Username { get; set; }

        public string Refresh_token { get; set; }
    }
}
