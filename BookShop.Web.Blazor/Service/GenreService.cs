﻿using BookShopBLL.ViewModel;

namespace BookShop.Web.Blazor.Service
{
	public class GenreService
	{
		private readonly HttpClient _httpClient;
		private readonly Uri _url;
		public GenreService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = new Uri("https://localhost:7033/api/Genre/");
		}

		public async Task<List<GenreVM>?> GetAsync(string? name)
		{
			if (name == null) return await _httpClient.GetFromJsonAsync<List<GenreVM>>(_url + $"all");
			return await _httpClient.GetFromJsonAsync<List<GenreVM>>(_url + $"all?name={name}");
		}

		public async Task<List<GenreVM>?> GetActiveAsync(string? name)
		{
			if (name == null) return await _httpClient.GetFromJsonAsync<List<GenreVM>>(_url + $"active");
			return await _httpClient.GetFromJsonAsync<List<GenreVM>>(_url + $"active?name={name}");
		}

		public async Task<GenreVM?> GetByIdAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<GenreVM>(_url + $"{id}");
		}

		public async Task<GenreVM?> AddAsync(GenreVM item)
		{
			var response = await _httpClient.PostAsJsonAsync(_url + $"add", item);
			return await response.Content.ReadFromJsonAsync<GenreVM>();
		}

		public async Task<GenreVM?> UpdateAsync(GenreVM item)
		{
			var response = await _httpClient.PutAsJsonAsync(_url + $"update/{item.Id}", item);
			return await response.Content.ReadFromJsonAsync<GenreVM>();
		}

		public async Task<GenreVM?> AddAsync(Guid id)
		{
			var response = await _httpClient.DeleteAsync(_url + $"delete/{id}");
			return await response.Content.ReadFromJsonAsync<GenreVM>();
		}
	}
}
