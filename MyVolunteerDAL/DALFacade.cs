using MyVolunteerDAL.UOW;

namespace MyVolunteerDAL
{
    public class DALFacade
    {

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork();
            }
        }
    }
}
