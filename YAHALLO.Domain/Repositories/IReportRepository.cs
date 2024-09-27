using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Domain.Repositories
{
    public interface IReportRepository: IEFRepository<ReportEntity, ReportEntity>
    {
    }
}
