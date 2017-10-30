using System;
using System.Linq;
using MyVolunteerBLL.BusinessObjects;
using MyVolunteerDAL.Entities;

namespace MyVolunteerBLL.Converters
{
    public class UserConverter
    {

        internal User Convert(UserBO user)
        {
            if(user == null)
            {
                return null;
            }

            return new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Guilds = user.GuildIds?.Select(gID => new GuildUser(){
                    GuildId = gID,
                    UserId = user.Id
                }).ToList()
            };
        }

        internal UserBO Convert(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserBO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                GuildIds = user.Guilds?.Select(g => g.GuildId).ToList(),
                /*Guilds = user.Guilds?.Select(g => new GuildBO(){
                    Id = g.UserId,
                    GuildName = g.Guild?.GuildName,
                    Description = g.Guild?.Description
                }).ToList()*/              
            };
        }
    }
}
