using SFUListParser.Model;
using SFUListParser.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SFUListParser.Pages
{
    public sealed partial class CompetitionListDataEditPage : Page
    {
        private CompetitionListData currentCompetitionList = new CompetitionListData("", "", "", "");

        private MainPageViewModel CompetitionListDataVM;

        public CompetitionListDataEditPage()
        {
            InitializeComponent();

            CompetitionListDataVM = MainPageViewModel.Init();
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            CompetitionListDataVM.CompetitionLists.Add(currentCompetitionList);
        
            Frame.Navigate(typeof(MainPage));
        }
    }
}
