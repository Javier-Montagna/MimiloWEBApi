using Microsoft.AspNetCore.Identity;
using Mimilo.Interfaces;

namespace Mimilo.Models
{
    public class MimiloUser : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}