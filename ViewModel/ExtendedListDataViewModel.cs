using SFUListParser.Model;
using SFUListParser.Scripts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace SFUListParser.ViewModel
{
    internal class ExtendedListDataViewModel : INotifyPropertyChanged
    {
        private static ExtendedListDataViewModel instance;
        private CompetitionListData currentListData;

        private Student selectedStudent;
        private ObservableCollection<Student> students = new ObservableCollection<Student>();
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
            Students = new ObservableCollection<Student>(await SFUHtmlListParser.ParseTableAsync(currentListData.Link, currentListData.ParseLimit));

            //try
            //{
            //    SelectedStudent = Students.Where(x => x.ID == currentListData.Id).LastOrDefault();
            //}
            //catch (System.Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //    Debug.WriteLine(ex.StackTrace);
            //}
        }

        public async Task ParseTableIterable()
        {
            Students.Clear();

            var result = await SFUHtmlListParser.ParseTableAsync(currentListData.Link);

            foreach (var student in result)
            {
                Thread.Sleep(100);
                Debug.WriteLine(student.ID);
                Students.Add(student);
            }

            SelectedStudent = Students.Where(x => x.ID == currentListData.Id).LastOrDefault();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}