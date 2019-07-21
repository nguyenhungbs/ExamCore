using Exam.CoreData.Models.Departments;
using Exam.CoreData.Models.PagingInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DepartmentFacade
{
    public interface IDepartmentService
    {
        BaseSearchResult<DepartmentModel> SearchDepartment(SearchModel search);

        DepartmentModel GetInfoById(int id);

        bool SaveDepartment(SaveDepartmentModel model);

        bool DeleteOneDepartment(int id);

        bool DeleteManyDepartment(DeleteManyDepartmentModel model);
        
    }
}
