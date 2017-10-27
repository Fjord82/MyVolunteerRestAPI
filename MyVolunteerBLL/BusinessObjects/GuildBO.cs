using System;
namespace MyVolunteerBLL.BusinessObjects
{
    public class GuildBO
    {
        public int Id { get; set; }

        public string GuildName { get; set; }

        public string Description { get; set; }

        public UserBO User { get; set; }
    }
}
