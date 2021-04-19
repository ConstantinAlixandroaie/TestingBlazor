using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingBlazor.Data.Models;
using TestingBlazor.ViewModels;

namespace TestingBlazor.Data.Acces.Repositories
{
    public interface IRepository<T, U>
      where T : IDbObject
      where U : IUIObject
    {
        Task<IEnumerable<U>> Get(bool asNoTracking = false);
        Task<U> GetById(int id, bool asNoTracking = false);
        Task<T> Add(U item);
        Task<bool> Remove(U item);
        Task<T> RemoveById(int id);
        Task<bool> Update(int id, U newData);
    }
}
