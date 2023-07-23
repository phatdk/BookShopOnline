using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class BookService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public BookService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Book/");
		}

		public async Task<List<BookVM>?> GetAsync(string? name)
		{
			if (name == null) return await _httpClient.GetFromJsonAsync<List<BookVM>>(_url + "all");
			return await _httpClient.GetFromJsonAsync<List<BookVM>>(_url + "all" + $"?name={name}");
		}

		public async Task<List<BookVM>?> GetActiveAsync(string? name)
		{
			if (name == null) return await _httpClient.GetFromJsonAsync<List<BookVM>>(_url + "active");
			return await _httpClient.GetFromJsonAsync<List<BookVM>>(_url + "active" + $"?name={name}");
		}

		public async Task<BookVM?> GetByIdAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<BookVM?>(_url + $"{id}");
		}

		public async Task<BookVM?> AddAsync(BookVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + $"add", item);
			return await response.Content.ReadFromJsonAsync<BookVM>();
		}

		public async Task<BookVM?> UpdateAsync(BookVM item)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{item.Id}", item);
			return await response.Content.ReadFromJsonAsync<BookVM>();
		}

		public async Task<BookVM?> DeleteAsync(Guid id)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{id}");
			return await response.Content.ReadFromJsonAsync<BookVM?>();
		}

	}
}
