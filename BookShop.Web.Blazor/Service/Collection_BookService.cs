using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class Collection_BookService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public Collection_BookService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Collection_Book/");
		}

		public async Task<List<Collection_BookVM>?> GetAsync(string? name)
		{
			if (name == null) return await _httpClient.GetFromJsonAsync<List<Collection_BookVM>>(_url + $"all");
			return await _httpClient.GetFromJsonAsync<List<Collection_BookVM>>(_url + $"all?name={name}");
		}

		public async Task<List<Collection_BookVM>?> GetActiveAsync(string? name)
		{
			if (name == null) return await _httpClient.GetFromJsonAsync<List<Collection_BookVM>>(_url + $"active");
			return await _httpClient.GetFromJsonAsync<List<Collection_BookVM>>(_url + $"active?name={name}");
		}

		public async Task<Collection_BookVM?> GetByIdAsync(Guid id) {
			return await _httpClient.GetFromJsonAsync<Collection_BookVM>(_url + $"{id}");
		}

		public async Task<bool> AddAsync(Collection_BookVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + $"add", item);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> UpdateAsync(Collection_BookVM item)
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
