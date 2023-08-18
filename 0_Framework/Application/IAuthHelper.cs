﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
	public interface IAuthHelper
	{
		void Signin(AuthViewModel account);
		bool IsAuthenticated();
		void SignOut();
		string CurrentAccountRole();
		long CurrentAccountId();
		AuthViewModel CurrentAccountInfo();
		// void ConfirmMobile();
	}
}
