using System;
using MyVolunteerDAL.Context;
using MyVolunteerDAL.Repositories;

namespace MyVolunteerDAL.UnitOfWork
{
    public class UnitOfWorkMemory : IUnitOfWork
    {
        public IUserRepository UserRepository { get; internal set; }

        private InMemoryContext _context;

        public UnitOfWorkMemory()
        {
            _context = new InMemoryContext();
            UserRepository = new UserRepositoryEFMemory(_context);
        }

        public int Complete()
        {
            //The number of objects written to the underlying DB
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
