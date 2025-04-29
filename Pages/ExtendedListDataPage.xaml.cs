using SFUListParser.Model;
using SFUListParser.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SFUListParser
{
    public sealed partial class ExtendedListDataPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Student> students = new ObservableCollection<Student>();
        private Student SelectedStudent;

        private Visibility isStudentDataLoaded = Visibility.Collapsed;
        public Visibility IsStudentDataLoaded 
        { 
            get => isStudentDataLoaded; 
            set 
            { 
                isStudentDataLoaded = value;

                OnPropertyChanged();
            }
        }

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

            extendedListDataViewModel = ExtendedListDataViewModel.Init(competitionListData);

            Task.Run(async () =>
            {
                await extendedListDataViewModel.ParseTableAsync();

                _ = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    SelectedStudent = extendedListDataViewModel.Students.Where(x => x.ID == competitionListData.Id).LastOrDefault();
                    OnPropertyChanged(nameof(SelectedStudent));

                    foreach (var item in extendedListDataViewModel.Students)
                        students.Add(item);

                    if (SelectedStudent != null)
                    {
                        StudentsListView.SelectedIndex = SelectedStudent.PositionIndex;

                        IsStudentDataLoaded = Visibility.Visible;
                    }
                });
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

        private void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}