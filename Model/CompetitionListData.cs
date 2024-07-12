using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SFUListParser.Model
{
    public class CompetitionListData : INotifyPropertyChanged
    {
        private string name;
        private string description;
        private string link;
        private string id;

        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public string Description { get => description; set { description = value; OnPropertyChanged(); } }
        public string Link { get => link; set { link = value; OnPropertyChanged(); } }
        public string Id { get => id; set { id = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}