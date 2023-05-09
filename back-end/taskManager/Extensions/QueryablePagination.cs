using System.Runtime.CompilerServices;

namespace task_manager.Extensions
{
    public static class QueryablePagination
    {

        public static IQueryable<T> Pagination<T>(this IQueryable<T> query, int pageNumber, int pageSize) 
        {
        
            return query.Skip((pageNumber - 1)*pageSize).Take(pageSize);

        }
    }
}
