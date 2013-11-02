using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP8.BusinessLayer.Contracts.Gateway
{
    public interface ILiveTileGateway
    {
        void UpdateLiveTile(string title, string backTitle, string mediumTileContent, string largeTileContent);
    }
}
