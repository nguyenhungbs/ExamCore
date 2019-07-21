using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.CoreData.Models.PagingInfo
{
    public class BaseSearchResult<R> where R : class
    {
        public List<R> Records { get; set; }

        public int TotalRecord { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }
    }
}
