using AgroVision.Dal.Entities;
using AgroVision.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVision.Api.Mappers.Profiles
{
    public class UserCalculationProfile: Profile
    {
        public UserCalculationProfile()
        {
            CreateMap<UserCalculation, UserCalculationModel>().ReverseMap();

        }
    }
}
