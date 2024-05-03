using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Contract
{
    public interface IBaseRepository<T> where T : class, new()
    {
        Task<IEnumerable<T>> GetAll(params string[]?includes);
        Task<IEnumerable<T>> GetAll();
        Task<T> FindById(int id);
        Task<T> FindByName(string name);
        bool IsExist(int id);
        bool IsExist(T entity);
        Task<T> Delete(int id);
        Task<int> Delete(T entity);
        Task<T> Update(T entity);
        Task<T> Create(T entity);
        Task<IEnumerable<T>> CreateRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> UpdateRange(IEnumerable<T> entities);
        Task<int> DeleteRange(IEnumerable<T> entities);
        Task<bool> Exists(int id);
        Task<int> Count();
        Task<int> Count(Expression<Func<T, bool>> predicate);
        Task<bool> Any();
        Task<bool> Any(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefault();
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);

    }
}
