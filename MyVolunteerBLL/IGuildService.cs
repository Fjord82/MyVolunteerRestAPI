using System;
using System.Collections.Generic;
using MyVolunteerBLL.BusinessObjects;

namespace MyVolunteerBLL
{
    public interface IGuildService
    {

        //C - Create
        GuildBO Create(GuildBO guild);

        //R - Read
        List<GuildBO> GetAll();
        GuildBO Get(int Id);

        //U - Update
        GuildBO Update(GuildBO guild);

        //D - Delete
        GuildBO Delete(int Id);

    }
}
