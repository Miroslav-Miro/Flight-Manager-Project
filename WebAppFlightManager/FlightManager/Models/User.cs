namespace FlightManager.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PIN { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
    }
}
