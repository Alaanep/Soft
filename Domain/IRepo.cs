using System.Reflection.Metadata;
namespace ABC.Domain
{
    public interface IRepo<T> : IBaseRepo<T> where T: UniqueEntity{}
    public interface IBaseRepo<T> where T: UniqueEntity
    {
        //crud
        bool Add(T obj);
        T Get(string id);
        List<T> Get();
        bool Update(T obj);
        bool Delete(string id);

        Task<bool> AddAsync(T obj);
        Task<T> GetAsync(string id);
        Task<List<T>> GetAsync();
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(string id);
    }
}
