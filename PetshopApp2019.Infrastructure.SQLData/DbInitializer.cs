using PetshopApp2019.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopApp2019.Infrastructure.SQLData
{
    public class DbInitializer
    {
        public static void Seed(PetshopContext context)
        {
            var listOfPets = new List<Pet>();
            var listOfOwner = new List<Owner>();

            var owner1 = new Owner { FirstName = "Dude", LastName = "Son", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            var owner2 = new Owner { FirstName = "Big", LastName = "Lebowski", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            var owner3 = new Owner { FirstName = "John", LastName = "Rambo", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            var owner4 = new Owner { FirstName = "Vincent", LastName = "Vega", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            listOfOwner.Add(owner1);
            listOfOwner.Add(owner2);
            listOfOwner.Add(owner3);
            listOfOwner.Add(owner4);
            var bearPet1 = new Pet { Name = "Bear1", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "Brown", PreviousOwner = owner1, Price = 69, Type = "Bear" };
            var bearPet2 = new Pet { Name = "Bear2", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "Black", PreviousOwner = owner2, Price = 98, Type = "Bear" };
            var bearPet3 = new Pet { Name = "Bear3", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "White", PreviousOwner = owner3, Price = 102, Type = "Bear" };
            var bearPet4 = new Pet { Name = "Bear4", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "Brown", PreviousOwner = owner4, Price = 39, Type = "Bear" };
            var bearPet5 = new Pet { Name = "Bear5", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "Black", PreviousOwner = owner1, Price = 106, Type = "Bear" };
            var bearPet6 = new Pet { Name = "Bear6", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "White", PreviousOwner = owner2, Price = 78, Type = "Bear" };
            listOfPets.Add(bearPet1);
            listOfPets.Add(bearPet2);
            listOfPets.Add(bearPet3);
            listOfPets.Add(bearPet4);
            listOfPets.Add(bearPet5);
            listOfPets.Add(bearPet6);

            context.Pets.AddRange(listOfPets);
            context.Owners.AddRange(listOfOwner);
            context.SaveChanges();
        }
    }
}