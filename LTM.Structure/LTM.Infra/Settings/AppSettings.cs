﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Infra.Settings
{
    public sealed class AppSettings
    {
        public sealed class ConnectionStrings
        {
            public static string DefaultConnection { get; set; }
        }
    }
}
