using System;
using System.Collections.Generic;
using System.Text;

namespace AgroVision.Common.Exceptions
{
    public class ResourceNotFoundException: Exception
    {
        public ResourceNotFoundException(string entity)
        {
            Entity = entity;
        }

        public string Entity { get; }
    }
}
