using System.Collections.Generic;
using dr.Application.Contract.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dr.Web.Areas.Admin.Pages.User
{
    [Authorize(Roles = _0_Framework.Interfaces.Roles.Doctor + "," + _0_Framework.Interfaces.Roles.Assistant)]
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly IUserApplication _application;
        public List<UserViewModel> Users;
        public SelectList Roles;
        [BindProperty(SupportsGet = true)]
        public UserSearchModel UserSearch { get; set; } = new UserSearchModel();

        public IndexModel(IUserApplication application)
        {
            _application = application;
        }

        public void OnGet()
        {
            var model = UserSearch;

            Roles = new SelectList(_application.GetAllRoles(), "Id", "Name");
            Users = _application.Search(model);
        }

        public IActionResult OnGetCreate()
        {
	        var user = new UserCreateModel()
	        {
		        Roles = _application.GetAllRoles(),
	        };
            return Partial("Create", user);
        }
        public IActionResult OnPostCreate(UserCreateModel model)
        {
            var result = _application.Create(model);
            Message = result.Message;
            return new JsonResult(result);
        }

        public IActionResult OnGetChangePassword(int id)
        {
            var changePassword = new UserChangePasswordModel()
            {
                Id = id
            };
            return Partial("ChangePassword", changePassword);
        }

        public IActionResult OnPostChangePassword(UserChangePasswordModel model)
        {
            var result = _application.ChangePassword(model);
            Message = result.Message;
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var user = _application.GetDetails(id);
            user.Roles = _application.GetAllRoles();
            return Partial("Edit", user);
        }

        public IActionResult OnPostEdit(UserEditModel model)
        {
            var result = _application.Edit(model);
            Message = result.Message;
            return new JsonResult(result);
        }

    }
}
