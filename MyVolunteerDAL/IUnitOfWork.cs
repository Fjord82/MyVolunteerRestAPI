using System;
namespace MyVolunteerDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }

        int Complete();
    }
}
