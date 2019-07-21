using Exam.CoreData.Models.Categories;
using Exam.CoreData.Models.PagingInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Services.CategoryFacade
{
    public interface ICategoryService
    {
        BaseSearchResult<CategoryModel> SearchDepartment(SearchModel search);
    }
}
