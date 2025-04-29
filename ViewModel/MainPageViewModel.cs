using Newtonsoft.Json;
using SFUListParser.Model;
using SFUListParser.Scripts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SFUListParser.ViewModel
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        private static MainPageViewModel instance;

        public ObservableCollection<CompetitionListData> CompetitionLists { get; set; }

        private SaveDataHandler saveDataHandler;

        public event PropertyChangedEventHandler PropertyChanged;

        public static MainPageViewModel Init()
        {
            if (instance == null)
            {
                instance = new MainPageViewModel();
            }

            return instance;
        }

        private MainPageViewModel()
        {
            _ = InitCtor();
        }

        private async Task InitCtor()
        {
            saveDataHandler = SaveDataHandler.Init();
            CompetitionLists = JsonConvert.DeserializeObject<ObservableCollection<CompetitionListData>>(await saveDataHandler.LoadDataAsync());
            
            Debug.WriteLine("Deserialized");

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CompetitionLists)));

            CompetitionLists.CollectionChanged += async (sender, e) => await saveDataHandler.SaveData(JsonConvert.SerializeObject(CompetitionLists, Formatting.Indented));
        }
    }
}