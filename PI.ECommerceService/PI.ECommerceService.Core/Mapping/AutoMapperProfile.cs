using System;
using System.Globalization;
using AutoMapper;
using Mongo = PI.ECommerceService.Models.MongoDB;
using Product = PI.ECommerceService.Models.DTO.Product;

namespace PI.ECommerceService.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Mongo.ManufactureDetails, Product.ManufactureDetailsDTO>();
            this.CreateMap<Mongo.Pricing, Product.PricingDTO>();
            this.CreateMap<Mongo.Rating, Product.RatingDTO>();
            this.CreateMap<Mongo.Products, Product.ProductDTO>();
        }
    }
}
