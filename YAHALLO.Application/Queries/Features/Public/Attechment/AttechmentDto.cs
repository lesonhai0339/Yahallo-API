using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities.Reference;

namespace YAHALLO.Application.Queries.Features.Public.Attechment
{
    public class AttechmentDto : IMapFrom<AttachmentEntity>
    {


        public AttechmentDto Create()
        {
            return new AttechmentDto();
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AttachmentEntity, AttechmentDto>();   
        }
    }
}
