using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Application.RepositoryContracts
{
    public interface IGenericRepository<T> where T : class
    {


        Task<IReadOnlyList<T>> GetAsync();

        Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize);
    }
}
