using Exam.CoreData.Models.PagingInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Exam.CoreData.Repository.Common.Implement
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ExamDBContext _examDBContext;

        public Repository(ExamDBContext examDBContext)
        {
            _examDBContext = examDBContext;
        }

        public ExamDBContext GetDBContext()
        {
            return _examDBContext;
        }

        public T FindById(object id)
        {
            return _examDBContext.Set<T>().Find(id);
        }

        public T FirstOrDefault()
        {
            return _examDBContext.Set<T>().FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return _examDBContext.Set<T>().FirstOrDefault(expression);
        }

        public T SingleOrDefault()
        {
            return _examDBContext.Set<T>().SingleOrDefault();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> expression)
        {
            return _examDBContext.Set<T>().SingleOrDefault(expression);
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _examDBContext.Set<T>().Any(expression);
        }

        public IEnumerable<T> FindAll()
        {
            return _examDBContext.Set<T>().ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression)
        {
            return _examDBContext.Set<T>().Where(expression).ToList();
        }

        public BaseSearchResult<T> FinAllPaging(SearchModel search, Expression<Func<T, bool>> expression,
            Expression<Func<T, object>> orderBy)
        {
            var result = new BaseSearchResult<T>();
            var list = new List<T>();
            if (!search.SortDesc.HasValue)
            {
                list = _examDBContext.Set<T>().Where(expression).ToList();
            }
            else
            {
                if (search.SortDesc.Value)
                    list = _examDBContext.Set<T>().Where(expression).OrderByDescending(orderBy).ToList();
                else
                    list = _examDBContext.Set<T>().Where(expression).OrderBy(orderBy).ToList();
            }

            result.Records = list.Skip(search.PageSize * (search.PageIndex - 1)).Take(search.PageSize).ToList();
            result.TotalRecord = list.Count();
            result.PageIndex = search.PageIndex;
            result.PageSize = search.PageSize;
            result.PageCount = result.TotalRecord / result.PageSize + (result.TotalRecord % result.PageSize > 0 ? 1 : 0);
            return result;
        }

        public bool Insert(T entity)
        {
            _examDBContext.Set<T>().Add(entity);
            return SaveChange();
        }

        public bool Update(T entity)
        {
            _examDBContext.Set<T>().Update(entity);
            return SaveChange();
        }

        public bool Delete(T entity)
        {
            _examDBContext.Attach(entity);
            _examDBContext.Set<T>().Remove(entity);
            return SaveChange();
        }

        public bool SaveChange()
        {
            return _examDBContext.SaveChanges() > 0 ? true : false;
        }


    }
}
