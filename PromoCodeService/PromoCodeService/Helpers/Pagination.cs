using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeService.Helpers
{
	public class Pagination<T> : List<T>
	{
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int ItemIndex { get; } = 0;
        public int ItemsLeft { get; } = 0;
        public int TotalItems { get; } = 0;
        public Pagination(List<T> items, int count, int pageIndex, int pageSize)
        {
            TotalItems = count;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(TotalItems / (double)PageSize);

            AddRange(items);

            if (items.Count > 0)
            {
                ItemIndex = PageSize * (PageIndex - 1);
                ItemsLeft = Math.Max(TotalItems - ItemIndex - items.Count, 0);
            }
        }

        public bool HasPreviousPage
        {
            get => PageIndex > 1;
        }

        public bool HasNextPage
        {
            get => PageIndex < TotalPages;
        }

        public static async Task<Pagination<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Pagination<T>(items, count, pageIndex, pageSize);
        }
    }
}
