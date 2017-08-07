using System.Collections.Generic;
using Mimilo.Models;

namespace Mimilo.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
    }
}