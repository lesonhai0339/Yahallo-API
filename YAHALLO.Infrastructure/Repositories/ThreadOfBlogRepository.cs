﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Repositories
{
    public class ThreadOfBlogRepository : RepositoryBase<ThreadOfBlogEntity, ThreadOfBlogEntity, ApplicationDbContext>, IThreadOfBlogRepository
    {
        public ThreadOfBlogRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
