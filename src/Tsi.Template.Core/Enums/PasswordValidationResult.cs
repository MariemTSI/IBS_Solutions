﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsi.Template.Core.Models
{
    public enum PasswordValidationResult
    {
        Valid,
        Expired,
        Invalid,
        WrongPassword
    }
}
