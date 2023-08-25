using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace dr.Application.Contract.TimeTable
{
    public class TimeTableEditModel : TimeTableCreateModel
    {
        public int Id { get; set; }
    }
}
