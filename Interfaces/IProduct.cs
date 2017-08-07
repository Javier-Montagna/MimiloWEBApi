namespace Mimilo.Intefaces
{
    public interface IProduct
    {
        int ProductId { get; set; }
        string ProductName { get; set; }
        string ReleaseDate { get; set; }
        double Price { get; set; }
        string TitleDescription { get; set; }
        string ShortDescription { get; set; }
        string LongDescription { get; set; }
        string CoverImageUrl { get; set; }
    }
}