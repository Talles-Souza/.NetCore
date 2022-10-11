using Azure;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public static class PagedBaseResponseHelper
    {
        public static async Task<TResponse> GetResponseAsync<TResponse, T>(IQueryable<T> query,
            PagedBaseRequest request) where TResponse : PagedBaseResponse<T>, new()
        {
            var response = new TResponse();
            var count = query.Count();
            response.TotalPages = (int)Math.Abs((double)count / request.PageSize);
            response.TotalRegisters = count;
            if (string.IsNullOrEmpty(request.OrderByProperty))
                response.Data = await query.ToListAsync();
            else response.Data = query.OrderBy(request.OrderByProperty).Skip((request.Page - 1) * request.PageSize)
                    .Take(request.PageSize).ToList();
            return response;
        }

        private static IEnumerable<T> OrderBy<T>(this IEnumerable<T> query, string propertyName)
        {
            return query.OrderBy(x => x.GetType().GetProperty(propertyName).GetValue(x, null));
        }
    }

    
}
