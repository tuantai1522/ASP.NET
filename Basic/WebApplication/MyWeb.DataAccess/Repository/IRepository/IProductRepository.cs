using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.DataAccess.Repository.IRepository
{
    //will have all methods from IRepository and we can add methods which only have in this Repository
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
