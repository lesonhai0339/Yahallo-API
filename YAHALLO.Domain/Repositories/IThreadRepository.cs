using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.Reference;

namespace YAHALLO.Domain.Repositories
{
    public interface IThreadRepository: IEFRepository<ThreadEntity, ThreadEntity>
    {
    }
}
