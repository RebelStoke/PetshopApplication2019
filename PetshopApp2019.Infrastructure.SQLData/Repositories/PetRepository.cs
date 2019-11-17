using Microsoft.EntityFrameworkCore;
using PetshopApp2019.Core.DomainService;
using PetshopApp2019.Core.Entity;
using PetshopApp2019.Infrastructure.SQLData;
using System.Linq;

namespace PetshopApp2019.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetshopContext context;
        private readonly IOwnerRepository ownerRepo;
        public PetRepository(PetshopContext ctx, IOwnerRepository ownerRepository)
        {
            ownerRepo = ownerRepository;
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
            Pet pet = ReadByID(id);
            context.Remove(pet);
            context.SaveChanges();
            return pet;
        }

        public Pet ReadByID(int id)
        {
            return context.Pets.Include("PreviousOwner").FirstOrDefault(p => p.Id == id);
        }

        public FilteredList<Pet> ReadPets(Filter filter)
        {
            FilteredList<Pet> filteredList = new FilteredList<Pet>();

            if (filter != null)
            {

                filteredList.List = context.Pets
                .Include(x => x.PreviousOwner)
                .AsNoTracking()
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
                filteredList.Count = filteredList.List.Count();
                return filteredList;

            }
            else
            {
                filteredList.List = context.Pets
                .AsNoTracking()
                .Include("PreviousOwner");
            }

            filteredList.Count = context.Pets.Count();
            return filteredList;
        }

        public Pet Update(int id, Pet pet)
        {
            context.Attach(pet).State = EntityState.Modified;
            context.SaveChanges();
            return pet;
        }
    }
}
