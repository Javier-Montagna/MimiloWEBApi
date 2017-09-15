using Mimilo.Interfaces;

namespace Mimilo.Models
{
    public class Product : IProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ReleaseDate { get; set; }
        public double Price { get; set; }
        public string TitleDescription { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string CoverImageUrl { get; set; }
    }
}