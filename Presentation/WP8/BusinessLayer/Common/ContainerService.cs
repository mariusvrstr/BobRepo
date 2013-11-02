using Ninject;
using WP8.BusinessLayer.Contracts.Gateway;
using WP8.BusinessLayer.Contracts.Logic;
using WP8.BusinessLayer.Implementation.Gateway;
using WP8.BusinessLayer.Implementation.Logic;
using WP8.ViewModel;

public static class ContainerService
{
    private static readonly IKernel kernel = new StandardKernel();

    public static void Initialize()
    {
        kernel.Bind<ILiveTileGateway>().To<LiveTileGateway>();
        kernel.Bind<ICardGateway>().To<CardGateway>();
        kernel.Bind<IDepotLogic>().To<DepotLogic>();
        kernel.Bind<IGameLogic>().To<GameLogic>();

        kernel.Bind<MainViewModel>().ToSelf().InSingletonScope();
        kernel.Bind<DepotViewModel>().ToSelf();
        kernel.Bind<ScoreboardViewModel>().ToSelf();
        kernel.Bind<ProfileViewModel>().ToSelf();
    }

    public static T Get<T>()
    {
        return kernel.Get<T>();
    }
}