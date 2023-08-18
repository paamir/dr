using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace dr.Application.Contract.User
{
	public class UserLoginModel
	{
		[Required(ErrorMessage = ValidationModel.IsRequired), RegularExpression("(^09)[0-9]{9}", ErrorMessage = ValidationModel.MobileNotValid), MinLength(11, ErrorMessage = ValidationModel.MobileNotValid), MaxLength(11, ErrorMessage = ValidationModel.MobileNotValid)]
		public string Mobile { get; set; }
		[Required(ErrorMessage = "رمز عبور نمی تواند خالی باشد"), MinLength(6, ErrorMessage = "پسورد باید بیشتر از شش کاراکتر باشد")]
		public string Password { get; set; }
	}
}