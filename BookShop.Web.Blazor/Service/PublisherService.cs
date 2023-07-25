using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class PublisherService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public PublisherService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Publisher/");
		}

		public async Task<List<PublisherVM>?> GetAsync(string? name)
		{
			if (name == null) return await _httpClient.GetFromJsonAsync<List<PublisherVM>>(_url + $"all");
			return await _httpClient.GetFromJsonAsync<List<PublisherVM>>(_url + $"all?name={name}");
		}

		public async Task<List<PublisherVM>?> GetActiveAsync(string? name)
		{
			if (name == null) return await _httpClient.GetFromJsonAsync<List<PublisherVM>>(_url + $"active");
			return await _httpClient.GetFromJsonAsync<List<PublisherVM>>(_url + $"active?name={name}");
		}

		public async Task<PublisherVM?> GetByIdAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<PublisherVM>(_url + $"{id}");
		}

		public async Task<bool> AddAsync(PublisherVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + $"add", item);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> UpdateAsync(PublisherVM item)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{item.Id}", item);
			if(response != null) return true;
			return false;
		}

		public async Task<bool> AddAsync(Guid id)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{id}");
			if(response != null) return true;
			return false;
		}
	}
}
