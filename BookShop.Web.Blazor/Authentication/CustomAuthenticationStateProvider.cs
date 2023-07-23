using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace BookShop.Web.Blazor.Authentication
{
	public class CustomAuthenticationStateProvider : AuthenticationStateProvider
	{
		private readonly ProtectedSessionStorage _protectedStorage;
		private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
		public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
		{
			_protectedStorage = sessionStorage;
		}
		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			try
			{
				var userSessonStorageResult = await _protectedStorage.GetAsync<AccountLogin>("AcountLogin");
				var userSession = userSessonStorageResult.Success ? userSessonStorageResult.Value : null;
				if (userSession == null)
				{
					return await Task.FromResult(new AuthenticationState(_anonymous));
				}
				var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
				{
					new Claim(ClaimTypes.Name, userSession.Name),
					new Claim(ClaimTypes.Role, userSession.Role)
				}, "CustomAuth"));
				return await Task.FromResult(new AuthenticationState(claimsPrincipal));
			}
			catch
			{
				return await Task.FromResult(new AuthenticationState(_anonymous));
			}
		}

		public async Task UpdateAuthenticationState(AccountLogin account)
		{
			ClaimsPrincipal claimsPrincipal;
			if (account != null)
			{
				await _protectedStorage.SetAsync("AcountLogin", account);
				claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
				{
					new Claim(ClaimTypes.Name, account.Name),
					new Claim(ClaimTypes.Role, account.Role)
				}));
			}
			else
			{
				await _protectedStorage.DeleteAsync("AcountLogin");
				claimsPrincipal = _anonymous;
			}
			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
		}
	}
}
