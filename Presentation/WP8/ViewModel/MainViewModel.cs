using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Phone.Shell;
using WP8.BusinessLayer.Contracts.Logic;

namespace WP8.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IGameLogic gameLogic)
        {
            LoadedCommand = new RelayCommand(() => OnLoaded());
            GameLogic = gameLogic;
        }

        public ICommand LoadedCommand
        {
            get;
            private set;
        }

        public IGameLogic GameLogic { get; private set; }

        private void OnLoaded()
        {
            doUpdateFlipTile();
        }

        private void doUpdateFlipTile()
        {
            GameLogic.UpdateScores();
        }
    }
}