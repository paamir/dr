using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using dr.Application.Contract.TimeTable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dr.Web.Areas.Admin.Pages.TimeTable
{
    public class IndexModel : PageModel
    {
        private readonly ITimeTableApplication _application;

        public IndexModel(ITimeTableApplication application)
        {
            _application = application;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        public TimeTableSearchModel TimeTableSearch { get; set; }

        public List<TimeTableViewModel> TimeTables { get; set; }
        public void OnGet()
        {
            TimeTables = _application.Search(TimeTableSearch);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("Create");
        }

        public IActionResult OnPostCreate(TimeTableCreateModel model)
        {
            var result = _application.Create(model);
            Message = result.Message;
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(TimeTableEditModel model)
        {
            var timeTable = _application.GetDetails(model.Id);
            return Partial("Edit", timeTable);
        }

        public IActionResult OnPostEdit(TimeTableEditModel model)
        {
            var result = _application.Edit(model);
            Message = result.Message;
            return new JsonResult(result);
        }
    }
}
