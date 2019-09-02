using PetshopApp2019.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopApp2019.Infrastructure.Data
{
    static class FakeDB
    {
        static public int id = 1;
        static public List<Pet> listOfPets = new List<Pet>();
        static public void InitData() {
            var bearPet1 = new Pet { ID = id++, Name = "Bear1", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "Brown", PreviousOwner = "Nedas", Price = 69, Type = "Bear"};
            var bearPet2 = new Pet { ID = id++, Name = "Bear2", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "Black", PreviousOwner = "Szymon", Price = 98, Type = "Bear" };
            var bearPet3 = new Pet { ID = id++, Name = "Bear3", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "White", PreviousOwner = "Mate", Price = 102, Type = "Bear" };
            var bearPet4 = new Pet { ID = id++, Name = "Bear4", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "Brown", PreviousOwner = "Greg", Price = 39, Type = "Bear" };
            var bearPet5 = new Pet { ID = id++, Name = "Bear5", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "Black", PreviousOwner = "Me", Price = 106, Type = "Bear" };
            var bearPet6 = new Pet { ID = id++, Name = "Bear6", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "White", PreviousOwner = "Nedas", Price = 78, Type = "Bear" };
            listOfPets.Add(bearPet1);
            listOfPets.Add(bearPet2);
            listOfPets.Add(bearPet3);
            listOfPets.Add(bearPet4);
            listOfPets.Add(bearPet5);
            listOfPets.Add(bearPet6);
        }
    }
}
