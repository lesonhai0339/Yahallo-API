using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.BlogQuery
{
    public class BlogDto : IMapFrom<BlogEntity>
    {



        public BlogDto Create()
        {
            return new BlogDto();
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BlogEntity, BlogDto>();   
        }
    }
}
