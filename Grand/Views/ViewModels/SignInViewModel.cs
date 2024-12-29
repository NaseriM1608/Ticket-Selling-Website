using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Grand.Views.ViewModels
{
    public class SignInViewModel
    {
        [DisplayName("شماره موبایل")]
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "فرمت شماره موبایل صحیح نیست")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "فیلد {0} اجباری است.")]
        [DisplayName("رمز عبور")]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("مرا به خاطر بسپارید")]
        public bool RememberMe { get; set; }
    }
}
