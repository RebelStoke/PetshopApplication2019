using Microsoft.Extensions.DependencyInjection;
using PetshopApp2019.Core.ApplicationService;
using PetshopApp2019.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetshopApp2019.UI.Application
{
    class Printer: IPrinter
    {
        IPetService _petService;
        public Printer(IPetService petService)
        {
            _petService = petService;
        }

        public void PrintUI()
        {
            string[] menuItems = {
                "Show list of all Pets",
                "Search Pets by Type",
                "Create a new Pet",
                "Delete Pet",
                "Update a Pet",
                "Sort Pets By Price",
                "Get 5 cheapest available Pets",
                "Exit"
            };
            int number = ShowMenu(menuItems);
            while (number != 8)
            {
                switch (number)
                { 
                    case 1:
                        List<Pet> pets = _petService.GetPets();
                        ListPets(pets);
                        break;
                    case 2:
                        Console.WriteLine("Give the type: ");
                        string type = Console.ReadLine();
                        ListPets(_petService.GetPetsByType(type));
                        break;
                    case 3:
                        CreatePet();
                        break;
                    case 4:
                        DeletePet();
                        break;
                    case 5:
                        UpdatePet();
                        break;
                    case 6:
                        List <Pet>  petsByPrice = _petService.sortPetsByPrice();
                        ListPets(petsByPrice);
                        break;
                    case 7:
                        List < Pet > cheapestPets = _petService.get5CheapestPets();
                        ListPets(cheapestPets);
                        break;
                    case 8:
                        Environment.Exit(1);
                        break;
                    default:
                        break;
                }
                number = ShowMenu(menuItems);
            }
        }
        int ShowMenu(string[] menuItems) {
            for (int i = 0; i < menuItems.Length; i++) {
                Console.WriteLine(i + 1 + ": " + menuItems[i]);
            }
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 8)
            {
                Console.WriteLine("Please select a number between 1-8");
            }
            return selection;

        }
        void UpdatePet() {
            Console.WriteLine("Give ID of the pet you want to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Pet petByID = _petService.getPetByID(id);
            if (petByID == null)
            {
                Console.WriteLine("There is no pet with ID like that: ");
            }
            else {
                if (_petService.UpdatePet(id, CreatePet()) != null)
                {
                    Console.WriteLine("Pet successfully updated.");
                }
                else
                    _petService.CreatePet(petByID);
                    Console.WriteLine("There was error during pet update!");
            }

        }
        Pet CreatePet()
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Type: ");
            var type = Console.ReadLine();
            Console.WriteLine("BirthDate: ");
            var birthDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("SoldDate: ");
            var soldDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Color: ");
            var color = Console.ReadLine();
            Console.WriteLine("PreviousOwner: ");
            var previousOwner = new Owner() { FirstName = Console.ReadLine()};
            Console.WriteLine("Price: ");
            var price = Convert.ToDouble(Console.ReadLine());
            var pet = _petService.NewPet(type, name, birthDate, soldDate, color, previousOwner, price);
            return _petService.CreatePet(pet);

        }
        void DeletePet() {
            Console.WriteLine("Give ID of the pet: ");
            _petService.DeletePet(Convert.ToInt32(Console.ReadLine()));
        }
        void ListPets(List<Pet> pets)
        {
                Console.WriteLine("\nList of Pets");
                foreach (var pet in pets)
                {
                    Console.WriteLine($"Id: {pet.ID} " +
                                    $" | Name: {pet.Name}" +
                                    $" | PreviousOwner: {pet.PreviousOwner} " +
                                    $" | Price: {pet.Price}" +
                                    $" | SoldDate {pet.BirthDate}" +
                                    $" | SoldDate {pet.SoldDate}" +
                                    $" | Type: {pet.Type}"
                                    );
                }
                Console.WriteLine("\n");
            }
    }
}
