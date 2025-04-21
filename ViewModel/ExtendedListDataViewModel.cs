using SFUListParser.Model;
using SFUListParser.Scripts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SFUListParser.ViewModel
{
    internal class ExtendedListDataViewModel : INotifyPropertyChanged
    {
        private static ExtendedListDataViewModel instance;
        private CompetitionListData currentListData;

        private Student selectedStudent;
        private ObservableCollection<Student> students;
        public Student SelectedStudent { get => selectedStudent; set { selectedStudent = value; OnPropertyChanged(); } }
        public ObservableCollection<Student> Students { get => students; set { students = value; OnPropertyChanged(); } }

        public static ExtendedListDataViewModel Init(CompetitionListData competitionListData)
        {
            if (instance == null)
                instance = new ExtendedListDataViewModel();

            instance.currentListData = competitionListData;

            return instance;
        }

        public async Task ParseTableAsync()
        {
            Students = new ObservableCollection<Student>(await SFUHtmlListParser.ParseTableAsync(currentListData.Link));

            SelectedStudent = Students.Where(x => x.ID == currentListData.Id).LastOrDefault();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}