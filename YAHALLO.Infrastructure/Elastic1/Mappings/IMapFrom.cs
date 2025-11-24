using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Infrastructure.Elastic1.Mappings
{
    interface IMapFrom<T>
    {
        void Mapping(Profile profile);

    }
}
