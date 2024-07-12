using SFUListParser.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SFUListParser.ViewModel
{
    internal class StudentViewModel : INotifyPropertyChanged
    {
        private Student student;

        public Student Student { get => student; set { student = value; OnPropertyChanged(); } }

        public StudentViewModel(Student competitionListData)
        {
            this.student = competitionListData;

            competitionListData.PropertyChanged += (sender, e) => PropertyChanged?.Invoke(sender, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}