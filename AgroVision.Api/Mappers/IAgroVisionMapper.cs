using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVision.Api.Mappers
{
    public interface IAgroVisionMapper<out T>
    {
        T CreateMapper();
    }
}
