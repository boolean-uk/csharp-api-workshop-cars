using workshop.wwwapi.Models;
using workshop.wwwapi.ViewModels;

namespace workshop.wwwapi.Repository
{
    public interface IRepository<T> 
    {
        Task<IEnumerable<T>> Get();
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(object id);
        Task Save();
        Task<T> GetById(int id);
    }
}
