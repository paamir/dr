using System.Collections.Generic;
using dr.Application.Contract.TimeTable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dr.Web.Areas.Admin.Pages.TimeTable
{
    public class CreateModel : PageModel
    {
        public TimeTableCreateModel TimeTable { get; set; }
        public List<SelectListItem> Shifts { get; set; }
        public void OnGet()
        {
        }
    }
}
