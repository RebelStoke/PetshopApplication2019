using PetshopApp2019.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetshopApp2019.Infrastructure.SQLData
{
    public class DbInitializer
    {
        public static void Seed(PetshopContext context)
        {
            List<Pet> listOfPets = new List<Pet>();
            List<Owner> listOfOwner = new List<Owner>();

            Owner owner1 = new Owner { FirstName = "Dude", LastName = "Son", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            Owner owner2 = new Owner { FirstName = "Big", LastName = "Lebowski", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            Owner owner3 = new Owner { FirstName = "John", LastName = "Rambo", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            Owner owner4 = new Owner { FirstName = "Vincent", LastName = "Vega", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            listOfOwner.Add(owner1);
            listOfOwner.Add(owner2);
            listOfOwner.Add(owner3);
            listOfOwner.Add(owner4);
            Pet frogPet1 = new Pet { Name = "Frog1", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#6b8a82", PreviousOwner = owner1, Price = 69, Type = "Frog" };
            Pet frogPet2 = new Pet { Name = "Frog2", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#a27c27", PreviousOwner = owner2, Price = 98, Type = "Frog" };
            Pet frogPet3 = new Pet { Name = "Frog3", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#9E799D", PreviousOwner = owner3, Price = 102, Type = "Frog" };
            Pet frogPet4 = new Pet { Name = "Frog4", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#6b8a82", PreviousOwner = owner4, Price = 39, Type = "Frog" };
            Pet frogPet5 = new Pet { Name = "Frog5", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#a27c27", PreviousOwner = owner1, Price = 106, Type = "Frog" };
            Pet frogPet6 = new Pet { Name = "Frog6", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#9E799D", PreviousOwner = owner2, Price = 78, Type = "Frog" };
            listOfPets.Add(frogPet1);
            listOfPets.Add(frogPet2);
            listOfPets.Add(frogPet3);
            listOfPets.Add(frogPet4);
            listOfPets.Add(frogPet5);
            listOfPets.Add(frogPet6);
            Pet crowPet1 = new Pet { Name = "Crow1", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#6b8a82", PreviousOwner = owner1, Price = 69, Type = "Crow" };
            Pet crowPet2 = new Pet { Name = "Crow2", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#a27c27", PreviousOwner = owner2, Price = 98, Type = "Crow" };
            Pet crowPet3 = new Pet { Name = "Crow3", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#9E799D", PreviousOwner = owner3, Price = 102, Type = "Crow" };
            Pet crowPet4 = new Pet { Name = "Crow4", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#6b8a82", PreviousOwner = owner4, Price = 39, Type = "Crow" };
            Pet crowPet5 = new Pet { Name = "Crow5", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#a27c27", PreviousOwner = owner1, Price = 106, Type = "Crow" };
            Pet crowPet6 = new Pet { Name = "Crow6", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#9E799D", PreviousOwner = owner2, Price = 78, Type = "Crow" };
            listOfPets.Add(crowPet1);
            listOfPets.Add(crowPet2);
            listOfPets.Add(crowPet3);
            listOfPets.Add(crowPet4);
            listOfPets.Add(crowPet5);
            listOfPets.Add(crowPet6);
            Pet otterPet1 = new Pet { Name = "Otter1", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#6b8a82", PreviousOwner = owner1, Price = 69, Type = "Otter" };
            Pet otterPet2 = new Pet { Name = "Otter2", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#a27c27", PreviousOwner = owner2, Price = 98, Type = "Otter" };
            Pet otterPet3 = new Pet { Name = "Otter3", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#9E799D", PreviousOwner = owner3, Price = 102, Type = "Otter" };
            Pet otterPet4 = new Pet { Name = "Otter4", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#6b8a82", PreviousOwner = owner4, Price = 39, Type = "Otter" };
            Pet otterPet5 = new Pet { Name = "Otter5", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#a27c27", PreviousOwner = owner1, Price = 106, Type = "Otter" };
            Pet otterPet6 = new Pet { Name = "Otter6", BirthDate = DateTime.Now, SoldDate = DateTime.Now, Color = "#9E799D", PreviousOwner = owner2, Price = 78, Type = "Otter" };
            listOfPets.Add(otterPet1);
            listOfPets.Add(otterPet2);
            listOfPets.Add(otterPet3);
            listOfPets.Add(otterPet4);
            listOfPets.Add(otterPet5);
            listOfPets.Add(otterPet6);

            context.Pets.AddRange(listOfPets);
            context.SaveChanges();
        }
    }
}