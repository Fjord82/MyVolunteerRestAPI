using System;
using System.Collections.Generic;

namespace MyVolunteerBLL.BusinessObjects
{
    public class GuildBO
    {
        public int Id { get; set; }

        public string GuildName { get; set; }

        public string Description { get; set; }


        public List<int> UserIds { get; set; }
        public List<UserBO> Users { get; set; }
    }
}
