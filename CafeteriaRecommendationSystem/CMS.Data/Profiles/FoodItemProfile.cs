using AutoMapper;
using CMS.Common.Models;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Profiles
{
    public class FoodItemProfile : Profile
    {
        public FoodItemProfile()
        {
            CreateMap<AddFoodItem, FoodItem>().ReverseMap();
            CreateMap<UpdateFoodItemPrice, FoodItem>().ReverseMap();
            CreateMap<UpdateFoodItemStatus, FoodItem>().ReverseMap();
            CreateMap<FoodItem, ViewFoodItem> ()
             .ForMember(dest => dest.AvailabilityStatus, opt => opt.MapFrom(src => src.FoodItemAvailabilityStatus != null ? src.FoodItemAvailabilityStatus.Name : null))
            .ForMember(dest => dest.FoodItemType, opt => opt.MapFrom(src => src.FoodItemType != null ? src.FoodItemType.Name : null))
            .ReverseMap();
            CreateMap<RecommendedItem, FoodItem>().ReverseMap();
        }
    }
}
