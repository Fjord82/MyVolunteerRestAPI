using System;
using System.Collections.Generic;
using System.Linq;
using MyVolunteerBLL.BusinessObjects;
using MyVolunteerBLL.Converters;
using MyVolunteerDAL;
using MyVolunteerDAL.Entities;

namespace MyVolunteerBLL.Services
{
    public class GuildService : IGuildService
    {
        GuildConverter conv = new GuildConverter();
        UserConverter uConv = new UserConverter();
        DALFacade _facade;

        public GuildService(DALFacade facade)
        {
            _facade = facade;
        }

        public GuildBO Create(GuildBO guild)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var guildEnt = conv.Convert(guild);
                var guildEntity = uow.GuildRepository.Create(guildEnt);
                uow.Complete();
                return conv.Convert(guildEntity);
            }

        }

        public GuildBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var guildEntity = uow.GuildRepository.Get(Id);
                if (guildEntity != null)
                {
                    guildEntity = uow.GuildRepository.Delete(Id);
                }
                uow.Complete();
                return conv.Convert(guildEntity);
            }
        }

        public GuildBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var guildEntity = conv.Convert(uow.GuildRepository.Get(Id));

                /*if(guildEntity.UserIds != null)
                {
                    guildEntity.Users = guildEntity.UserIds
                        .Select(id => uConv.Convert(uow.UserRepository.Get(id)))
                        .ToList();
                }*/
                if (guildEntity != null)
                {
                    guildEntity.Users = uow.UserRepository.GetAllById(guildEntity.UserIds)
                        .Select(u => uConv.Convert(u))
                        .ToList();
                }
                return guildEntity;
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
            using (var uow = _facade.UnitOfWork)
            {
                var guildFromDB = uow.GuildRepository.Get(guild.Id);
                if (guildFromDB == null)
                {
                    throw new InvalidOperationException("Guild not found");
                }

                var guildUpdated = conv.Convert(guild);
                guildFromDB.GuildName = guildUpdated.GuildName;
                guildFromDB.Description = guildUpdated.Description;

                if (guildUpdated.Users != null)
                {
                    guildFromDB.Users.RemoveAll(
                        gu => !guildUpdated.Users.Exists(
                            u => u.UserId == gu.UserId &&
                            u.GuildId == gu.GuildId));

                    guildUpdated.Users.RemoveAll(
                        gu => guildFromDB.Users.Exists(
                            u => u.UserId == gu.UserId &&
                            u.GuildId == gu.GuildId));

                    guildFromDB.Users.AddRange(
                        guildUpdated.Users);
                }

                uow.Complete();

                return conv.Convert(guildFromDB);
            }
        }
    }
}
