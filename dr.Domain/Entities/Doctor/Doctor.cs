using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;

namespace dr.Domain.Entities.Doctor
{
	public class Doctor : EntityBase
	{
		public string Name { get; private set; }
		public string Skill { get; private set; }
		public string Description { get;private set; }
		public bool IsActive { get; private set; }
		public int TimeTableId { get;private set; }
		public TimeTable.TimeTable TimeTable { get; set; }
		public Doctor(string name, string skill, string description, int timeTableId)
		{
			Name = name;
			Skill = skill;
			Description = description;
			IsActive = true;
			TimeTableId = timeTableId;

        }
		public void Edit(string name, string skill, string resume)
		{
			Name = name;
			Skill = skill;
			Description = resume;
		}

		public void Active()
		{
			IsActive = true;
		}

		public void DeActive()
		{
			IsActive = false;
		}
	}
}
