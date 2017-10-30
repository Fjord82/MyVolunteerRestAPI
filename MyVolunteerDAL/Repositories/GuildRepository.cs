using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyVolunteerDAL.Context;
using MyVolunteerDAL.Entities;

namespace MyVolunteerDAL.Repositories
{
    public class GuildRepository : IGuildRepository
    {
        MyVolunteerAppContext _context;
        public GuildRepository(MyVolunteerAppContext context)
        {
            _context = context;
        }

        public Guild Create(Guild guild)
        {
            /* if(guild.User != null)
             {
                 _context.Entry(guild.User).State =
                             EntityState.Unchanged;
             }*/
            _context.Guilds.Add(guild);
            return guild;
        }

        public Guild Delete(int Id)
        {
            var guild = Get(Id);
            _context.Guilds.Remove(guild);
            return guild;
        }

        public Guild Get(int Id)
        {
            return _context.Guilds
                           .Include(g => g.Users)
                           .FirstOrDefault(g => g.Id == Id);
        }

        public List<Guild> GetAll()
        {
            return _context.Guilds
                           .Include(g => g.Users)
                           .ToList();
        }

        public IEnumerable<Guild> GetAllById(List<int> ids)
        {
            if (ids == null) return null;

            return _context.Guilds.Where(g => ids.Contains(g.Id));
        }
    }
}
