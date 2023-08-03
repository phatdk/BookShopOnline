using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using BookShopDAL.ApplicationDBContext;
using BookShopDAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.Service
{
	public class ImageService : IImageService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public ImageService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(ImageVM item)
		{
			try
			{
				var obj = new Image()
				{
					Id = item.Id,
					ImageUrl = item.ImageUrl,
					Index = item.Index,
					CreatedDate = DateTime.Now,
					Id_Parents = item.Id_Parents,
				};
				await _context.Images.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Images.FindAsync(Id);
				await Task.FromResult<Image>(_context.Images.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<ImageVM>> GetAsync(Guid? IdParents)
		{
			if (IdParents != null)
			{
				return await _context.Images.ProjectTo<ImageVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Parents == IdParents).ToListAsync();
			}
			return await _context.Images.ProjectTo<ImageVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<ImageVM> GetByIdAsync(Guid Id)
		{
			try
			{
				return await _context.Images.ProjectTo<ImageVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
			}catch { return null; }
		}

		public async Task<bool> UpdateAsync(ImageVM item)
		{
			try
			{
				var obj = await _context.Images.FindAsync(item.Id);
				obj.ImageUrl = item.ImageUrl;
				obj.Index = item.Index;

				await Task.FromResult<Image>(_context.Images.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
