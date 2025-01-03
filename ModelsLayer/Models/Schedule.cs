﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Models
{
    [Table("Table_Schedules")]

    public class Schedule : BaseEntity
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public Event? Event { get; set; }
    }
}
