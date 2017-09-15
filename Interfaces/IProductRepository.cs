using System.Collections.Generic;
using Mimilo.Models;

namespace Mimilo.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<IProduct> GetAllProducts();
        IProduct GetProductById(int Id);
    }
}