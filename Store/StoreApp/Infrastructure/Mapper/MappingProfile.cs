using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace StoreApp.Infrastructure.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();//2 yönlü Mapleme işlemi için  diğerinde farklıdır
            CreateMap<UserDtoForCreation,IdentityUser>(); 
            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();
        }

    }
}
