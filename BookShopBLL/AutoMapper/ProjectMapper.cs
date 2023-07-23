using AutoMapper;
using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.AutoMapper
{
	public class ProjectMapper : Profile
	{
        public ProjectMapper()
        {
            CreateMap<Admin, AdminVM>().ReverseMap();
            CreateMap<Author, Author>().ReverseMap();
            CreateMap<Book, BookVM>().ReverseMap();
            CreateMap<Book_Author, Book_AuthorVM>().ReverseMap();
            CreateMap<Book_Promotion,Book_PromotionVM>().ReverseMap();
            CreateMap<Brand, BrandVM>().ReverseMap();
            CreateMap<Cart, CartVM>().ReverseMap();
            CreateMap<Collection_Book, Collection_BookVM>().ReverseMap();
            CreateMap<Comment, CommentVM>().ReverseMap();
            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<Customer_Promotion, Customer_PromotionVM>().ReverseMap();
            CreateMap<Delivery_Address, Delivery_AddressVM>().ReverseMap();
            CreateMap<Evaluate, EvaluateVM>().ReverseMap();
            CreateMap<Genre, GenreVM>().ReverseMap();
            CreateMap<Image, ImageVM>().ReverseMap();
            CreateMap<News, NewsVM>().ReverseMap();
            CreateMap<Order, OrderVM>().ReverseMap();
            CreateMap<Order_Book, Order_BookVM>().ReverseMap();
            CreateMap<Order_Promotion, Order_PromotionVM>().ReverseMap();
            CreateMap<Payment_Form, Payment_FormVM>().ReverseMap();
            CreateMap<Promotion, PromotionVM>().ReverseMap();
            CreateMap<Promotion_Type, Promotion_TypeVM>().ReverseMap();
            CreateMap<Publisher, PublisherVM>().ReverseMap();
            CreateMap<ReturnOrder, ReturnOrderVM>().ReverseMap();
            CreateMap<Shop, ShopVM>().ReverseMap();
            CreateMap<WishList, WishListVM>().ReverseMap();
        }
    }
}
