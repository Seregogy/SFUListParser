using SFUListParser.Model;
using SFUListParser.ViewModel;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SFUListParser.Pages
{
    public sealed partial class CompetitionListDataEditPage : Page, INotifyPropertyChanged
    {
        private CompetitionListData currentCompetitionList = new CompetitionListData(null, null, null, null, -1);

        private MainPageViewModel CompetitionListDataVM;

        public event PropertyChangedEventHandler PropertyChanged;
        private bool canCreate;
        public bool CanCreate
        {
            get => canCreate;
            set
            {
                canCreate = value;

                OnPropertyChanged();
            }
        }

        public CompetitionListDataEditPage()
        {
            InitializeComponent();

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += CompetitionListDataEditPage_BackRequested;
            CompetitionListDataVM = MainPageViewModel.Init();
        }


        private void CompetitionListDataEditPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();

                e.Handled = true;
            }
        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine((currentCompetitionList.Name, currentCompetitionList.Id));

            if (currentCompetitionList.Name == null || currentCompetitionList.Link == null)
            {
                ValidationErrorInfoBar.IsOpen = true;

                return;
            }

            CompetitionListDataVM.CompetitionLists.Add(currentCompetitionList);

            Frame.Navigate(typeof(MainPage));
        }

        private void OnPropertyChanged([CallerMemberName] string property = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
