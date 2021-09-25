﻿using EduHome.Models.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Entity
{
    public class AppUser:IdentityUser
    {
        [Required]
        public string Fullname { get; set; }
        [Required]
        public bool IsAgree { get; set; }
    }
}
