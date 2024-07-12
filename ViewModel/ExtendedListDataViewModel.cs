using SFUListParser.Model;
using SFUListParser.Scripts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SFUListParser.ViewModel
{
    internal class ExtendedListDataViewModel : INotifyPropertyChanged
    {
        private CompetitionListData competitionListData;

        private List<Student> students;
        private Student selectedStudent = new Student();
        public List<Student> Students { get => students; set { students = value; OnPropertyChanged("Students"); } }
        public Student SelectedStudent { get => selectedStudent; set { selectedStudent = value; OnPropertyChanged("SelectedStudent"); } }

        public ExtendedListDataViewModel(CompetitionListData competitionListData)
        {
            this.competitionListData = competitionListData;

            _ = UpdateStudentsDataAsync();
        }

        public async Task UpdateStudentsDataAsync()
        {
            Students = await SFUHtmlListParser.ParseTableAsync(competitionListData.Link);
            
            SelectedStudent = Students.Where(x => x.ID == competitionListData.Id).FirstOrDefault();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}