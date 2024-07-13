using SFUListParser.Pages;
using SFUListParser.ViewModel;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace SFUListParser
{
    public sealed partial class MainPage : Page
    {
        private CompetitionListDataViewModel CompetitionListDataVM;

        public MainPage()
        {
            InitializeComponent();
            
            CompetitionListDataVM = CompetitionListDataViewModel.Init();\
        }

        private void MainGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(ExtendedListDataPage),
                   e.ClickedItem,
                   new SlideNavigationTransitionInfo()
                   { Effect = SlideNavigationTransitionEffect.FromBottom });
        }

        private void AddButtonClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e) =>
            Frame.Navigate(typeof(CompetitionListDataEditPage));

        private void DeleteButtonClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e) =>
            CompetitionListDataVM.CompetitionLists.Remove(CompetitionListDataVM.CompetitionLists.Last());
    }
}