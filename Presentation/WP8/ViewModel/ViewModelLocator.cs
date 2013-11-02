namespace WP8.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in 
    /// the application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel
        {
            get
            {
                return ContainerService.Get<MainViewModel>();
            }
        }

        public DepotViewModel DepotViewModel
        {
            get
            {
                return ContainerService.Get<DepotViewModel>();
            }
        }

        public ProfileViewModel ProfileViewModel
        {
            get
            {
                return ContainerService.Get<ProfileViewModel>();
            }
        }

        public ScoreboardViewModel ScoreboardViewModel
        {
            get
            {
                return ContainerService.Get<ScoreboardViewModel>();
            }
        }

        public ViewCardViewModel ViewCardViewModel
        {
            get
            {
                return ContainerService.Get<ViewCardViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}