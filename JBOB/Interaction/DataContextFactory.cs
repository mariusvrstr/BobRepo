
namespace JBOB.Interaction
{
    using Switcher;

    public static class DataContextFactory
    {
        public static IContextSwitcher CreateContext()
        {
            return new DataContext();;
        }
    }
}
