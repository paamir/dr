using _0_Framework.Interfaces;
using dr.Application.Contract.User;
using dr.Domain.Entities.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dr.Web.Pages
{
    public class RegisterModel : PageModel
    {
	    private readonly IUserApplication _application;
		[TempData]
	    public string Message { get; set; }

		[BindProperty]
		public UserCreateModel RegisterUser { get; set; } 
	    public RegisterModel(IUserApplication application)
	    {
		    _application = application;
	    }

	    public void OnGet()
        {
        }

	    public IActionResult OnPost()
	    {
		    if (!ModelState.IsValid)
		    {
			    return Page();
		    }
		    RegisterUser.RoleId = int.Parse(Roles.Customer);
		    var result = _application.Create(RegisterUser);
		    Message = result.Message;
		    if (!result.IsSuccedded)
		    {
			    return Page();
		    }

		    _application.Login(new UserLoginModel { Mobile = RegisterUser.Mobile, Password = RegisterUser.Password});
		    return RedirectToPage("./Index");
	    }
    }
}
