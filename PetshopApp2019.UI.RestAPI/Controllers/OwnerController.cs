using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PetshopApp2019.Core.ApplicationService;
using PetshopApp2019.Core.Entity;

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
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetOwner();
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

