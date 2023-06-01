using AutoMapper;
using Ecommerce.Services.ProductAPI.Models;
using Ecommerce.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Ecommerce.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
               // config.CreateMap<Product, ProductDto>();
            });
            return mappingConfig;
        }
    }
}
