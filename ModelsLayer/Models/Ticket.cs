using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Primitives;
using System.ComponentModel;

namespace ModelsLayer.Models
{
    [Table("Table_Tickets")]

    public class Ticket : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        public int EventId { get; set; }
        public int? SeatNumber { get; set; }
        [DisplayName("تعداد")]
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        public int Quantity { get; set; }
        [DisplayName("قیمت")]
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        public int Price { get; set; }
        [DisplayName("نوع")]
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        public string Type { get; set; }
        [ForeignKey("EventId")]
        public Event? Event { get; set; }
    }
}
