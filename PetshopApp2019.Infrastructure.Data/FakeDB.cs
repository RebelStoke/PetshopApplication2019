using PetshopApp2019.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopApp2019.Infrastructure.Data
{
    static class FakeDB
    {
        static public Boolean dataInit = false;
        static public int petID = 1;
        static public int ownerID = 1;
        static public List<Pet> listOfPets = new List<Pet>();
        static public List<Owner> listOfOwner = new List<Owner>();
        static public void InitData() {
            if (dataInit) {
                return;
            }
            var owner1 = new Owner { Id = ownerID++, FirstName = "Dude", LastName = "Son", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            var owner2 = new Owner { Id = ownerID++, FirstName = "Big", LastName = "Lebowski", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            var owner3 = new Owner { Id = ownerID++, FirstName = "John", LastName = "Rambo", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            var owner4 = new Owner { Id = ownerID++, FirstName = "Vincent", LastName = "Vega", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            listOfOwner.Add(owner1);
            listOfOwner.Add(owner2);
            listOfOwner.Add(owner3);
            listOfOwner.Add(owner4);
            var bearPet1 = new Pet { Id = petID++, Name = "Bear1", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "Brown", PreviousOwner = owner1, Price = 69, Type = "Bear"};
            var bearPet2 = new Pet { Id = petID++, Name = "Bear2", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "Black", PreviousOwner = owner2, Price = 98, Type = "Bear" };
            var bearPet3 = new Pet { Id = petID++, Name = "Bear3", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "White", PreviousOwner = owner3, Price = 102, Type = "Bear" };
            var bearPet4 = new Pet { Id = petID++, Name = "Bear4", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "Brown", PreviousOwner = owner4, Price = 39, Type = "Bear" };
            var bearPet5 = new Pet { Id = petID++, Name = "Bear5", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "Black", PreviousOwner = owner1, Price = 106, Type = "Bear" };
            var bearPet6 = new Pet { Id = petID++, Name = "Bear6", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "White", PreviousOwner = owner2, Price = 78, Type = "Bear" };
            listOfPets.Add(bearPet1);
            listOfPets.Add(bearPet2);
            listOfPets.Add(bearPet3);
            listOfPets.Add(bearPet4);
            listOfPets.Add(bearPet5);
            listOfPets.Add(bearPet6);

            dataInit = true;
        }
    }
}
