using System;
using MyVolunteerBLL.BusinessObjects;
using MyVolunteerDAL.Entities;

namespace MyVolunteerBLL.Converters
{
    public class UserConverter
    {
        internal User Convert(UserBO user)
        {
            if(user == null)
            {
                return null;
            }

            return new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address
            };
        }

        internal UserBO Convert(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserBO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address
            };
        }
    }
}
