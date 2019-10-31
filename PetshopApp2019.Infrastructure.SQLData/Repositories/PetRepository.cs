using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetshopApp2019.Core.DomainService;
using PetshopApp2019.Core.Entity;
using PetshopApp2019.Infrastructure.SQLData;

namespace PetshopApp2019.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        PetshopContext context;
        public PetRepository(PetshopContext ctx) {
           context = ctx;
        }
        public Pet Create(Pet pet)
        {
           context.Pets.Add(pet);
           context.SaveChanges();
           return pet;
        }

        public Pet Delete(int id)
        {
            var pet = ReadByID(id);
            context.Remove(pet);
            return pet;
        }

        public Pet ReadByID(int id)
        {
            return context.Pets.Include("PreviousOwner").FirstOrDefault(p => p.Id == id);
        }

        public FilteredList<Pet> ReadPets(Filter filter)
        {
            var filteredList = new FilteredList<Pet>();

            if (filter != null)
            {

                filteredList.List = context.Pets
                .Include("PreviousOwner")
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
                filteredList.Count = filteredList.List.Count();
                return filteredList;

            }
            else
                filteredList.List = context.Pets
                .Include("PreviousOwner");
            filteredList.Count = context.Pets.Count();
            return filteredList;
        }

        public Pet Update(int id, Pet pet)
        {
            if (Delete(id) != null) {
                context.Pets.Add(pet);
                return pet;
            }
            return null;
        }
    }
}
