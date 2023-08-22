using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace dr.Domain.Entities.ShifHours
{
    public class ShiftHours : EntityBase
    {
        public DateTime StartDate { get;private set; }
        public DateTime EndDate { get;private set; }
        public bool IsReserved { get; private set; }
        public int TimeTableId { get; private set; }
        public TimeTable.TimeTable  TimeTable { get; private set; }
        public ShiftHours(DateTime startDate, DateTime endDate, int timeTableId)
        {
            StartDate = startDate;
            EndDate = endDate;
            IsReserved = false;
            TimeTableId = timeTableId;
        }
        public void Edit(DateTime startDate, DateTime endDate, int timeTableId)
        {
            StartDate = startDate;
            EndDate = endDate;
            TimeTableId = timeTableId;
        }

        public void Reserve()
        {
            IsReserved = true;
        }

        public void DeReserve()
        {
            IsReserved = false;
        }
    }
}
