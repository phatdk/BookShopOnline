using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class OrderService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public OrderService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Order/");
		}

		public async Task<List<OrderVM>?> GetAsync(Guid? idcustomer)
		{
			if (idcustomer == null) return await _httpClient.GetFromJsonAsync<List<OrderVM>>(_url + "all");
			return await _httpClient.GetFromJsonAsync<List<OrderVM>>(_url + $"all?idcustomer={idcustomer}");
		}

		public async Task<List<OrderVM>?> GetActiveAsync(Guid? idcustomer, int s)
		{
			if (idcustomer == null) return await _httpClient.GetFromJsonAsync<List<OrderVM>>(_url + $"active?s={s}");
			return await _httpClient.GetFromJsonAsync<List<OrderVM>>(_url + $"active?idcustomer={idcustomer}&s={s}");
		}

		public async Task<OrderVM?> GetByIdAsync(Guid? id, string? code)
		{
			if (id != null) return await _httpClient.GetFromJsonAsync<OrderVM>(_url + $"get?id={id}");
			return await _httpClient.GetFromJsonAsync<OrderVM>(_url + $"get?code={code}");
		}

		public async Task<bool> AddAsync(OrderVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + "add", item);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> UpdateAsync(OrderVM item)
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
