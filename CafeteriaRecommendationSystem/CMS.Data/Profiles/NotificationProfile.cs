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
    public class NotificationProfile : Profile
    {
        public NotificationProfile() {
            CreateMap<AddNotification, Notification>().ReverseMap();
        }

    }
}
