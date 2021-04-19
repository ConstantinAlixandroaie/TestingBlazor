using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingBlazor.Data.Models;
using TestingBlazor.ViewModels;

namespace TestingBlazor.Data.Acces.Repositories
{
    public abstract class Repository<T, U> : IRepository<T, U>
        where T : class, IDbObject
        where U : class, IUIObject
    {
        protected TestingBlazorContext _ctx;
        public Repository(TestingBlazorContext ctx)
        {
            _ctx = ctx;
        }
        public abstract Task<T> Add(U item);

        public abstract Task<IEnumerable<U>> Get(bool asNoTracking = false);

        public abstract Task<U> GetById(int id, bool asNoTracking = false);
        public abstract Task<bool> Remove(U item);
        public abstract Task<T> RemoveById(int id);

        public abstract Task<bool> Update(int id, U newData);

    }
}
