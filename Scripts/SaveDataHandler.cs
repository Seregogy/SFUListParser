using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;

namespace SFUListParser.Scripts
{
    public class SaveDataHandler
    {
        private static SaveDataHandler instance;

        public static SaveDataHandler Init()
        {
            if (instance == null)
            {
                instance = new SaveDataHandler();
            }

            return instance;
        }

        public async Task SaveData(string data)
        {
            await ApplicationData.Current.LocalFolder.WriteTextToFileAsync(data, "config.json");
        }


        public async Task<string> LoadDataAsync()
        {
            var storageFolder = ApplicationData.Current.LocalFolder;

            if (!await storageFolder.FileExistsAsync("config.json"))
                await storageFolder.CreateFileAsync("config.json");

            DataPackage package = new DataPackage();
            package.SetText(storageFolder.Path.ToString());
            Clipboard.SetContent(package);

            return await storageFolder.ReadTextFromFileAsync("config.json");
        }
    }
}