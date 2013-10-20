
namespace JBOB.Switcher
{
    using Repositories;

    public interface IContextSwitcher : IGlobalContext
    {
        IUserRepository UserRepository { get; }
    }
}
