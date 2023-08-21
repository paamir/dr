using _0_Framework.Application;
using dr.Application.Contract.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dr.Web.Pages
{
    public class ChangePasswordModel : PageModel
    {
	    private readonly IUserApplication _userApplication;

	    public UserChangePasswordModel UserChangePassword { get; set; }
		[TempData]
		public string Message { get; set; }
	    public ChangePasswordModel(IUserApplication userApplication)
	    {
		    _userApplication = userApplication;
	    }

	    [BindProperty] public UserChangePasswordModel NewPassword { get; set; } = new UserChangePasswordModel();
        public void OnGet(string token)
        {
	        NewPassword.Id = _userApplication.GetUserIdBy(token);
        }

        public IActionResult OnPostChangePassword()
        {
	        if (!ModelState.IsValid)
	        {
		        return Page();
	        }
	        var result = _userApplication.CustomerChangePassword(NewPassword);

			if (result.IsSuccedded)
	        {
		        return RedirectToPage("./Index");
	        }

			return Page();
        }
    }
}
