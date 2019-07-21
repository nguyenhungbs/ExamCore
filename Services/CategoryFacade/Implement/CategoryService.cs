using Exam.CoreData.Data.Entities;
using Exam.CoreData.Models.Categories;
using Exam.CoreData.Models.PagingInfo;
using Exam.CoreData.Repository.Common;
using Exam.Libraries.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Services.CategoryFacade.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public BaseSearchResult<CategoryModel> SearchDepartment(SearchModel search)
        {
            var result = new BaseSearchResult<CategoryModel>();
            var list = _categoryRepository.FinAllPaging(search, c => c.Id > 0, a => a.Id);

            result.Records = list.Records.CloneToListModels<Category, CategoryModel>();
            result.PageCount = list.PageCount;
            result.PageIndex = list.PageIndex;
            result.PageSize = list.PageSize;
            result.TotalRecord = list.TotalRecord;
            return result;
        }
    }
}
