using System.Collections.Generic;
using System.ComponentModel.Design;
using dr.Application.Contract.Doctor;
using dr.Application.Contract.TimeTable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dr.Web.Areas.Admin.Pages.Doctor
{
    public class IndexModel : PageModel
    {
        private readonly IDoctorApplication _application;
        private readonly ITimeTableApplication _timeTableApplication;
        public IndexModel(IDoctorApplication application, ITimeTableApplication timeTableApplication)
        {
            _application = application;
            _timeTableApplication = timeTableApplication;
        }

        public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        public DoctorSearchModel DoctorSearch { get; set; }
        public List<DoctorViewModel> Doctors { get; set; }
        public void OnGet()
        {
            Doctors = _application.Search(DoctorSearch);
        }

        public IActionResult OnGetCreate()
        {
            var doctor = new DoctorCreateModel
            {
                AvailableTimeTables = _timeTableApplication.List() 
            };
            return Partial("Create", doctor);
        }

        public IActionResult OnPostCreate(DoctorCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = _application.Create(model);
            Message = result.Message;
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var doctor = _application.GetDetails(id);
            doctor.AvailableTimeTables = _timeTableApplication.List();
            return Partial("Edit", doctor);
        }

        public IActionResult OnPostEdit(DoctorEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = _application.Edit(model);
            Message = result.Message;
            return new JsonResult(result);
        }
    }
}
