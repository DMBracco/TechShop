using Microsoft.AspNetCore.Identity;

namespace TechShop.Data.Entities
{
    public class User : IdentityUser
    {
        public int? Year { get; set; }
    }
}
