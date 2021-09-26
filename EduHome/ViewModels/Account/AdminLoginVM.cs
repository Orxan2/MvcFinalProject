﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels.Account
{
    public class AdminLoginVM
    {
        [Required, DataType("nvarchar(50)")]
        public string Username { get; set; }
       
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
