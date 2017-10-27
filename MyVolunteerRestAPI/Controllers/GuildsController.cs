using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyVolunteerBLL;
using MyVolunteerBLL.BusinessObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyVolunteerRestAPI.Controllers
{
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
        public GuildBO Get(int id)
        {
            return facade.GuildService.Get(id);
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

        // DELETE api/guilds/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.GuildService.Delete(id);
        }
    }
}
