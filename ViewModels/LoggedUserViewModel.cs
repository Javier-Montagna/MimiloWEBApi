using Mimilo.Models;

public class LoggedUserViewModel
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public ShoppingCart shoppingCart { get; set; }
}