using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities.Reference;

namespace YAHALLO.Application.Queries.AttechmentQuery
{
    public class AttechmentDto : IMapFrom<AttechmentEntity>
    {


        public AttechmentDto Create()
        {
            return new AttechmentDto();
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AttechmentEntity, AttechmentDto>();   
        }
    }
}
