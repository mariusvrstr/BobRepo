
// ReSharper disable CheckNamespace
namespace JBOB
// ReSharper restore CheckNamespace
{
    using Repositories;
    using Switcher;

    internal partial class DataContext : IContextSwitcher
    {

        public IUserRepository UserRepository
        {
            get
            {
                return this as IUserRepository;
            }
        }


    }
}
