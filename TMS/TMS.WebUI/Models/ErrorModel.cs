﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.WebUI.Models
{
    public class ErrorModel
    {
        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorField { get; set; }
    }
}