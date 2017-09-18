using Microsoft.AspNetCore.Identity;

namespace Mimilo.Models
{
    public class MimiloRole : IdentityRole
    {
        public string Description { get; set; }
    }
}