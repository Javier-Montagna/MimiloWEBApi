namespace Mimilo.Interfaces
{
    public interface IMimiloUser
    {
        int MimiloUserId { get; set; }
        string Name { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}