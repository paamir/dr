using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Interfaces;
using dr.Application.Contract.Doctor;
using dr.Domain.Entities.Doctor;
using Microsoft.EntityFrameworkCore;

namespace dr.Infrastracture.Repositories
{
	public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
	{
		private readonly ApplicationDbContext _context;
		public DoctorRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public List<DoctorViewModel> Search(DoctorSearchModel model)
		{
			var query = _context.Doctors.Select(x => new DoctorViewModel()
			{
				Id= x.Id,
				Name= x.Name,
				Skill = x.Skill,
				IsActive = x.IsActive,
				Description = x.Description,
				CreationDate = x.CreationDate.ToFarsiFull()
			});

			if (!string.IsNullOrWhiteSpace(model.Name))
			{
				query = query.Where(x => x.Name.Contains(model.Name));
			}

			if (!string.IsNullOrWhiteSpace(model.Skill))
			{
				query = query.Where(x => x.Skill.Contains(model.Name));
			}
			return query.ToList();
		}

        public DoctorEditModel GetDetails(int id)
        {
            return _context.Doctors.Select(x => new DoctorEditModel()
            {
				Description = x.Description,
				Id = x.Id,
				Name = x.Name,
				Skill = x.Skill
            }).FirstOrDefault(x => x.Id == id) ?? new DoctorEditModel();
        }
    }
}
