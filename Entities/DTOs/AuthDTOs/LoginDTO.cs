﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.AuthDTOs
{
    public class LoginDTO
    {
        public required string EmailOrUsername { get; set; }
        public required string Password { get; set; }
    }
}
