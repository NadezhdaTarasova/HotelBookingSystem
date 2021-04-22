﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models.Authorization
{
    public class Error
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
