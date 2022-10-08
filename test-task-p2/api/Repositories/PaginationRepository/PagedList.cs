using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories.PaginationRepository
{
    public class PagedList<T> : List<T>
    {
        private int currentPage;
        private int totalPages;
        private int pageSize;
        private int totalCount;
        private bool hasPrevious;
        private bool hasNext;
        public int CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
            }
        }
        public int TotalPages
        {
            get
            {
                return totalPages;
            }
            set
            {
                totalPages = value;
            }
        }
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value;
            }
        }
        public int TotalCount
        {
            get
            {
                return totalCount;
            }
            set
            {
                totalCount = value;
            }
        }
        public bool HasPrevious
        {
            get
            {
                return hasPrevious;
            }
            set
            {
                if (CurrentPage > 1)
                {
                    hasPrevious = true;
                }
                else
                {
                    hasPrevious = false;
                }
            }
        }
        public bool HasNext
        {
            get
            {
                return hasNext;
            }
            set
            {
                if (CurrentPage < TotalPages)
                {
                    hasNext = true;
                }
                else
                {
                    hasNext = false;
                }
            }
        }

        public PagedList(List<T> items, int totalCount, int pageSize, int currentPageNumber)
        {
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = currentPageNumber;

            this.AddRange(items);
        }

        public static PagedList<T> ToPagedList(IQueryable<T> query, int pageNumber, int pageSize)
        {
            var count = query.Count();
            var items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
