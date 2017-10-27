using System;
using System.Collections.Generic;
using System.Linq;
using MyVolunteerBLL.BusinessObjects;
using MyVolunteerBLL.Converters;
using MyVolunteerDAL;

namespace MyVolunteerBLL.Services
{
    public class GuildService : IGuildService
    {
        GuildConverter conv = new GuildConverter();
        DALFacade _facade;

        public GuildService(DALFacade facade)
        {
            _facade = facade;
        }

        public GuildBO Create(GuildBO guild)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var guildEntity = uow.GuildRepository.Create(conv.Convert(guild));
                uow.Complete();
                return conv.Convert(guildEntity);
            }

        }

        public GuildBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var guildEntity = uow.GuildRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(guildEntity);
            }
        }

        public GuildBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var guildEntity = uow.GuildRepository.Get(Id);
                return conv.Convert(guildEntity);
            }
        }

        public List<GuildBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
               return uow.GuildRepository.GetAll().Select(g => conv.Convert(g)).ToList();
            }
        }

        public GuildBO Update(GuildBO guild)
        {
            using(var uow = _facade.UnitOfWork)
            {
                var guildEntity = uow.GuildRepository.Get(guild.Id);
                if(guildEntity == null)
                {
                    throw new InvalidOperationException("Guild not found");
                }
                guildEntity.GuildName = guild.GuildName;
                guildEntity.Description = guild.Description;
                uow.Complete();
                return conv.Convert(guildEntity);
            }
        }
    }
}
