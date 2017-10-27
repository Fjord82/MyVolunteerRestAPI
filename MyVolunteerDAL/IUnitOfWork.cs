using System;
namespace MyVolunteerDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IGuildRepository GuildRepository { get; }

        int Complete();
    }
}
