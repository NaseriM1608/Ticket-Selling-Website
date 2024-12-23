using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.ComponentModel;


namespace ModelsLayer.Models
{
    [Table("Table_Users")]
    public class User : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("نام")]
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("نام خانوادگی")]
        [MaxLength(60)]
        public string LastName { get; set; }
        [DisplayName("آدرس ایمیل")]
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        [MinLength(8, ErrorMessage = "رمز عبور باید حداقل ۸ کاراکتر باشد.")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "فقط حروف انگلیسی وارد شود")]
        [PasswordPropertyText]
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
}
