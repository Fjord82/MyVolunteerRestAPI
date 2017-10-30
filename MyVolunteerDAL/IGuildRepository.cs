using System;
using System.Collections.Generic;
using MyVolunteerDAL.Entities;

namespace MyVolunteerDAL
{
    public interface IGuildRepository
    {
        //C - Create
        Guild Create(Guild guild);

        //R - Read
        List<Guild> GetAll();
        IEnumerable<Guild> GetAllById(List<int> ids);

        Guild Get(int Id);

        //U - Update
        //No update for Repository, it will be a task for the Unit of Work

        //D - Delete
        Guild Delete(int Id);
    }
}
