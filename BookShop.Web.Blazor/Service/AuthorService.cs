using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class AuthorService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public AuthorService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Author/");
		}

		public async Task<List<AuthorVM>?> GetAsync(string? name)
		{
			if (name == null) return await _httpClient.GetFromJsonAsync<List<AuthorVM>>(_url + "all");
			return await _httpClient.GetFromJsonAsync<List<AuthorVM>>(_url + "all" + $"?name={name}");
		}

		public async Task<List<AuthorVM>?> GetActiveAsync(string? name)
		{
			if (name == null) return await _httpClient.GetFromJsonAsync<List<AuthorVM>>(_url + "active");
			return await _httpClient.GetFromJsonAsync<List<AuthorVM>>(_url + "active" + $"?name={name}");
		}

		public async Task<AuthorVM?> GetByIdAsync(Guid Id)
		{
			return await _httpClient.GetFromJsonAsync<AuthorVM>(_url + $"{Id}");
		}

		public async Task<bool> AddAsync(AuthorVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + $"add", item);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> UpdateAsync(AuthorVM item)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{item.Id}", item);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> AddAsync(Guid id)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{id}");
			if (response != null) return true;
			return false;
		}

	}
}
