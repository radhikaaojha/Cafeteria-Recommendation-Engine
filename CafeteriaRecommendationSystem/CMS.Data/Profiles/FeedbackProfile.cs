using AutoMapper;
using CMS.Common.Models;
using CMS.Data.Entities;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Profiles
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile() {
            CreateMap<FoodItemFeedback, Feedback>().ReverseMap();
            CreateMap<DetailedFoodItemFeedback, DetailedFeedback>().ReverseMap();
            CreateMap<FoodItemFeedback, FoodReview>()
                .ForMember(dest => dest.ReviewText, opt => opt.MapFrom(src => src.Comment))
                .ForMember(dest => dest.FoodItemId, opt => opt.MapFrom(src => src.FoodItemId))
                .ReverseMap();
        }
    }
}
