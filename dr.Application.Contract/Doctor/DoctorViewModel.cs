namespace dr.Application.Contract.Doctor
{
	public class DoctorViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string CreationDate { get; set; }
		public string Skill { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}