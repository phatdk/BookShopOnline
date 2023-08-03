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
	public class OrderService : IOrderService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public OrderService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(OrderVM item)
		{
			try
			{
				var obj = new Order()
				{
					Id = item.Id,
					Code = item.Code,
					Receiver = item.Receiver,
					Phones = item.Phones,
					CreatedDate = item.CreatedDate,
					DeliveryCharges = item.DeliveryCharges,
					Status = item.Status,
					Id_Address = item.Id_Address,
					Id_Customer = item.Id_Customer,
					Id_PaymentForm = item.Id_PaymentForm,
				};
				await _context.Orders.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Orders.FindAsync(Id);
				await Task.FromResult<Order>(_context.Orders.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
		/*
		 * -3 huy
		 * -2 tra hang
		 * -1 doi hang
		 * 0 dang doi
		 * 1 da xac nhan
		 * 2 dang giao
		 * 3 hoan thanh 
		 */
		public async Task<List<OrderVM>> GetActiveAsync(Guid? IdCustomer, int? status)
		{
			if (IdCustomer != null)
			{
				return await _context.Orders.ProjectTo<OrderVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Customer == IdCustomer && c.Status == status).ToListAsync();
			}
			return await _context.Orders.ProjectTo<OrderVM>(_mapper.ConfigurationProvider).Where(c => c.Status == status).ToListAsync();
		}

		public async Task<List<OrderVM>> GetAsync(Guid? IdCustomer)
		{
			if (IdCustomer != null)
			{
				return await _context.Orders.ProjectTo<OrderVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Customer == IdCustomer).ToListAsync();
			}
			return await _context.Orders.ProjectTo<OrderVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<OrderVM> GetByIdAsync(Guid? Id, string? code)
		{
			try
			{
				if (Id != null)
				{
					return await _context.Orders.ProjectTo<OrderVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
				}
				return await _context.Orders.ProjectTo<OrderVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Code.ToLower().Equals(code.ToLower()));
			}
			catch { return null; }
		}

		public async Task<bool> UpdateAsync(OrderVM item)
		{
			try
			{
				var obj = await _context.Orders.FindAsync(item.Id);
				obj.Receiver = item.Receiver;
				obj.Phones = item.Phones;
				obj.AcceptDate = item.AcceptDate;
				obj.DeliveryDate = item.DeliveryDate;
				obj.ReceiveDate = item.ReceiveDate;
				obj.PaymentDate = item.PaymentDate;
				obj.CompleteDate = item.CompleteDate;
				obj.ModifyDate = item.ModifyDate;
				obj.ModifyNotes = item.ModifyNotes;
				obj.DeliveryCharges = item.DeliveryCharges;
				obj.Id_Address = item.Id_Address;
				obj.Id_PaymentForm = item.Id_PaymentForm;
				obj.Status = item.Status;

				await Task.FromResult<Order>(_context.Orders.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
