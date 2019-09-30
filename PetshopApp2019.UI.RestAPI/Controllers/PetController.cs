using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetshopApp2019.Core.Entity;
using PetshopApp2019.Core.ApplicationService;
using PetshopApp2019.UI.RestAPI.DTO;

namespace PetshopApp2019.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        IPetService _petService;
        public PetController(IPetService petService) {
            _petService = petService;
        }

        [HttpGet]
        public ActionResult<FilteredList<PetDTO>> Get([FromQuery] Filter filter) {
            if (filter.CurrentPage == 0 || filter.ItemsPrPage == 0) {
                filter = null;
            }
            var list = _petService.GetPets(filter);
            
            var newList = new List<object>();


            if (filter == null)
            {
                foreach (var pet in list.List)
                {

                    newList.Add(
                        new
                        {
                            Name = pet.Name,
                            Id = pet.Id,
                        });
                }
                    var newFilteredList = new FilteredList<object>();
                    newFilteredList.List = newList;
                    newFilteredList.Count = list.Count;
                    return Ok(newFilteredList);
            }
            

            var newList2 = new List<PetDTO>();
            foreach (var pet in list.List) { 
                
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
        public Pet Get(int id) {
            return _petService.getPetByID(id);
        }

        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet) {
            if (pet.Name == "") {
                return BadRequest("No name provided");
            }
            foreach (var item in _petService.GetPets(null).List) {
                if (item.Id == pet.Id) {
                    return BadRequest("Wrong ID");
                }
            }
            return _petService.CreatePet(pet);
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody]Pet pet) {
            if (pet.Name == "")
            {
                return BadRequest("No name provided");
            }
            foreach (var item in _petService.GetPets(null).List)
            {
                if (item.Id == id)
                {
                    return _petService.UpdatePet(id, pet);
                }
            }
            return BadRequest("Wrong ID");

        }

        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id) {
            Pet pet = _petService.DeletePet(id);
            if (pet == null) {
                return BadRequest("Wrong ID");
            }
            return pet;
        }
        } 
    }
