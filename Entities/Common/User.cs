﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Common
{
    public class User : AppUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
