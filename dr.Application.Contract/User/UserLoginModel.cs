using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace dr.Application.Contract.User
{
	public class UserLoginModel
	{
		[Required(ErrorMessage = ValidationModel.IsRequired), RegularExpression("(^09)[0-9]{9}", ErrorMessage = ValidationModel.MobileNotValid), MinLength(11, ErrorMessage = ValidationModel.MobileNotValid), MaxLength(11, ErrorMessage = ValidationModel.MobileNotValid)]
		public string Mobile { get; set; }
		[Required(ErrorMessage = "رمز عبور نمی تواند خالی باشد"), RegularExpression("^(?=.*[0-9])(?=.*[a-zA-Z])(?=\\S+$).{6,}$", ErrorMessage = ValidationModel.PasswordNotValid)]
		public string Password { get; set; }
	}
}