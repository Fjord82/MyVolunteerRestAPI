using System;
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
                User = new UserConverter().Convert(guild.User)
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
                User = new UserConverter().Convert(guild.User)
            };
        }
    }
}
