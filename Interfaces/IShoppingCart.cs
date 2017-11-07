using System.Collections.Generic;
using Mimilo.Models;

namespace  Mimilo.Interfaces
{
    public interface IShoppingCart
    {
        int ShoppingCartId { get; set; }
        List<LineItem> LineItems { get; set; }
    }
}