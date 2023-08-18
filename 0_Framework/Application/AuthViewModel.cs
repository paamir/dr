using System.Collections.Generic;

namespace _0_Framework.Application
{
	public class AuthViewModel
	{
		public long UserId { get; set; }
		public long RoleId { get; set; }
		public string Mobile { get; set; }
		public string Name { get; set; }
		// public bool IsConfirmed { get; set; } = false;
		public AuthViewModel()
		{
		}

		public AuthViewModel(long userId, long roleId, string mobile, string name)
		{
			UserId = userId;
			RoleId = roleId;
			Mobile = mobile;
			Name = name;
		}

	}
}