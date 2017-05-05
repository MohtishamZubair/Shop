using AutoMapper;
using Shop.Models.Models;
using System;
using System.Linq;

namespace Shop.Models
{
    public static class AutoMapperHelper
    {
        public static void LoadMapping()
        {
            Mapper.CreateMap<Category, CategoryView>()
                .ForMember(cv => cv.Id, c => c.MapFrom(ct=>ct.CategoryId))
                .ForMember(cv => cv.SubCategoryName, c=>c.MapFrom(ct=>ct.SubCategory.Name));            
            Mapper.CreateMap<CategoryView, Category>()
                .ForMember(cv=>cv.CategoryId,d=>d.MapFrom(c=>c.Id));
            Mapper.CreateMap<Product, ProductView>()
                .ForMember(pv => pv.Id, p => p.MapFrom(pt => pt.ProductId))
                .ForMember(pv=>pv.CategoryId,p=>p.MapFrom(pc=>pc.Categories.FirstOrDefault().CategoryId));
            Mapper.CreateMap<ProductView, Product>()
                 .ForMember(pv => pv.ProductId, p => p.MapFrom(pt => pt.Id));
            Mapper.CreateMap<ProductListing, ListingView>();                  
            Mapper.CreateMap<ListingView, ProductListing>();
            Mapper.CreateMap<ApplicationUser, UserView>()
                .ForMember(uv => uv.UserId, u => u.MapFrom(us => us.Id))
                .ForMember(uv=>uv.UserRole,u=>u.MapFrom(us=>us.Roles.FirstOrDefault().RoleId));
            Mapper.CreateMap<UserView, ApplicationUser>();
            Mapper.CreateMap<Deliverable,DeliverableView>()
                .ForMember(dv=>dv.AgentId,dp=>dp.MapFrom(d=>d.ApplicationUserId))
            .ForMember(dv => dv.Status, dp => dp.MapFrom(d => Enum.GetName(typeof(DeliveryStatusEnum), d.Status == null ? DeliveryStatusEnum.UnPack : d.Status)));


        }

        public static ViewModel Get<DomainModel, ViewModel>(DomainModel models)
        {
            ViewModel viewModels = Mapper.Map<DomainModel, ViewModel>(models);
            return viewModels;
        }
    }
}