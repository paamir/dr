namespace dr.Application.Contract.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string CreationDate { get; set; }
        public int RoleId { get; set; }
    }
}
