using Microsoft.AspNetCore.Identity;

namespace CustomerSupplier.CrossCutting.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
