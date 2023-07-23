using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class CustomerService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public CustomerService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Customer/");
		}

		public async Task<List<CustomerVM>?> GetAsync(string? name)
		{
			if (name == null) return await _httpClient.GetFromJsonAsync<List<CustomerVM>>(_url + $"all");
			return await _httpClient.GetFromJsonAsync<List<CustomerVM>>(_url + $"all?name={name}");
		}

		public async Task<List<CustomerVM>?> GetActiveAsync(string? name)
		{
			if (name == null) return await _httpClient.GetFromJsonAsync<List<CustomerVM>>(_url + $"active");
			return await _httpClient.GetFromJsonAsync<List<CustomerVM>>(_url + $"active?name={name}");
		}

		public async Task<CustomerVM?> GetByIdAsync(Guid? id, string? address, int s)
		{
			if (id != null)	return await _httpClient.GetFromJsonAsync<CustomerVM>(_url + $"get?id={id}&s={s}");
			return await _httpClient.GetFromJsonAsync<CustomerVM>(_url + $"get?address={address}&s={s}");
		}

		public async Task<CustomerVM?> AddAsync(CustomerVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + $"add", item);
			return await response.Content.ReadFromJsonAsync<CustomerVM>();
		}

		public async Task<CustomerVM?> UpdateAsync(CustomerVM item)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{item.Id}", item);
			return await response.Content.ReadFromJsonAsync<CustomerVM>();
		}

		public async Task<CustomerVM?> AddAsync(Guid id)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{id}");
			return await response.Content.ReadFromJsonAsync<CustomerVM>();
		}
	}
}
