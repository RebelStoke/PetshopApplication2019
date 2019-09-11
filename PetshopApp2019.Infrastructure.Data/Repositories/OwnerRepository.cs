using PetshopApp2019.Core.DomainService;
using PetshopApp2019.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopApp2019.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository

    {
        public OwnerRepository() {
            FakeDB.InitData();
        }
        public Owner Create(Owner owner)
        {
            owner.ID = FakeDB.ownerID++;
            FakeDB.listOfOwner.Add(owner);
            return owner;
        }

        public Owner Delete(int id)
        {
            foreach (Owner owner in FakeDB.listOfOwner)
            {
                if (owner.ID == id)
                {
                    FakeDB.listOfOwner.Remove(owner);
                    return owner;
                }
            }
            return null;
        }

        public Owner ReadByID(int id)
        {
            foreach (Owner owner in FakeDB.listOfOwner)
            {
                if (owner.ID == id)
                {
                    return owner;
                }
            }
            return null;
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return FakeDB.listOfOwner;
        }

        public Owner Update(int id, Owner owner)
        {
            if (Delete(id) != null) {
                owner.ID = id;
                FakeDB.listOfOwner.Add(owner);
                return owner;
            }
            return null;
        }
    }
}
