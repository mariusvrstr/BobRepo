using System.Linq;
using Microsoft.Phone.Shell;
using WP8.BusinessLayer.Contracts.Gateway;

namespace WP8.BusinessLayer.Implementation.Gateway
{
    public class LiveTileGateway : ILiveTileGateway
    {

        public void UpdateLiveTile(string title, string backTitle, string mediumTileContent, string largeTileContent)
        {
            ShellTile mainTile = ShellTile.ActiveTiles.FirstOrDefault();

            if (mainTile != null)
            {
                FlipTileData tileData = new FlipTileData()
                {
                    BackContent = mediumTileContent,
                    WideBackContent = largeTileContent,
                    BackTitle = backTitle,
                    Title = title
                };

                mainTile.Update(tileData);
            }
        }
    }
}
