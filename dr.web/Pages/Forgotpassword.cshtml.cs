using dr.Application.Contract.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using _0_Framework.Application;

namespace dr.Web.Pages
{
    public class ForgotpasswordModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly IUserApplication _userApplication;

        public ForgotpasswordModel(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostSendForgotPasswordCode(string email)
        {
            var result = _userApplication.CreateAndSendVerificationCode(email);
            result.Email = email.EncryptString();
            return new JsonResult(result);
        }

        public IActionResult OnPostVerifyCode(string token)
        {
            var result = _userApplication.CheckRecoverCode(token);
            Message = result.Message;
            if (result.IsSuccedded)
            {
                return RedirectToPage("ChangePassword", new{token});
            }

            return Page();
        }
    }
}
