using Microsoft.AspNetCore.Identity;

namespace CAVWAApp.Models
{
    public class ApplicationUserMod : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  string StreetAddress { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }


    }
}
