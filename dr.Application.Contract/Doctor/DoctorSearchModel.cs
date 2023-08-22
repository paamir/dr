
using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dr.Application.Contract.Doctor
{
	public class DoctorSearchModel
	{
        [MaxLength(500, ErrorMessage = "این فیلد نمی اواند بیشتر از 500 حرف باشد")]
        public string Name { get; set; }
        [MaxLength(500, ErrorMessage = "این فیلد نمی اواند بیشتر از 500 حرف باشد")]
        public string Skill { get; set; }
	}
}
