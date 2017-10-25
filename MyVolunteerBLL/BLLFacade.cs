using System;
using MyVolunteerBLL.Services;
using MyVolunteerDAL;

namespace MyVolunteerBLL
{
    public class BLLFacade
    {
        public IUserService UserService
        {
            get { return new UserService(new DALFacade()); }
        }
    }
}
