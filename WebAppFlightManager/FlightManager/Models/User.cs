namespace FlightManager.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PIN { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }
    }
}
