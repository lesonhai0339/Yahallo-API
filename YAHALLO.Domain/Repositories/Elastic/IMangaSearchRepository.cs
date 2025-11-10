using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Domain.Repositories.Elastic
{
    public interface IMangaSearchRepository
    {
        Task<MangaEntity> Search(string name, CancellationToken token = default);
        Task Add(MangaEntity entity, CancellationToken token = default);
    }
}
