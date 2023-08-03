using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class Order_BookService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public Order_BookService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Order_Book");
		}

		public async Task<List<Order_BookVM>?> GetAsync(Guid? idorder, Guid? idbook)
		{
			if (idorder != null && idbook == null) return await _httpClient.GetFromJsonAsync<List<Order_BookVM>>(_url + "all" + $"?idorder={idorder}");
			else if (idbook != null && idorder == null) return await _httpClient.GetFromJsonAsync<List<Order_BookVM>>(_url + "all" + $"?idbook={idbook}");
			return await _httpClient.GetFromJsonAsync<List<Order_BookVM>>(_url + "all");
		}

		public async Task<Order_BookVM?> GetByIdAsync(Guid idorder, Guid idbook)
		{
			return await _httpClient.GetFromJsonAsync<Order_BookVM>(_url + $"{idorder}/{idbook}");
		}

		public async Task<bool> AddAsync(List<Order_BookVM> obj)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + "add", obj);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> UpdateAsync(Order_BookVM obj)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{obj.Id_Order}/{obj.Id_Book}", obj);
			if(response != null) return true;
			return false;
		}

		public async Task<bool> DeleteAsync(Guid idorder, Guid? idbook)
		{
			if (idbook == null)
			{
				var response = await _httpClient.DeleteAsync(_url + "delete" + $"?idorder={idorder}");
				if(response != null) return true;
				return false;
			}
			else
			{
				var response = await _httpClient.DeleteAsync(_url + "delete" + $"?idorder={idorder}&idbook{idbook}");
				if(response != null) return true;
				return false;
			}
		}
	}
}
