using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace _0_Framework.Application
{
	public class AuthHelper : IAuthHelper
	{
		private readonly IHttpContextAccessor _contextAccessor;
		public AuthHelper(IHttpContextAccessor contextAccessor)
		{
			_contextAccessor = contextAccessor;
		}

		public void Signin(AuthViewModel account)
		{
			var claims = new List<Claim>
			{
				new Claim("UserId", account.UserId.ToString()),
				new Claim(ClaimTypes.Name, account.Name),
				new Claim(ClaimTypes.Role, account.RoleId.ToString()),
				new Claim(ClaimTypes.MobilePhone, account.Mobile),
				// new Claim("IsConfirm" , account.IsConfirmed.ToString())
			};

			var claimIdentity = new ClaimsIdentity(claims,
				CookieAuthenticationDefaults.AuthenticationScheme);

			var authenticationProperties =
				new Microsoft.AspNetCore.Authentication.AuthenticationProperties
				{
					ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7),
					IsPersistent = true
				};
			_contextAccessor.HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimIdentity),
				authenticationProperties);
		}

		public string CurrentAccountRole()
		{
			return IsAuthenticated()
				? _contextAccessor.HttpContext.User.Claims
					.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
				: null;
		}

		public long CurrentAccountId()
		{
			return IsAuthenticated()
				? long.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value) : 0;
		}

		public AuthViewModel CurrentAccountInfo()
		{
			var result = new AuthViewModel();
			if (!IsAuthenticated())
				return result;
			var claims = _contextAccessor.HttpContext.User.Claims.ToList();
			result.Name = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
			result.RoleId = int.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value);
			result.UserId = int.Parse(claims.FirstOrDefault(x => x.Type == "UserId").Value);
			result.Mobile = claims.FirstOrDefault(x => x.Type == ClaimTypes.MobilePhone)?.Value;
			// result.IsConfirmed = result.IsConfirmed = claims.FirstOrDefault(x => x.Type == "IsConfirm").Value == true.ToString();
			return result;
		}

		// public void ConfirmMobile()
		// {
		// 	var account = CurrentAccountInfo();
		// 	var user = new AuthViewModel
		// 	{
		// 		UserName = account.UserName,
		// 		Permissions = CurrentAccountPermissions(),
		// 		IsConfirmed = true,
		// 		FullName = account.FullName,
		// 		UserId = CurrentAccountId(),
		// 		RoleId = account.RoleId
		// 	};
		// 	Signin(user);
		// }

		public bool IsAuthenticated()
		{
			return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
			// var claims = _contextAccessor.H ttpContext.User.Claims.ToList();
			// return claims.Count > 0;
		}

		public void SignOut()
		{
			_contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		}
	}
}
