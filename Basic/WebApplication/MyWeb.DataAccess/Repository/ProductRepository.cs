using Microsoft.EntityFrameworkCore;
using MyWeb.DataAccess;
using MyWeb.DataAccess.Repository.IRepository;
using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            Product? product = _db.Products.FirstOrDefault(u => u.ProductID == obj.ProductID);

            if(product != null)
            {
                product.ProductName = obj.ProductName;
                product.Description= obj.Description;
                product.ListPrice = obj.ListPrice;
                product.Price = obj.Price;
                product.Price50 = obj.Price50;
                product.Price100 = obj.Price100;
                product.CategoryID = obj.CategoryID;

                if (!string.IsNullOrEmpty(obj.ImageUrl))
                {
                    product.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
