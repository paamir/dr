using dr.Application.Contract.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace dr.Web.Pages
{
    public class ForgotpasswordModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly IUserApplication _userApplication;
        public void OnGet()
        {
        }

        public IActionResult OnPostSendForgotPasswordCode(string email)
        {
            var result = _userApplication.CreateAndSendVerificationCode(email);
            Message = result.Message;
            return Page();
        }

        public IActionResult OnPostVerifyCode(string token)
        {
            var result = _userApplication.CheckRecoverCode(token);
            Message = result.Message;
            return Page();
        }
    }
}