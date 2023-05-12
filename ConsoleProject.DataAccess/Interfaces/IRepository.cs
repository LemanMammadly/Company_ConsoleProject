using ConsoleProject.Core.Interfaces;

namespace ConsoleProject.DataAccess.Interfaces;

public interface IRepository<T> where T : IEntity
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    T Get(int id);
    List<T> GetAll();
}

