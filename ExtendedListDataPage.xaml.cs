using SFUListParser.Model;
using SFUListParser.ViewModel;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SFUListParser
{
    public sealed partial class ExtendedListDataPage : Page
    {
        private CompetitionListData competitionListData { get; set; }
        private ExtendedListDataViewModel extendedListDataViewModel { get; set; }

        public ExtendedListDataPage()
        {
            InitializeComponent();

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
            Content.PointerPressed += Page_PointerPressed;

            competitionListData = e.Parameter as CompetitionListData;
            extendedListDataViewModel = new ExtendedListDataViewModel(competitionListData);
        }
        
        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }

        private void Page_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {            
            if (e.GetCurrentPoint(Frame).Properties.IsXButton1Pressed)
                Frame.GoBack();
        }
    }
}