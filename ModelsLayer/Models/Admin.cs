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
    public class Admin : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [DisplayName("قابلیت مدیریت کاربرها")]
        public bool CanManageUsers { get; set; }
        [DisplayName("قابلیت مدیریت کنفرانس‌ها")]
        public bool CanManageConferences { get; set; }
        [DisplayName("قابلیت مدیریت سفارش‌ها")]
        public bool CanManageOrders { get; set; }
        public List<DateTime> LastLogins { get; set; } = new List<DateTime>();
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
