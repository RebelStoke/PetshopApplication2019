using PetshopApp2019.Core.DomainService;
using PetshopApp2019.Core.Entity;

namespace PetshopApp2019.Core.ApplicationService.Impl
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepository.Create(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepository.Delete(id);
        }

        public FilteredList<Owner> GetOwner(Filter filter)
        {
            return _ownerRepository.ReadOwners(filter);
        }

        public Owner getOwnerByID(int id)
        {
            return _ownerRepository.ReadByID(id);
        }

        public Owner NewOwner(string firstName, string lastName, string address, string email, string phoneNumber, int id)
        {
            return new Owner { FirstName = firstName, LastName = lastName, Address = address, Email = email, PhoneNumber = phoneNumber, Id = id };
        }

        public Owner UpdateOwner(int id, Owner owner)
        {
            return _ownerRepository.Update(id, owner);
        }
    }
}
