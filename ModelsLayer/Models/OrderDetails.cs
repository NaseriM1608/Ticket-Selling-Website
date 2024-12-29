using ModelsLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

[Table("Table_OrderDetails")]
public class OrderDetails : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int TicketId { get; set; }
    [DisplayName("Price")]
    public int Price { get; set; }
    public int SeatNumber { get; set; }
    [ForeignKey("OrderId")]
    public Order Order { get; set; }
    [ForeignKey("TicketId")]
    public Ticket Ticket { get; set; }
}
