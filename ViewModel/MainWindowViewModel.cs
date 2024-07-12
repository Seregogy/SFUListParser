using SFUListParser.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SFUListParser.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CompetitionListData> competitionListDatas;

        public ObservableCollection<CompetitionListData> CompetitionListDatas
        {
            get
            {
                //OnPropertyChanged("CompetitionListDatas");
                return competitionListDatas;
            }
            set
            {
                competitionListDatas = value;
                OnPropertyChanged("CompetitionListDatas");
            }
        }

        public MainWindowViewModel()
        {
            /*competitionListDatas = new ObservableCollection<Student>
            {
                new Student()
                {
                    Snils="159-857-355 35",
                    Position = 59,
                    TotalPoints = 255,
                    PriorityPosition = 11,
                    AdditionalPoints = 0,
                    Prioriry = 1,
                    IsHighestPriority = true
                },
                new Student()
                {
                    Snils = "159-857-355 35",
                    Position = 67,
                    TotalPoints = 255,
                    PriorityPosition = 12,
                    AdditionalPoints = 0,
                    Prioriry = 2,
                    IsHighestPriority = true
                },
                new Student()
                {
                    Snils = "159-857-355 35",
                    Position = 48,
                    TotalPoints = 260,
                    PriorityPosition = 8,
                    AdditionalPoints = 5,
                    Prioriry = 3,
                    IsHighestPriority = true
                }
            };*/

            competitionListDatas = new ObservableCollection<CompetitionListData>()
            {
                new CompetitionListData()
                {
                    Name = "ФИиИТ",
                    Description = "Фундаментальная информатика и информационные технологии",
                    Link = "https://sfedu.ru/abitur/list/02.03.02_%D0%9C%D0%9C_%D0%A4%D1%83%D0%BD%D0%B4%D0%B0%D0%BC%D0%B5%D0%BD%D1%82%D0%B0%D0%BB%D1%8C%D0%BD%D0%B0%D1%8F%20%D0%B8%D0%BD%D1%84%D0%BE%D1%80%D0%BC%D0%B0%D1%82%D0%B8%D0%BA%D0%B0%20%D0%B8%20%D0%B8%D0%BD%D1%84%D0%BE%D1%80%D0%BC%D0%B0%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D1%82%D0%B5%D1%85%D0%BD%D0%BE%D0%BB%D0%BE%D0%B3%D0%B8%D0%B8.%20%D0%A4%D1%83%D0%BD%D0%B4%D0%B0%D0%BC%D0%B5%D0%BD%D1%82%D0%B0%D0%BB%D1%8C%D0%BD%D0%B0%D1%8F%20%D0%B8%D0%BD%D1%84%D0%BE%D1%80%D0%BC%D0%B0%D1%82%D0%B8%D0%BA%D0%B0%20%D0%B8%20%D0%B8%D0%BD%D1%84%D0%BE%D1%80%D0%BC%D0%B0%D1%86%D0%B8%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D1%82%D0%B5%D1%85%D0%BD%D0%BE%D0%BB%D0%BE%D0%B3%D0%B8%D0%B8_%D0%9E%D0%9E_%D0%93%D0%91",
                    Id = "159-857-355 35"
                },
                new CompetitionListData()
                {
                    Name = "ПМиИ",
                    Description = "Прикладная математика и информатика",
                    Link = "https://sfedu.ru/abitur/list/01.03.02_%D0%9C%D0%9C_%D0%9F%D1%80%D0%B8%D0%BA%D0%BB%D0%B0%D0%B4%D0%BD%D0%B0%D1%8F%20%D0%BC%D0%B0%D1%82%D0%B5%D0%BC%D0%B0%D1%82%D0%B8%D0%BA%D0%B0%20%D0%B8%20%D0%B8%D0%BD%D1%84%D0%BE%D1%80%D0%BC%D0%B0%D1%82%D0%B8%D0%BA%D0%B0.%20%D0%9C%D0%B0%D1%82%D0%B5%D0%BC%D0%B0%D1%82%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%BE%D0%B5%20%D0%BC%D0%BE%D0%B4%D0%B5%D0%BB%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5%20%D0%B8%20%D0%B8%D1%81%D0%BA%D1%83%D1%81%D1%81%D1%82%D0%B2%D0%B5%D0%BD%D0%BD%D1%8B%D0%B9%20%D0%B8%D0%BD%D1%82%D0%B5%D0%BB%D0%BB%D0%B5%D0%BA%D1%82_%D0%9E%D0%9E_%D0%93%D0%91",
                    Id = "159-857-355 35"
                },
                new CompetitionListData()
                {
                    Name = "ПИ",
                    Description = "Прикладная информатика (Современные технологии разработки приложений)",
                    Link = "https://sfedu.ru/abitur/list/09.03.03_%D0%92%D0%A2_%D0%9F%D1%80%D0%B8%D0%BA%D0%BB%D0%B0%D0%B4%D0%BD%D0%B0%D1%8F%20%D0%B8%D0%BD%D1%84%D0%BE%D1%80%D0%BC%D0%B0%D1%82%D0%B8%D0%BA%D0%B0.%20%D0%A1%D0%BE%D0%B2%D1%80%D0%B5%D0%BC%D0%B5%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BC%D0%B5%D1%82%D0%BE%D0%B4%D1%8B%20%D1%80%D0%B0%D0%B7%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%BA%D0%B8%20%D0%BF%D1%80%D0%B8%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%B8%D0%B9_%D0%9E%D0%9E_%D0%93%D0%91",
                    Id = "159-857-355 35"
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
