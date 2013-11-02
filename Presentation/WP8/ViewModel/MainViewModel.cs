using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Phone.Shell;
using WP8.BusinessLayer.Contracts.Logic;
using WP8.Resources;

namespace WP8.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ApplicationBar applicationBar;
        private const string ApplicationBarPropertyName = "MainApplicationBar";

        public enum ChildViewModelDisplayOrder
        {
            Intro = 0,
            Depot = 1,
            Scoreboard = 2,
            Profile = 3
        }

        public MainViewModel(IGameLogic gameLogic)
        {
            LoadedCommand = new RelayCommand(() => OnLoaded());
            PanoramaSelectedIndexChangedCommand = new RelayCommand<int>(PanoramaSelectedIndexChangedExecute);
            GameLogic = gameLogic;
            PanoramaSelectedIndexChangedExecute((int)ChildViewModelDisplayOrder.Intro);
        }

        private void PanoramaSelectedIndexChangedExecute(int selectedIndex)
        {
            MainApplicationBar = new ApplicationBar()
            {
                Mode = ApplicationBarMode.Minimized,
                Opacity = 0.7
            };

            ApplicationBarMenuItem appBarHelpMenuItem = new ApplicationBarMenuItem("Help");
            MainApplicationBar.MenuItems.Add(appBarHelpMenuItem);

            ApplicationBarMenuItem appBarFeedbackMenuItem = new ApplicationBarMenuItem("Feedback...");
            MainApplicationBar.MenuItems.Add(appBarFeedbackMenuItem);

            switch ((ChildViewModelDisplayOrder)selectedIndex)
            {
                case ChildViewModelDisplayOrder.Intro: break;
                case ChildViewModelDisplayOrder.Depot: break;
                case ChildViewModelDisplayOrder.Scoreboard: break;
                case ChildViewModelDisplayOrder.Profile:
                    MainApplicationBar.Mode = ApplicationBarMode.Default;
                    ApplicationBarIconButton editContextButton = new ApplicationBarIconButton()
                    {
                        IconUri = new Uri("/Assets/AppBar/edit.png", UriKind.Relative),
                        Text = "edit"
                    };
                    MainApplicationBar.Buttons.Add(editContextButton);
                    break;
            }
        }

        public ICommand LoadedCommand
        {
            get;
            private set;
        }

        public RelayCommand<int> PanoramaSelectedIndexChangedCommand
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

        public ApplicationBar MainApplicationBar
        {
            get
            {
                return applicationBar;
            }
            set
            {
                if (applicationBar != value)
                {
                    applicationBar = value;
                    RaisePropertyChanged(ApplicationBarPropertyName);
                }
            }
        }
    }
}