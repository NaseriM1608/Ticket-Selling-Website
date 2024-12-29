using System.ComponentModel;

namespace Grand.Views.ViewModels
{
    public class UserViewModel
    {
        [DisplayName("نام")]
        public string Name { get; set; }
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; }
        [DisplayName("شماره موبایل")]
        public string PhoneNumber { get; set; }
        [DisplayName("رمز عبور")]
        public string Password { get; set; }
        [DisplayName("تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }
    }
}
