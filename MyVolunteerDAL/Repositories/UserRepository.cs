using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyVolunteerDAL.Context;
using MyVolunteerDAL.Entities;

namespace MyVolunteerDAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        MyVolunteerAppContext _context;

        public UserRepository(MyVolunteerAppContext context)
        {
            _context = context;
        }
       
        public User Create(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public User Delete(int Id)
        {
            var user = Get(Id);
            _context.Users.Remove(user);
            return user;
        }

        public User Get(int Id)
        {
            return _context.Users.FirstOrDefault(xUser => xUser.Id == Id);
        }

        public List<User> GetAll()
        {
            return _context.Users
                           .Include(u => u.Guilds)
                           .ThenInclude(gu => gu.Guild)
                           .ToList();
        }

    }
}
