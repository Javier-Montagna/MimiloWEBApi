using Mimilo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimilo.Database
{
    public class ProductRepository : IProductRepository
    {
        private MimiloContext _context;

        public ProductRepository(MimiloContext context)
        {
            _context = context;
        }

        //Returns all products and their comments/features
        public IEnumerable<IProduct> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        
        //Returns all products and their comments/features
        public IProduct GetProductById(int Id)
        {
            return _context.Products.Where(x=> x.ProductId == Id).FirstOrDefault();
        }
    }
}
