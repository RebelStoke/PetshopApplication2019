using Microsoft.AspNetCore.Mvc;
using PetshopApp2019.Core.ApplicationService;
using PetshopApp2019.Core.Entity;
using PetshopApp2019.UI.RestAPI.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PetshopApp2019.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            Pet pet = _petService.DeletePet(id);
            if (pet == null)
            {
                return BadRequest("Wrong ID");
            }
            return pet;
        }

        [HttpGet]
        public ActionResult<List<object>> Get([FromQuery] Filter filter, [FromQuery] string sortOrder)
        {
            if (filter.CurrentPage == 0 || filter.ItemsPrPage == 0)
            {
                filter = null;
            }
            var list = _petService.GetPets(filter);

            switch (sortOrder)
            {
                case "Name":
                    list.List = list.List.OrderByDescending(s => s.Name);
                    break;

                case "Price":
                    list.List = list.List.OrderByDescending(s => s.Price);
                    break;

                case "Type":
                    list.List = list.List.OrderByDescending(s => s.Type);
                    break;

                default:
                    list.List = list.List.OrderByDescending(s => s.Id);
                    break;
            }

            var newList = new List<object>();

            if (filter == null)
            {
                foreach (var pet in list.List)
                {
                    newList.Add(
                        new
                        {
                            pet.Name,
                            pet.Id,
                            pet.Price,
                            pet.Color,
                            pet.BirthDate,
                            pet.SoldDate,
                            pet.PreviousOwner.FirstName,
                            pet.Type
                        });
                }
                var newFilteredList = new FilteredList<object>();
                newFilteredList.List = newList;
                newFilteredList.Count = list.Count;
                return Ok(newList);
            }
            var newList2 = new List<PetDTO>();
            foreach (var pet in list.List)
            {
                newList2.Add(new PetDTO()
                {
                    Name = pet.Name,
                    Id = pet.Id,
                    Price = pet.Price,
                    PreviousOwner = pet.PreviousOwner.FirstName,
                    Type = pet.Type
                });
            }
            var newFilteredList2 = new FilteredList<PetDTO>();
            newFilteredList2.List = newList2;
            newFilteredList2.Count = list.Count;
            return Ok(newFilteredList2);
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var newList = new List<object>();
            var pet = _petService.getPetByID(id);
            if (pet == null) {
                return BadRequest("Wrong ID");
            }
            object xD = new{
                Name = pet.Name,
                Id = pet.Id,
                Price = pet.Price,
                Color = pet.Color,
                BirthDate = pet.BirthDate,
                SoldDate = pet.SoldDate,
                PreviousOwner = pet.PreviousOwner.FirstName,
                Type = pet.Type
            };
            return xD;
           
        }

        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (pet.Name == "")
            {
                return BadRequest("No name provided");
            }
            foreach (var item in _petService.GetPets(null).List)
            {
                if (item.Id == pet.Id)
                {
                    return BadRequest("Wrong ID");
                }
            }
            return _petService.CreatePet(pet);
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody]PetDTO pet)
        {
            if (pet.Name == "")
            {
                return BadRequest("No name provided");
            }
            foreach (var item in _petService.GetPets(null).List)
            {
                if (item.Id == id)
                {
                    Pet pet2 = new Pet {Id = pet.Id, Type = pet.Type, Name = pet.Name, Price = pet.Price, Color = pet.Color, BirthDate = pet.BirthDate, SoldDate = pet.SoldDate};
                    return _petService.UpdatePet(id, pet2);
                }
            }
            return BadRequest("Wrong ID");
        }
    }
}