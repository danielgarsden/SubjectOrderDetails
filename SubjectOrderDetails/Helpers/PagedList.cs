using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Helpers
{
    /// <summary>
    /// Class to represent a List with methods to allow paging
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T>: List<T>
    {
        /// <summary>
        /// Represents the current page number within the data set
        /// </summary>
        public int CurrentPage { get; private set; }

        /// <summary>
        /// Represents the total number of pages within the data set
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Represents the size of each page within the data set
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Represents the number of rows in the data set
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// Is there a page before the current one
        /// </summary>
        public bool HasPrevious => (CurrentPage > 1);

        /// <summary>
        /// Is there a page after the current one
        /// </summary>
        public bool HasNext => (CurrentPage < TotalPages);

        /// <summary>
        /// Constructor for the Paged List
        /// </summary>
        /// <param name="items"></param>
        /// <param name="count"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        /// <summary>
        /// A
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
