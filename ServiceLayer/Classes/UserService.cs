﻿using ModelsLayer.Context;
using ModelsLayer.Models;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Classes
{
    public class UserService : EntityService<User>, IUserService
    {
        public UserService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
