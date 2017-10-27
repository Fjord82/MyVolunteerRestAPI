using System;
using MyVolunteerDAL.Repositories;
using MyVolunteerDAL.UnitOfWork;

namespace MyVolunteerDAL
{
    public class DALFacade
    {

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork.UnitOfWork();
            }
        }
    }
}
