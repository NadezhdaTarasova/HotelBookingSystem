﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models.Authorization.Manage
{
    public class RemoteLogin
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
