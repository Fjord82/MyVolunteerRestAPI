using MyVolunteerDAL.Context;
using MyVolunteerDAL.Repositories;

namespace MyVolunteerDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; internal set; }
        public IGuildRepository GuildRepository { get; internal set; }

        private MyVolunteerAppContext _context;

        public UnitOfWork()
        {
            _context = new MyVolunteerAppContext();
            _context.Database.EnsureCreated();
            UserRepository = new UserRepository(_context);
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
