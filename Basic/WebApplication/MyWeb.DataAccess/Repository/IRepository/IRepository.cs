using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //don't save UPDATE function in Repository

        //T - Category
        IEnumerable<T> GetAll(string? includeProperties = null); //get all T


        //Expression: like we write in FirstOrDefault
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);  //get one with id
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
