﻿using System;
namespace MyVolunteerDAL.Entities
{
    public class GuildUser
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int GuildId { get; set; }
        public Guild Guild { get; set; }
    }
}
