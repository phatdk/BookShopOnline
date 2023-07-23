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
	public class Delivery_AddressService : IDelivery_AddressService
	{
		BookShopDBContext _context;
		IMapper _mapper;
        public Delivery_AddressService(IMapper mapper)
        {
			_context = new BookShopDBContext();
			_mapper = mapper;
        }
        public  async Task<bool> AddAsync(Delivery_AddressVM item)
		{
			try
			{
				var obj = new Delivery_Address()
				{
					Id = item.Id,
					Address = item.Address,
					CreatedDate = DateTime.Now,
					Status = 1,
					Id_Customer = item.Id_Customer,
				};
				await _context.Delivery_Addresses.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}catch (Exception ex) { return false; }
		}

		public  async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Delivery_Addresses.FindAsync(Id);
				await Task.FromResult<Delivery_Address>(_context.Delivery_Addresses.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}catch(Exception ex) { return false; }
		}

		public  async Task<List<Delivery_AddressVM>> GetActiveAsync(Guid? IdCustomer)
		{
			if (IdCustomer != null)
			{
				return await _context.Delivery_Addresses.ProjectTo<Delivery_AddressVM>(_mapper.ConfigurationProvider).Where(c=>c.Id_Customer == IdCustomer && c.Status == 1).ToListAsync();
			}return await _context.Delivery_Addresses.ProjectTo<Delivery_AddressVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1).ToListAsync();
		}

		public  async Task<List<Delivery_AddressVM>> GetAsync(Guid? IdCustomer)
		{
			if (IdCustomer != null)
			{
				return await _context.Delivery_Addresses.ProjectTo<Delivery_AddressVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Customer == IdCustomer).ToListAsync();
			}
			return await _context.Delivery_Addresses.ProjectTo<Delivery_AddressVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public  async Task<Delivery_AddressVM> GetByIdAsync(Guid Id)
		{
			return await _context.Delivery_Addresses.ProjectTo<Delivery_AddressVM>(_mapper.ConfigurationProvider).FirstAsync(c=>c.Id == Id);
		}

		public  async Task<bool> UpdateAsync(Delivery_AddressVM item)
		{
			try
			{
				var obj = await _context.Delivery_Addresses.FindAsync(item.Id);
				obj.Address =item.Address;
				obj.Status = item.Status;
				obj.Id_Customer = item.Id_Customer;

				await Task.FromResult<Delivery_Address>(_context.Delivery_Addresses.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}catch (Exception ex) { return false; }
		}
	}
}
