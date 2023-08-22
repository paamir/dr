using System.Collections.Generic;
using dr.Application.Contract.SiftHours;

namespace dr.Application.Contract.TimeTable
{
    public class TimeTableViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public List<ShiftHoursViewModel> ShiftHours { get; set; }
    }
}