using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.DataAccess.Repository.IRepository
{
    //In UnitOfWork, we can access to all repository that we want
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }

        void Save(); //save is used for all 
    }
}
