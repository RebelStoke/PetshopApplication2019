using PetshopApp2019.Core.DomainService;
using PetshopApp2019.Core.Entity;
using PetshopApp2019.Infrastructure.SQLData;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PetshopApp2019.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository

    {
        PetshopContext context;
        public OwnerRepository(PetshopContext ctx) {
            context = ctx;
        }
        public Owner Create(Owner owner)
        {
            context.Owners.Add(owner);
            return owner;
        }

        public Owner Delete(int id)
        {
            var owner = ReadByID(id);
            context.Remove(owner);
            return owner;
        }

        public Owner ReadByID(int id)
        {
            var owner = context.Owners.Find(id);
            return owner;
        }

        public FilteredList<Owner> ReadOwners(Filter filter)
        {
            var filteredList = new FilteredList<Owner>();
            if (filter != null)
            {

                filteredList.List = context.Owners
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
            }
            else
                filteredList.List = context.Owners;
            filteredList.Count = filteredList.List.Count();
            return filteredList;

            
        }

        public Owner Update(int id, Owner owner)
        {
            if (Delete(id) != null) {
                owner.Id = id;
                context.Owners.Add(owner);
                return owner;
            }
            return null;
        }
    }
}
