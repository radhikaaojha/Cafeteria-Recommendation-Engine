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
    public class WeeklyMenuProfile : Profile
    {
        public WeeklyMenuProfile() { 
            CreateMap<WeeklyMenu, SelectedFoodItem>().ReverseMap();
            CreateMap<WeeklyMenu, FoodItemVotingStats>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FoodItem.Name))
            .ForMember(dest => dest.MealType, opt => opt.MapFrom(src => src.MealType.Name))
          .ReverseMap();
        }
    }
}
