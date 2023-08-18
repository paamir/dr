using System.ComponentModel.DataAnnotations;

namespace dr.Application.Contract.User
{
    public class UserChangePasswordModel
    {
        public int Id { get; set; }

        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
