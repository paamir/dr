using dr.Application.Contract.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dr.Web.Pages
{
    public class LoginModel : PageModel
    {
	    private readonly IUserApplication _application;

		[BindProperty]
	    public UserLoginModel LoginUser { get; set; }
	    public LoginModel(IUserApplication application)
	    {
		    _application = application;
	    }

	    [TempData]
		public string LoginMessage { get; set; }
        [TempData]
		public string ReturnUrl { get; set; }
        public void OnGet([FromQuery] string returnUrl)
        {
            ReturnUrl = returnUrl;
        }

        public IActionResult OnPost()
        {
	        if (!ModelState.IsValid)
	        {
		        return Page();
	        }
	        var result = _application.Login(LoginUser);
	        if (result.IsSuccedded)
	        {
		        return Redirect(ReturnUrl == null ? "./Index" : $"{ReturnUrl}");
	        }
	        LoginMessage = result.Message;
	        return Page();
		}

        public IActionResult OnGetLogOut()
        {
            _application.LogOut();
            return RedirectToPage("./Index");
        }
    }
}
