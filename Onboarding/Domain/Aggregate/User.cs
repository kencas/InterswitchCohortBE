using Microsoft.AspNetCore.Identity;

namespace Domain.Aggregate
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        
    }
}
