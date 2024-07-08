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
            CreateMap<FoodItemPriceUpdate, FoodItem>().ReverseMap();
            CreateMap<FoodItemStatusUpdate, FoodItem>().ReverseMap();
            CreateMap<ViewFoodItem, FoodItem>().ReverseMap();
            CreateMap<RecommendedItem, FoodItem>().ReverseMap();
        } 
    }
}
