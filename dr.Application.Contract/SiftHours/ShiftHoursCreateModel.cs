using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dr.Application.Contract.SiftHours
{
    public class ShiftHoursCreateModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimeTableId { get; set; }
    }
}
