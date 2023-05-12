using System.Collections.Generic;
using ConsoleProject.Core.Interfaces;

namespace ConsoleProject.DataAccess.Interfaces;

public interface IRepository<T> where T : IEntity
{
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
    T? Get(int id);
    List<T> GetAll();
}

