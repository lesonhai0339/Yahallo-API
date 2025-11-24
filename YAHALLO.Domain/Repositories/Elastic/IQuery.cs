using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Repositories.Elastic
{
    public interface IQuery<TSearch>
    {
        void Apply(object queryContext);
    }
}
