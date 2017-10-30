using System.Collections.Generic;
using System.Linq;
using MyVolunteerDAL.Entities;

namespace MyVolunteerDAL.Repositories
{
    public class UserRepositoryFakeDB : IUserRepository
    {
       
        #region FakeDB
        private static int Id = 1;
        private static List<User> Users = new List<User>();
        #endregion

        public User Create(User user)
        {
            User newUser;
            Users.Add(newUser = new User()
            {
                Id = Id++,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address
            });
            return newUser;
        }

        public User Delete(int Id)
        {
            var user = Get(Id);
            Users.Remove(user);
            return user;
        }

        public User Get(int Id)
        {
            return Users.FirstOrDefault(xUser => xUser.Id == Id);
        }

        public List<User> GetAll()
        {
            //Returning a copy of the real list from DB - Securing valuable data by wrapping it
            return new List<User>(Users);
        }

        public IEnumerable<User> GetAllById(List<int> ids)
        {
            throw new System.NotImplementedException();
        }
    }
}
