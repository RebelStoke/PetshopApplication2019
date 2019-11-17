using Microsoft.AspNetCore.Mvc;
using PetshopApp2019.Core.ApplicationService;
using PetshopApp2019.Core.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PetshopApp2019.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

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
            FilteredList<Pet> list = _petService.GetPets(filter);

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

            return Ok(list.List);
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            Pet pet = _petService.getPetByID(id);
            if (pet == null)
            {
                return BadRequest("Wrong ID");
            }
            return pet;

        }

        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (pet.Name == "")
            {
                return BadRequest("No name provided");
            }
            foreach (Pet item in _petService.GetPets(null).List)
            {
                if (item.Id == pet.Id)
                {
                    return BadRequest("Wrong ID");
                }
            }
            return _petService.CreatePet(pet);
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody]Pet pet)
        {
            if (pet.Name == "")
            {
                return BadRequest("No name provided");
            }
            foreach (Pet item in _petService.GetPets(null).List)
            {
                if (item.Id == id)
                {
                    return _petService.UpdatePet(id, pet);
                }
            }
            return BadRequest("Wrong ID");
        }
    }
}