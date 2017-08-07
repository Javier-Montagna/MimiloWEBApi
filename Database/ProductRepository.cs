using Mimilo.Interfaces;
using Mimilo.Models;
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
        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}
