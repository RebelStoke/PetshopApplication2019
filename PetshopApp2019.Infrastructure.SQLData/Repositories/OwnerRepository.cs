using Microsoft.EntityFrameworkCore;
using PetshopApp2019.Core.DomainService;
using PetshopApp2019.Core.Entity;
using PetshopApp2019.Infrastructure.SQLData;
using System.Linq;

namespace PetshopApp2019.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository

    {
        private readonly PetshopContext context;
        public OwnerRepository(PetshopContext ctx)
        {
            context = ctx;
        }
        public Owner Create(Owner owner)
        {
            context.Owners.Add(owner);
            context.SaveChanges();
            return owner;
        }

        public Owner Delete(int id)
        {
            Owner owner = ReadByID(id);
            context.Remove(owner);
            context.SaveChanges();
            return owner;
        }

        public Owner ReadByID(int id)
        {
            Owner owner = context.Owners.Find(id);
            return owner;
        }

        public FilteredList<Owner> ReadOwners(Filter filter)
        {
            FilteredList<Owner> filteredList = new FilteredList<Owner>();
            if (filter != null)
            {

                filteredList.List = context.Owners
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
            }
            else
            {
                filteredList.List = context.Owners;
            }

            filteredList.Count = filteredList.List.Count();
            return filteredList;


        }

        public Owner Update(int id, Owner owner)
        {
            context.Attach(owner).State = EntityState.Modified;
            return owner;
        }
    }
}
