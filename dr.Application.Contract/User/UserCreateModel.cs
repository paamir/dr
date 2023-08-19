using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using dr.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace dr.Application.Contract.User
{
    public class UserCreateModel
    {
        [Required(ErrorMessage = ValidationModel.IsRequired), MaxLength(500, ErrorMessage =  "طول {0} نمی تواند بیشتر از {1} حرف باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationModel.IsRequired), RegularExpression("(^09)[0-9]{9}", ErrorMessage = ValidationModel.MobileNotValid), MinLength(11, ErrorMessage = ValidationModel.MobileNotValid), MaxLength(11, ErrorMessage = ValidationModel.MobileNotValid)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = ValidationModel.IsRequired), RegularExpression("^(?=.*[0-9])(?=.*[a-zA-Z])(?=\\S+$).{6,}$", ErrorMessage = ValidationModel.PasswordNotValid), Compare("PasswordReCheck", ErrorMessage = ValidationModel.PasswordCompare)]
        public string Password { get; set; }
        [Required(ErrorMessage = ValidationModel.IsRequired), Compare("Password", ErrorMessage = ValidationModel.PasswordCompare)]
        public string PasswordReCheck { get; set; }

        [Required(ErrorMessage = ValidationModel.IsRequired), MaxLength(500), EmailAddress(ErrorMessage = ValidationModel.IsNotEmail)]
        public string Email { get; set; }

        public int RoleId { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
