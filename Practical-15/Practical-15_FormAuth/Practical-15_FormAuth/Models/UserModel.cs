﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_15_FormAuth.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}