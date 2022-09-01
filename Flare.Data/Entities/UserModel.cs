﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare.Data.Entities
{
    public class UserModel : BaseModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Picture { get; set; }
    }
}
