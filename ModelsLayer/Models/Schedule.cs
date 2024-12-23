using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Models
{
    public class Schedule : BaseEntity
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public Event? Event { get; set; }
    }
}
