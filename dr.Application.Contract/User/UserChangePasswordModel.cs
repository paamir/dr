using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace dr.Application.Contract.User
{
    public class UserChangePasswordModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ValidationModel.IsRequired), Compare("NewPassword", ErrorMessage = ValidationModel.PasswordCompare)]
        public string PasswordReCheck { get; set; }
        [Required(ErrorMessage = ValidationModel.IsRequired), RegularExpression("^(?=.*[0-9])(?=.*[a-zA-Z])(?=\\S+$).{6,}$", ErrorMessage = ValidationModel.PasswordNotValid), Compare("PasswordReCheck", ErrorMessage = ValidationModel.PasswordCompare)]
        public string NewPassword { get; set; }
    }
}
