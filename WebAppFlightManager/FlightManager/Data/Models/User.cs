namespace FlightManager.Data.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PIN { get; set; }

        public string Addres { get; set; }

        public int PhoneNumber { get; set; }

        public string Role { get; set; }

    }
}
