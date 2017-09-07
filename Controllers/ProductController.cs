using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mimilo.Intefaces;
using Mimilo.Interfaces;
using Mimilo.Models;

namespace Mimilo.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetProducts")]
        public IEnumerable<IProduct> GetProducts()
        {
            return _repository.GetAllProducts();
        }

        [HttpGet("GetProductById")]
        public IProduct GetProductById(int Id)
        {
            return _repository.GetProductById(Id);
        }
    }
}
