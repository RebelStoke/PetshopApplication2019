using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetshopApp2019.Core.Entity;
using PetshopApp2019.Core.ApplicationService;

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
        public ActionResult<IEnumerable<Pet>> Get() {
            return _petService.GetPets();
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
            foreach (var item in _petService.GetPets().ToList()) {
                if (item.ID == pet.ID) {
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
            foreach (var item in _petService.GetPets().ToList())
            {
                if (item.ID == id)
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
