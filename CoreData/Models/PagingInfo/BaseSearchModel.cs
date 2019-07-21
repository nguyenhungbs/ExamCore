using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.CoreData.Models.PagingInfo
{
    public class BaseSearchModel
    {
        public bool? SortDesc { get; set; }

        public string SortBy { get; set; }

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
