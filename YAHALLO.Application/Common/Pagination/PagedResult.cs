using YAHALLO.Application.Queries.UserQuery;

namespace YAHALLO.Application.Common.Pagination
{
    public class PagedResult<T>
    {
        public PagedResult()
        {
            Data = null!;
        }

        public static PagedResult<T> Create(
            int totalCount,
            int pageCount,
            int pageSize,
            int pageNumber,
            IEnumerable<T> data)
        {
            return new PagedResult<T>
            {
                TotalCount = totalCount,
                PageCount = pageCount,
                PageSize = pageSize,
                PageNumber = pageNumber,
                Data = data,
            };
        }

        //internal static PagedResult<UserDto> Create(int totalCount, int pageCount, int pageSize, int pageNumber, List<UserDto> data)
        //{
        //    throw new NotImplementedException();
        //}

        public int TotalCount { get; set; }

        public int PageCount { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public IEnumerable<T> Data { get; set; }

    }
}
