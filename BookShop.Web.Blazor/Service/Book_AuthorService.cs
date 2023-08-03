using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class Book_AuthorService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public Book_AuthorService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Book_Author");
		}

		public async Task<List<Book_AuthorVM>?> GetAsync(Guid? idbook, Guid? idauthor)
		{
			if (idbook != null && idauthor == null) return await _httpClient.GetFromJsonAsync<List<Book_AuthorVM>>(_url + "all" + $"?idbook={idbook}");
			else if (idauthor != null && idbook == null) return await _httpClient.GetFromJsonAsync<List<Book_AuthorVM>>(_url + "all" + $"?idauthor={idauthor}");
			return await _httpClient.GetFromJsonAsync<List<Book_AuthorVM>>(_url + "all");
		}

		public async Task<Book_AuthorVM?> GetByIdAsync(Guid idbook, Guid idauthor)
		{
			return await _httpClient.GetFromJsonAsync<Book_AuthorVM>(_url + $"{idbook}/{idauthor}");
		}

		public async Task<bool> AddAsync(List<Book_AuthorVM> obj)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + "add", obj);
			if (response != null) return true;
			return false;
		}

		public async Task<bool> UpdateAsync(Book_AuthorVM obj)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{obj.Id_Book}/{obj.Id_Author}", obj);
			if(response != null) return true;
			return false;
		}

		public async Task<bool> DeleteAsync(Guid idbook, Guid? idauthor)
		{
			if (idauthor == null)
			{
				var response = await _httpClient.DeleteAsync(_url + "delete" + $"?idbook={idbook}");
				if(response != null) return true;
				return false;
			}
			else
			{
				var response = await _httpClient.DeleteAsync(_url + "delete" + $"?idbook={idbook}&idauthor{idauthor}");
				if(response != null) return true;
				return false;
			}
		}

	}
}
