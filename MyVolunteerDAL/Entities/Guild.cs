using System;
using System.Collections.Generic;

namespace MyVolunteerDAL.Entities
{
    public class Guild
    {
        public int Id { get; set; }

        public string GuildName { get; set; }

        public string Description { get; set; }


        public List<GuildUser> Users { get; set; }

    }
}
