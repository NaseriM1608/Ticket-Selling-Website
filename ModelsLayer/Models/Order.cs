using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Models
{
    [Table("Table_Orders")]
    public class Order : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        [DisplayName("تعداد")]
        public int Quantity { get; set; }
        public int SeatNumber { get; set; }
        [DisplayName("تاریخ خرید")]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
    }
}
