using Exam.CoreData.Models.PagingInfo;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.CoreData.Repository.Common
{
    public interface IRepository<T> where T : class, new()
    {
        ExamDBContext GetDBContext();

        T FindById(object id);

        T FirstOrDefault();

        T FirstOrDefault(Expression<Func<T, bool>> expression);

        T SingleOrDefault();

        T SingleOrDefault(Expression<Func<T, bool>> expression);

        bool Any(Expression<Func<T, bool>> expression);

        IEnumerable<T> FindAll();

        IEnumerable<T> FindAll(Expression<Func<T, bool>> expression);

        BaseSearchResult<T> FinAllPaging(SearchModel search, Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderBy);

        bool Insert(T entity);

        bool Update(T entity);

        bool Delete(T entity);
    }
}
