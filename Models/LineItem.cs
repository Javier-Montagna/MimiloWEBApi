using Mimilo.Interfaces;

namespace Mimilo.Models
{
    public class LineItem : ILineItem
    {
        public int LineItemId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}