using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using _0_Framework.Application;
using dr.Application.Contract.SiftHours;
using dr.Application.Contract.TimeTable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dr.Web.Areas.Admin.Pages.TimeTable
{
    public class CreateModel : PageModel
    {
        public TimeTableCreateModel TimeTable { get; set; }
        public List<ShiftHoursViewModel> Shifts { get; set; } = new List<ShiftHoursViewModel>();

        public void OnGet()
        {
            Shifts = new List<ShiftHoursViewModel>()
            {
                new ShiftHoursViewModel()
                {
                    Id = 1, StartDate = DateTime.Now.AddMinutes(2).ToFarsiFull(),
                    EndDate = DateTime.Now.AddMinutes(2).ToFarsiFull(), IsReserved = false
                },
                new ShiftHoursViewModel()
                {
                    Id = 2, StartDate = DateTime.Now.AddMinutes(22).ToFarsiFull(),
                    EndDate = DateTime.Now.AddMinutes(3).ToFarsiFull(), IsReserved = false
                },
                new ShiftHoursViewModel()
                {
                    Id = 3, StartDate = DateTime.Now.AddMinutes(233).ToFarsiFull(),
                    EndDate = DateTime.Now.AddMinutes(4).ToFarsiFull(), IsReserved = false
                },
                new ShiftHoursViewModel()
                {
                    Id = 4, StartDate = DateTime.Now.AddMinutes(244).ToFarsiFull(),
                    EndDate = DateTime.Now.AddMinutes(5).ToFarsiFull(), IsReserved = false
                },
            };
        }

        public IActionResult OnGetAddShift(int id)
        {
            var model = new ShiftHoursCreateModel()
            {
                Id = id + 1
            };
            return Partial("AddShift", model);
        }

        public IActionResult OnPostAddShift(ShiftHoursCreateModel model)
        {
            var html = @"";
            if (ModelState.IsValid)
            {
                html =
                    $@"<tr role=""row"" id='{model.Id}'>
                                        <td>{model.Id}</td>
                                        <td>
                                            <input type=""text"" id=""Shifts_{model.Id}__StartDate"" name=""Shifts[{model.Id}].StartDate"" value=""{model.StartDate}"">
                                        </td>
                                        <td>
                                                <input type=""text"" id=""Shifts_{model.Id}__EndDate"" name=""Shifts[{model.Id}].EndDate"" value=""{model.EndDate}"">
                                        </td>
                                        <td>قابل استفاده</td>
                                        <td>
                                            <a class=""btn btn-warning pull-right m-rl-5"" href=""#showmodal=/Admin/TimeTable?id=1&amp;handler=Edit"">
                                                <i class=""fa fa-edit""></i> ویرایش
                                            </a>
                                            <a class=""btn btn-primary pull-right m-rl-5"" href=""#showmodal=/Admin/TimeTable?email=2&amp;handler=ChangePassword"">
                                                <i class=""fa fa-key""></i> ویراییش زمان بندی
                                            </a>
                                        </td>
                    </tr>";
            }

            return new JsonResult(html);
        }
    }
}