using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using dr.Domain.Entities.ShifHours;

namespace dr.Domain.Entities.TimeTable
{
    public class TimeTable : EntityBase
    {
        public string Name { get; private set; }
        public bool ItUsed { get; private set; }
        public Doctor.Doctor Doctor { get;private set; }
        public List<ShiftHours> ShiftHoursList { get; private set; }

        public TimeTable(string name)
        {
            ItUsed = false;
            Name = name;
        }

        public void Edit(string name)
        {
            Name = name;
        }

        public void Used()
        {
            ItUsed = true;
        }

        public void DeUsed()
        {
            ItUsed = false;
        }
    }
}
