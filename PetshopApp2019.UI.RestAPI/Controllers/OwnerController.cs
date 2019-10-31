using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PetshopApp2019.Core.ApplicationService;
using PetshopApp2019.Core.Entity;
using PetshopApp2019.UI.RestAPI.DTO;

namespace PetshopApp2019.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public ActionResult<FilteredList<Owner>> Get([FromQuery] Filter filter)
        {
            if(filter.CurrentPage == 0 || filter.ItemsPrPage == 0){
                filter = null;
            }
            var filteredList = _ownerService.GetOwner(filter);
            if (filter == null)
            {
                var newList = new List<OwnerDTO>();
                foreach (var owner in filteredList.List)
                {
                    newList.Add(new OwnerDTO()
                    {
                        Id = owner.Id,
                        FirstName = owner.FirstName,
                        LastName = owner.LastName,
                        PhoneNumber = owner.PhoneNumber
                    });

                }
                return Ok(newList);
            }
            else {
                var newList2 = new List<object>();
                foreach (var owner in filteredList.List) {
                    newList2.Add(
                        new {
                            Id = owner.Id,
                            FirstName = owner.FirstName,
                            LastName = owner.LastName,
                            PhoneNumber = owner.PhoneNumber,
                            Email = owner.Email,
                            Address = owner.Address,
                            Pets = owner.Pets
                        });
                }
                return Ok(newList2);
            }
                
            

            
        }
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
            return _ownerService.getOwnerByID(id);
        }
        [HttpPost]
        public void Post([FromBody] Owner owner)
        {
            _ownerService.CreateOwner(owner);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Owner owner)
        {
            _ownerService.UpdateOwner(id, owner);

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ownerService.DeleteOwner(id);
        }
    }
}

