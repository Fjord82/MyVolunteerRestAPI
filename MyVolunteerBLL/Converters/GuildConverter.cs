using System;
using System.Linq;
using MyVolunteerBLL.BusinessObjects;
using MyVolunteerDAL.Entities;

namespace MyVolunteerBLL.Converters
{
    public class GuildConverter
    {

        internal Guild Convert(GuildBO guild)
        {
            if (guild == null)
            {
                return null;
            }

            return new Guild()
            {
                Id = guild.Id,
                GuildName = guild.GuildName,
                Description = guild.Description,
                Users = guild.UserIds?.Select(uID => new GuildUser()
                {
                    UserId = uID,
                    GuildId = guild.Id
                }).ToList()
            };
        }

        internal GuildBO Convert(Guild guild)
        {
            if (guild == null)
            {
                return null;
            }

            return new GuildBO()
            {
                Id = guild.Id,
                GuildName = guild.GuildName,
                Description = guild.Description,
                UserIds = guild.Users?.Select(u => u.UserId).ToList(),
                /*Users = guild.Users?.Select(u => new UserBO()
                {
                    Id = u.GuildId,
                    FirstName = u.User?.FirstName,
                    LastName = u.User?.LastName,
                    Email = u.User?.Email,
                    Address = u.User?.Address,
                    PhoneNumber = u.User?.PhoneNumber
                }).ToList()*/

            };
        }
    }
}
