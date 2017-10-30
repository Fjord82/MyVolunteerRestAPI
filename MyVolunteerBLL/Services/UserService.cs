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
        GuildConverter gConv = new GuildConverter();
        DALFacade _facade;

        public UserService(DALFacade facade)
        {
            _facade = facade;
        }

        public UserBO Create(UserBO user)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newUser = uow.UserRepository.Create(conv.Convert(user));
                uow.Complete();
                return conv.Convert(newUser);
            }
        }

        public UserBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newUser = uow.UserRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newUser);
            }
        }

        public UserBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var user = conv.Convert(uow.UserRepository.Get(Id));

                /*if(user.GuildIds != null)
                {
                    user.Guilds = user.GuildIds
                        .Select(id => gConv.Convert(uow.GuildRepository.Get(id)))
                        .ToList();
                }*/

                user.Guilds = uow.GuildRepository.GetAllById(user.GuildIds)
                    .Select(g => gConv.Convert(g))
                    .ToList();

                return user;
            }
        }

        public List<UserBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                //return uow.UserRepository.GetAll();
                return uow.UserRepository.GetAll().Select(u => conv.Convert(u)).ToList();
            }
        }

        public UserBO Update(UserBO user)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var userFromDB = uow.UserRepository.Get(user.Id);
                if (userFromDB == null)
                {
                    throw new InvalidOperationException("User not found");
                }

                var userUpdated = conv.Convert(user);

                userFromDB.FirstName = userUpdated.FirstName;
                userFromDB.LastName = userUpdated.LastName;
                userFromDB.Email = userUpdated.Email;
                userFromDB.Address = userUpdated.Address;

                userFromDB.Guilds.RemoveAll(
                    gu => !userUpdated.Guilds.Exists(
                        g => g.GuildId == gu.GuildId &&
                        g.UserId == gu.UserId));

                userUpdated.Guilds.RemoveAll(
                    gu => userFromDB.Guilds.Exists(
                        g => g.GuildId == gu.GuildId &&
                        g.UserId == gu.UserId));

                userFromDB.Guilds.AddRange(
                    userUpdated.Guilds);


                uow.Complete();
                return conv.Convert(userFromDB);
            }
        }
    }
}
