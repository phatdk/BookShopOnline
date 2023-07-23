using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class ReturnOrderService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public ReturnOrderService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/ReturnOrder/");
		}

		public async Task<List<ReturnOrderVM>?> GetAsync(Guid? idorder)
		{
			if (idorder == null) return await _httpClient.GetFromJsonAsync<List<ReturnOrderVM>>(_url + $"all");
			return await _httpClient.GetFromJsonAsync<List<ReturnOrderVM>>(_url + $"all?idorder={idorder}");
		}

		public async Task<ReturnOrderVM?> GetByIdAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<ReturnOrderVM>(_url + $"{id}");
		}

		public async Task<ReturnOrderVM?> AddAsync(ReturnOrderVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + $"add", item);
			return await response.Content.ReadFromJsonAsync<ReturnOrderVM>();
		}

		public async Task<ReturnOrderVM?> UpdateAsync(ReturnOrderVM item)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{item.Id}", item);
			return await response.Content.ReadFromJsonAsync<ReturnOrderVM>();
		}

		public async Task<ReturnOrderVM?> AddAsync(Guid id)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{id}");
			return await response.Content.ReadFromJsonAsync<ReturnOrderVM>();
		}
	}
}
