using System.Collections.Generic;

namespace PetshopApp2019.Core.Entity
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}
