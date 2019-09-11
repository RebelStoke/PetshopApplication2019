using System;
using System.Collections.Generic;
using System.Text;
using PetshopApp2019.Core.Entity;

namespace PetshopApp2019.Core.DomainService
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> ReadOwners();
        Owner Create(Owner owner);
        Owner Delete(int id);
        Owner Update(int id, Owner owner);
        Owner ReadByID(int id);
    }
}
