using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetshopApp2019.UI.RestAPI.DTO
{
    public class PetDTO
    {
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string PreviousOwner { get; set; }

    }
}
