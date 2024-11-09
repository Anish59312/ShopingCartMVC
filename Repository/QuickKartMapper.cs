using AutoMapper;
using QuickKartDataAccessLayer.Models;

namespace ShopingCartMVC.Repository
{
    public class QuickKartMapper : Profile
    {
        public QuickKartMapper()
        {
            CreateMap<Products, Models.Products>();
            CreateMap<Models.Products, Products>();


        }

    }
}
