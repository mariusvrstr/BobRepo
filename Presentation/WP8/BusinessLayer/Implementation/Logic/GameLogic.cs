using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP8.BusinessLayer.Contracts.Gateway;
using WP8.BusinessLayer.Contracts.Logic;
using WP8.Resources;

namespace WP8.BusinessLayer.Implementation.Logic
{
    public class GameLogic : IGameLogic
    {
        private readonly ILiveTileGateway liveTileGateway;

        public GameLogic(ILiveTileGateway liveTileGateway)
        {
            this.liveTileGateway = liveTileGateway;
        }

        public void UpdateScores()
        {
            //Missing logic, but would probably reading scores from the service
            //Once you the scores, do something with it, like return it or update the tiles
            liveTileGateway.UpdateLiveTile(AppResources.LiveTileExampleTitle,
                AppResources.LiveTileExampleBackTitle,
                AppResources.LiveTileExampleMediumTileContent,
                AppResources.LiveTileExampleLargeTileContent);
        }
    }
}
