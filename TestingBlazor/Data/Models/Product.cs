using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingBlazor.Data.Models
{
    public class Product:IDbObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IDbObject MakeNew()
        {
            throw new NotImplementedException();
        }

        public void UpdateFrom(IDbObject obj)
        {
            throw new NotImplementedException();
        }
    }
}
