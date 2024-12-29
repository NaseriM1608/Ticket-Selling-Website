using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class SignUpViewModel
{
    [Required(ErrorMessage = "فیلد {0} اجباری است.")]
    [DisplayName("نام")]
    public string Name { get; set; }
    [Required(ErrorMessage = "فیلد {0} اجباری است.")]
    [DisplayName("نام خانوادگی")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "فیلد {0} اجباری است.")]
    [DisplayName("شماره موبایل")]
    [RegularExpression("(09)[0-9]{9}", ErrorMessage = "فرمت شماره موبایل صحیح نیست")]
    public string PhoneNumber { get; set; }
    [DisplayName("رمز عبور")]
    [Required(ErrorMessage = "فیلد {0} اجباری است.")]
    [MinLength(8, ErrorMessage = "رمز عبور باید حداقل ۸ کاراکتر باشد.")]
    [RegularExpression("^(?=.*\\d)[A-Za-z0-9!@#$%^&*(),.?\":{}|<>]+$", ErrorMessage = "رمز عبور باید فقط حروف انگلیسی باشد و حداقل یک عدد داشته باشد.")]
    [PasswordPropertyText]
    public string Password { get; set; }
    [DisplayName("تکرار رمز عبور")]
    [Required(ErrorMessage = "فیلد {0} اجباری است.")]
    [Compare("Password", ErrorMessage = "رمز مشابه تکرار رمز نیست.")]
    [PasswordPropertyText]
    public string ConfirmPassword { get; set; }
}