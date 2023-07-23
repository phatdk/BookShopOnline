using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class CartService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public CartService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Cart/");
		}

		public async Task<List<CartVM>?> GetAsync(Guid? idcustomer, Guid? idbook)
		{
			if (idcustomer != null && idbook == null) return await _httpClient.GetFromJsonAsync<List<CartVM>>(_url + $"all?idcustomer={idcustomer}");
			else if (idbook != null && idcustomer == null) return await _httpClient.GetFromJsonAsync<List<CartVM>>(_url + $"all?idbook={idbook}");
			return await _httpClient.GetFromJsonAsync<List<CartVM>>(_url + "all");
		}

		public async Task<CartVM?> GetByIdAsync(Guid idcustomer, Guid idbook)
		{
			return await _httpClient.GetFromJsonAsync<CartVM>(_url + $"{idcustomer}/{idbook}");
		}

		public async Task<CartVM?> AddAsync(CartVM cartVM)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + "add", cartVM);
			return await response.Content.ReadFromJsonAsync<CartVM>();
		}
		
		public async Task<CartVM?> UpdateAsync(CartVM cartVM)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{cartVM.Id_Customer}/{cartVM.Id_Book}", cartVM);
			return await response.Content.ReadFromJsonAsync<CartVM>();
		}
		
		public async Task<CartVM?> DeleteAsync(Guid? idcustomer, Guid? idbook)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{idcustomer}/{idbook}");
			return await response.Content.ReadFromJsonAsync<CartVM>();
		}

	}
}
