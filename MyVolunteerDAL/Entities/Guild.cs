using System;
namespace MyVolunteerDAL.Entities
{
    public class Guild
    {
        public int Id { get; set; }

        public string GuildName { get; set; }

        public string Description { get; set; }

        public User User { get; set; }

    }
}
