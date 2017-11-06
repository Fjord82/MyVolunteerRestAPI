using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyVolunteerBLL;
using MyVolunteerBLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyVolunteerRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/users
        [HttpGet]
        public IEnumerable<UserBO> Get()
        {
            return facade.UserService.GetAll();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = facade.UserService.Get(id);
            if(user == null)
            {
                return StatusCode(404, "User not found");
            }else
            {
                return StatusCode(200, user);
            }
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]UserBO user)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.UserService.Create(user));
        }

        // PUT api/users/5
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

        [HttpPut()]
        public IActionResult Put()
        {
                return StatusCode(405, "Error! Invalid operation due to missing parameters");
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = facade.UserService.Delete(id);
            if(user == null)
            {
                return StatusCode(404, "User not found");
            }else
            {
                return StatusCode(200, user);
            }

        }

        [HttpDelete()]
        public IActionResult Delete()
        {
            return StatusCode(405, "Error! Invalid operation due to missing parameters");
        }
    }
}
