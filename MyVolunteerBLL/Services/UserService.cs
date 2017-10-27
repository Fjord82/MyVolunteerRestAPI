using System;
using System.Collections.Generic;
using System.Linq;
using MyVolunteerBLL.BusinessObjects;
using MyVolunteerBLL.Converters;
using MyVolunteerDAL;

namespace MyVolunteerBLL.Services
{
    public class UserService : IUserService
    {
        UserConverter conv = new UserConverter();
        DALFacade facade;
       
        public UserService(DALFacade facade)
        {
            this.facade = facade;
        }

        public UserBO Create(UserBO user)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newUser = uow.UserRepository.Create(conv.Convert(user));
                uow.Complete();
                return conv.Convert(newUser);
            }
        }

        public UserBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newUser = uow.UserRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newUser);
            }
        }

        public UserBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.UserRepository.Get(Id));
            }
        }

        public List<UserBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //return uow.UserRepository.GetAll();
                return uow.UserRepository.GetAll().Select(u => conv.Convert(u)).ToList();
            }
        }

        public UserBO Update(UserBO user)
        {
            using (var uow = facade.UnitOfWork)
            {
                var userFromDB = uow.UserRepository.Get(user.Id);
                if (userFromDB == null)
                {
                    throw new InvalidOperationException("User not found");
                }
                userFromDB.FirstName = user.FirstName;
                userFromDB.LastName = user.LastName;
                userFromDB.Email = user.Email;
                userFromDB.Address = user.Address;

                uow.Complete();
                return conv.Convert(userFromDB);
            }
        }
    }
}
