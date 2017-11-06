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
    public class GuildsController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/guilds
        [HttpGet]
        public IEnumerable<GuildBO> Get()
        {
            return facade.GuildService.GetAll();
        }

        // GET api/guilds/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var guild = facade.GuildService.Get(id);
            if(guild == null)
            {
                return StatusCode(404, "Guild not found");
            }
            else
            {
                return StatusCode(200, guild);
            }
        }

        // POST api/guilds
        [HttpPost]
        public IActionResult Post([FromBody]GuildBO guild)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.GuildService.Create(guild));
        }

        // PUT api/guilds/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]GuildBO guild)
        {
            if(id != guild.Id)
            {
                return BadRequest("Path Id does not match Guild Id in json object");
            }
            try
            {
                var guildUpdated = facade.GuildService.Update(guild);
                return Ok(guildUpdated);
            }
            catch(InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPut()]
        public IActionResult Put()
        {
            return StatusCode(405, "Error! Invalid operation due to missing parameters");
        }

        // DELETE api/guilds/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var guild = facade.GuildService.Delete(id);
            if (guild == null)
            {
                return StatusCode(404, "Guild not found");
            }
            else
            {
                return StatusCode(200, guild);
            }
        }

        [HttpDelete()]
        public IActionResult Delete()
        {
            return StatusCode(405, "Error! Invalid operation due to missing parameters");
        }
    }
}
