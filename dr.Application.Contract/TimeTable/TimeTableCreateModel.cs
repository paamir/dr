using System.Collections.Generic;
using dr.Application.Contract.SiftHours;

namespace dr.Application.Contract.TimeTable
{
    public class TimeTableCreateModel
    {
        public string Name { get; set; }
        // public List<ShiftHoursCreateModel> aaa { get; set; }
        public List<int> ShiftHours { get; set; }
    }
}