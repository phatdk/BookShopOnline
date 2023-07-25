using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class AdminService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public AdminService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Admin/");
		}
		public async Task<bool> AddAsync(AdminVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + "add", item);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{Id}");
			if (response != null) return true;
			return false;
		}

		public async Task<List<AdminVM>?> GetActiveAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<AdminVM>>(_url + "active");
		}

		public async Task<List<AdminVM>?> GetAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<AdminVM>>(_url + "all");
		}

		public async Task<AdminVM?> GetByIdAsync(Guid? Id, string? address, int? s)
		{
			if(Id != null) return await _httpClient.GetFromJsonAsync<AdminVM>(_url + "get" + $"?id={Id}&s={s}");
			var result = await _httpClient.GetFromJsonAsync<AdminVM>(_url + "get" + $"?address={address}&s={s}");
			return result;
		}

		public async Task<bool> UpdateAsync(AdminVM item)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{item.Id}", item);
			if(response != null) return true;
			return false;
		}
	}
}
