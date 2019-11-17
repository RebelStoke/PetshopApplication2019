using PetshopApp2019.Core.Entity;

namespace PetshopApp2019.Core.ApplicationService
{
    public interface IOwnerService
    {

        FilteredList<Owner> GetOwner(Filter filter);
        Owner getOwnerByID(int id);
        Owner NewOwner(string firstName, string lastName, string address, string email, string phoneNumber, int id);
        Owner CreateOwner(Owner owner);
        Owner DeleteOwner(int id);
        Owner UpdateOwner(int id, Owner owner);

    }
}
