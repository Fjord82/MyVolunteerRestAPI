using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyVolunteerAppBLL;
using MyVolunteerAppBLL.BusinessObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParlanRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/values
        [HttpGet]
        public IEnumerable<UserBO> Get()
        {
            return facade.UserService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public UserBO Get(int id)
        {
            return facade.UserService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]UserBO user)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.UserService.Create(user));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserBO user)
        {
            if(id != user.Id)
            {
                return StatusCode(405, "Path id does not match User ID in json object!");
            }
            try
            {
                return Ok(facade.UserService.Update(user));
            } catch(InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.UserService.Delete(id);
        }
    }
}
