using System;
using MyVolunteerDAL.Context;
using MyVolunteerDAL.Repositories;

namespace MyVolunteerDAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; internal set; }
        public IGuildRepository GuildRepository { get; internal set; }

        private MyVolunteerAppContext _context;

        public UnitOfWork()
        {
            _context = new MyVolunteerAppContext();
            UserRepository = new UserRepositoryEFMemory(_context);
            GuildRepository = new GuildRepository(_context);
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
