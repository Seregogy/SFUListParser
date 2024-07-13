using System.IO;
using Windows.Storage;

namespace SFUListParser.Scripts
{
    public class SaveDataHandler
    {
        private static string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "config.json");

        private static SaveDataHandler instance;

        public static SaveDataHandler Init()
        {
            if (instance == null)
                instance = new SaveDataHandler();

            return instance;
        }

        public void SaveData(string data) =>
            File.WriteAllText(path, data);

        public void ClearData() =>
            File.WriteAllText(path, string.Empty);

        public string LoadData()
        {
            if (!File.Exists(path))
            {
                File.CreateText(path).Close();
                File.WriteAllText(path, "[]");
            }


            return File.ReadAllText(path);
        }
    }
}