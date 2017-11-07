using Mimilo.Models;

namespace  Mimilo.Interfaces
{
    public interface ILineItem
    {
        int LineItemId { get; set; }
        int Quantity { get; set; }
        Product Product { get; set; }
    }
}