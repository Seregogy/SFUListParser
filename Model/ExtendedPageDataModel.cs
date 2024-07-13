using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SFUListParser.Model
{
    internal class ExtendedPageDataModel : INotifyPropertyChanged
    {
        private Student selectedStudent;
        private ObservableCollection<Student> students;

        public Student SelectedStudent { get => selectedStudent; set { selectedStudent = value; OnPropertyChanged(); } }
        public ObservableCollection<Student> Students { get => students; set { students = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}