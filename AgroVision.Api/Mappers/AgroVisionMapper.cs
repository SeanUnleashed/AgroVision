using AgroVision.Api.Mappers.Profiles;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVision.Api.Mappers
{
    public class AgroVisionMapper : IAgroVisionMapper<IMapper>
    {
        public IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserCalculationProfile>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
