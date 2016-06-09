using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T t);
        T Update(int id, T t);
        void Delete(int id);
    }
}