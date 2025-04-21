using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SFUListParser.Model
{
    public class Student : INotifyPropertyChanged
    {
        private string id;
        private int position;
        private int priorityPosition;
        private int totalPoints;
        private int additionalPoints;
        private int prioriry;
        private bool isHighestPriority;

        public string ID { get => id; set { id = value; OnPropertyChanged(); } }
        public int Position { get => position; set { position = value; OnPropertyChanged(); } }
        public int PositionIndex { get => position - 1; }
        public int PriorityPosition { get => priorityPosition; set { priorityPosition = value; OnPropertyChanged(); } }
        public int TotalPoints { get => totalPoints; set { totalPoints = value; OnPropertyChanged(); } }
        public int AdditionalPoints { get => additionalPoints; set { additionalPoints = value; OnPropertyChanged(); } }
        public int Prioriry { get => prioriry; set { prioriry = value; OnPropertyChanged(); } }
        public bool IsHighestPriority { get => isHighestPriority; set { isHighestPriority = value; OnPropertyChanged(); } }

        public Student() { }

        public Student(string id)
        {
            ID = id;
        }

        public Student(string id, int position, int priorityPosition, int totalPoints, int additionalPoints, int prioriry, bool isHighestPriority) : this(id)
        {
            Position = position;
            PriorityPosition = priorityPosition;
            TotalPoints = totalPoints;
            AdditionalPoints = additionalPoints;
            Prioriry = prioriry;
            IsHighestPriority = isHighestPriority;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public override string ToString() =>
            $"{Position}\t{PriorityPosition}\t{ID}\t{AdditionalPoints}\t{TotalPoints}\t{Prioriry}\t{IsHighestPriority}";
    }
}