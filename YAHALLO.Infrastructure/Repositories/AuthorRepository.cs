using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace YAHALLO.Infrastructure.Repositories
{
    public class AuthorRepository : RepositoryBase<AuthorEntity, AuthorEntity, ApplicationDbContext>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        //public Func<IQueryable<AuthorEntity>, IQueryable<AuthorEntity>> IQueryableHandler(object request)
        //{
        //    Func<IQueryable<AuthorEntity>, IQueryable<AuthorEntity>> handler = query =>
        //    {
        //        query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
        //        PropertyInfo[] propeties = request.GetType().GetProperties();
        //        foreach (PropertyInfo prop in propeties)
        //        {
        //            var propetyValue = prop.GetValue(request, null);
        //            if (propetyValue != null)
        //            {
        //                var domainProperty = typeof(AuthorEntity).GetProperty(prop.Name);
        //                if (domainProperty != null)
        //                {
        //                    var parameter = Expression.Parameter(typeof(AuthorEntity), "x");
        //                    var property = Expression.Property(parameter, domainProperty); // Truy cập thuộc tính
        //                    var constant = Expression.Constant(propetyValue); // Tạo hằng số
        //                    var equal = Expression.Equal(property, constant); // Tạo biểu thức so sánh bằng
        //                    var lambda = Expression.Lambda<Func<AuthorEntity, bool>>(equal, parameter); // Tạo biểu thức lambda
        //                    query = query.Where(lambda); // Sử dụng biểu thức lambda trong phương thức Where
        //                }
        //                else
        //                {
        //                    continue;
        //                }
        //            }
        //        }
        //        return query;
        //    };
        //    return handler;
        //}
        //public Expression<Func<AuthorEntity, bool>>? IExpression(PropertyInfo pro, object value)
        //{
        //    var domainProperty = typeof(AuthorEntity).GetProperty(pro.Name);
        //    if (domainProperty != null)
        //    {
        //        var parameter = Expression.Parameter(typeof(AuthorEntity), "x");
        //        var property = Expression.Property(parameter, domainProperty);
        //        var constant = Expression.Constant(value);
        //        var equal = Expression.Equal(property, constant);
        //        var lambda = Expression.Lambda<Func<AuthorEntity, bool>>(equal, parameter);
        //        return lambda;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
