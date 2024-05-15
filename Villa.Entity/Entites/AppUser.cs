﻿using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.Entity.Entites
{
    public class AppUser:IdentityUser<int>
    {
        public string NameSurname { get; set; }

    }
}
