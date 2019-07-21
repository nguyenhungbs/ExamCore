using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exam.CoreData.Entities;
using Exam.CoreData.Models.Departments;
using Exam.CoreData.Models.PagingInfo;
using Exam.CoreData.Repository.Common;
using Exam.Libraries.Utils;
using Exam.Services;
using Microsoft.EntityFrameworkCore;

namespace Services.DepartmentFacade.Implement
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public BaseSearchResult<DepartmentModel> SearchDepartment(SearchModel search)
        {
            var testContext = _departmentRepository.GetDBContext();


            var re = new List<string>();
            //foreach (var item in testContext.Departments)
            //{
            //    var k = item.Description + " " + item.Name;
            //    re.Add(k);
            //    foreach (var item1 in item.Users)
            //    {
            //        var n = item1;
            //        re.Add(n.Email + " " + n.FirstName);
            //    }

            //}
            //var testU = testContext.Departments.Include(p => p.Users).Where(c => c.Id == 1);

            //using (var context = _departmentRepository.GetDBContext())
            //{
            //    var blogs = context.Departments
            //                    .Include(blog => blog.Users)
            //                    .ToList();
            //}


            var list = _departmentRepository.FinAllPaging(search, c => c.Id > 0, a => a.Id);

            return new BaseSearchResult<DepartmentModel>
            {
                Records = list.Records.CloneToListModels<Department, DepartmentModel>(),
                PageCount = list.PageCount,
                PageIndex = list.PageIndex,
                PageSize = list.PageSize,
                TotalRecord = list.TotalRecord
            };
        }

        public DepartmentModel GetInfoById(int id)
        {
            var exist = _departmentRepository.FindById(id);
            return (exist != null) ? exist.CloneToModel<Department, DepartmentModel>() : null;
        }

        public bool SaveDepartment(SaveDepartmentModel model)
        {
            var result = false;
            using (var db = _departmentRepository.GetDBContext())
            {
                if (model.Id.HasValue)
                {
                    var exist = _departmentRepository.FindById(model.Id);
                    if (exist == null) throw new ServiceException("Department not exist");
                    exist.Description = model.Description;
                    exist.Name = model.Name;
                    result = _departmentRepository.Update(exist);
                }
                else
                {
                    result = _departmentRepository.Insert(new Department
                    {
                        Description = model.Description,
                        Name = model.Name
                    });
                }
            }
            return result;
        }

        public bool DeleteOneDepartment(int id)
        {
            var exist = _departmentRepository.FindById(id);
            if (exist == null)
                throw new ServiceException("This department has id that does not exist");
            return _departmentRepository.Delete(exist);
        }

        public bool DeleteManyDepartment(DeleteManyDepartmentModel model)
        {
            var result = false;
            if (model.Ids.Count() == 0)
                throw new ServiceException("Please select at least 1 department");
            using (var context = _departmentRepository.GetDBContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in model.Ids)
                        {
                            result = _departmentRepository.Delete(new Department { Id = item });
                            if (!result)
                            {
                                trans.Rollback();
                                break;
                            }
                        }
                        if (result) trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                    }
                }
            }
            return result;
        }

    
    }
}
