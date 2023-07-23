using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class Book_PromotionService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public Book_PromotionService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Book_Promotion/");
		}

		public async Task<List<Book_PromotionVM>?> GetAsync(Guid? idbook, Guid? idpromotion)
		{
			if (idbook != null && idpromotion == null)
			{
				return await _httpClient.GetFromJsonAsync<List<Book_PromotionVM>>(_url + "all" + $"?idbook={idbook}");
			}
			else if (idpromotion != null && idbook == null)
			{
				return await _httpClient.GetFromJsonAsync<List<Book_PromotionVM>>(_url + "all" + $"?idpromotion={idpromotion}");
			}
			return await _httpClient.GetFromJsonAsync<List<Book_PromotionVM>>(_url + "all");
		}
		
		public async Task<List<Book_PromotionVM>?> GetActiveAsync(Guid? idbook, Guid? idpromotion)
		{
			if (idbook != null && idpromotion == null)
			{
				return await _httpClient.GetFromJsonAsync<List<Book_PromotionVM>>(_url + "active" + $"?idbook={idbook}");
			}
			else if (idpromotion != null && idbook == null)
			{
				return await _httpClient.GetFromJsonAsync<List<Book_PromotionVM>>(_url + "active" + $"?idpromotion={idpromotion}");
			}
			return await _httpClient.GetFromJsonAsync<List<Book_PromotionVM>>(_url + "active");
		}
		
		public async Task<Book_PromotionVM?> GetByIdAsync(Guid? idbook, Guid? idpromotion)
		{
			return await _httpClient.GetFromJsonAsync<Book_PromotionVM>(_url + $"id?idbook={idbook}&idpromotion={idpromotion}");
		}

		public async Task<Book_PromotionVM?> AddAsync(Book_PromotionVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + "add", item);
			return await response.Content.ReadFromJsonAsync<Book_PromotionVM>();
		}
		
		public async Task<Book_PromotionVM?> UpdateAsync(Book_PromotionVM item)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{item.Id_Book}/{item.Id_Promotion}", item);
			return await response.Content.ReadFromJsonAsync<Book_PromotionVM>();
		}
		
		public async Task<Book_PromotionVM?> DeleteAsync(Guid idbook, Guid idpromotion)
		{
			var response = await _httpClient.DeleteAsync(_url + "delete" + $"?idbook={idbook}&idpromotion={idpromotion}");
			return await response.Content.ReadFromJsonAsync<Book_PromotionVM>();
		}

	}
}
