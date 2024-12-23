﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.Context;
using ModelsLayer.Models;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Classes
{
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}