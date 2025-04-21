using SFUListParser.Model;
using SFUListParser.Scripts;
using SFUListParser.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.Networking.NetworkOperators;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace SFUListParser.Pages
{
    public sealed partial class ListDataPage : Page, INotifyPropertyChanged
    {
        private CompetitionListData competitionListData { get; set; }
        private ExtendedListDataViewModel extendedListDataViewModel { get; set; }

        private bool isParsed;

        private IEnumerator<Student> iterativeParse;

        public event PropertyChangedEventHandler PropertyChanged;

        public ListDataPage()
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

            //extendedListDataViewModel = ExtendedListDataViewModel.Init(competitionListData);
            //await extendedListDataViewModel.ParseTableAsync();


            _ = Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
            {
                iterativeParse = SFUHtmlListParser.ParseTableIterative(competitionListData.Link);

                while (iterativeParse.MoveNext())
                {
                    CompetitionList.Items.Add(iterativeParse.Current);
                }
            });
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

        private async void DeleteButtonClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ContentDialog contentDialog = new ContentDialog()
            {
                Name = "Подтвердить действие?",
                Title = "Удалить список",
                PrimaryButtonText = "Да",
                SecondaryButtonText = "Отменить"
            };

            var result = await contentDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                MainPageViewModel.Init().CompetitionLists.Remove(competitionListData);

                Frame.Navigate(typeof(MainPage));
            }
        }
    }
}