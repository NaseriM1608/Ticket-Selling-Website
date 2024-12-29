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
using System.Runtime.InteropServices;


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
        [DisplayName("شماره موبایل")]
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "فرمت شماره موبایل صحیح نیست")]
        public string PhoneNumber { get; set; }
        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        [MinLength(8, ErrorMessage = "رمز عبور باید حداقل ۸ کاراکتر باشد.")]
        [RegularExpression("^(?=.*\\d)[A-Za-z0-9!@#$%^&*(),.?\":{}|<>]+$", ErrorMessage = "رمز عبور باید فقط حروف انگلیسی باشد و حداقل یک عدد داشته باشد.")]     
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool RememberMe { get; set; }
        public bool IsAdmin { get; set; }
    }
}
