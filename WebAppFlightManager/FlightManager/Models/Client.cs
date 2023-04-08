using System;

namespace FlightManager.Models
{
    public class Client
    {
        public Client()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PIN { get; set; }

        public string PhoneNumber { get; set; }

        public string Nationality { get; set; }

        public string Email { get; set; }

    }
}
