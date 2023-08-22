using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using dr.Application.Contract.TimeTable;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace dr.Application.Contract.Doctor
{
	public class DoctorCreateModel
	{
		[Required(ErrorMessage = ValidationModel.IsRequired), MaxLength(500, ErrorMessage = "این فیلد نمی اواند بیشتر از 500 حرف باشد")]
		public string Name { get; set; }
        [Required(ErrorMessage = ValidationModel.IsRequired), MaxLength(500, ErrorMessage = "این فیلد نمی اواند بیشتر از 500 حرف باشد")]
        public string Skill { get; set; }
        [Required(ErrorMessage = ValidationModel.IsRequired), MaxLength(1000, ErrorMessage = "این فیلد نمی اواند بیشتر از 1000 حرف باشد")]
        public string Description { get; set; }
		public int TimeTableId { get; set; }
		public List<TimeTableViewModel> AvailableTimeTables { get; set; }
	}
}