using _0_Framework.Application;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using _0_Framework.Interfaces;

namespace dr.Web.TagHelpers
{
    [HtmlTargetElement(Attributes = "RequireRoles")]
    public class RequireRolesTagHelper : TagHelper
    {
        public int[] Roles { get; set; }
        private readonly IAuthHelper _authHelper;

        public RequireRolesTagHelper(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!_authHelper.IsAuthenticated())
            {
                output.SuppressOutput();
                return;
            }

            var accountRole = int.Parse(_authHelper.CurrentAccountRole());
            if (Roles.Contains(accountRole))
            {
                output.SuppressOutput();
                return;
            }


            base.Process(context, output);
        }
    }
}
