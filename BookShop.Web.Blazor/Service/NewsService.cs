using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class NewsService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public NewsService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/News/");
		}

		public async Task<List<NewsVM>?> GetAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<NewsVM>>(_url + $"all");
		}

		public async Task<NewsVM?> GetByIdAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<NewsVM>(_url + $"{id}");
		}

		public async Task<bool> AddAsync(NewsVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + $"add", item);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> UpdateAsync(NewsVM item)
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
