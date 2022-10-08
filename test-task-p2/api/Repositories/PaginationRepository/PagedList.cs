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
                hasPrevious = value;
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
                hasNext = value;
            }
        }

        public PagedList(List<T> items, int totalCount, int currentPageNumber, int pageSize)
        {
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = currentPageNumber;

            if (CurrentPage > 1)
            {
                HasPrevious = true;
            }
            else
            {
                HasPrevious = false;
            }

            if (CurrentPage < TotalPages)
            {
                HasNext = true;
            }
            else
            {
                HasNext = false;
            }

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
