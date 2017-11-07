using System.Collections.Generic;
using Mimilo.Interfaces;

namespace Mimilo.Models
{
    public class ShoppingCart : IShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public List<LineItem> LineItems { get; set; }
    }
}