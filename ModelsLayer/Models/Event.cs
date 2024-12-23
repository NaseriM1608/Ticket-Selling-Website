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
    [Table("Table_Events")]
    public class Event : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("موضوع")]
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        public string? Name { get; set; }
        [DisplayName("توضیحات")]
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        public string? Description { get; set; }
        [DisplayName("نام مجری")]
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        public string? PresenterName { get; set; }
        [DisplayName("تاریخ")]
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        public IEnumerable<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
