﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace Business.ViewModels.Authorization
{
    public class ApplicationUser : IdentityUser, IUser<string>
    {
        
    }
}
