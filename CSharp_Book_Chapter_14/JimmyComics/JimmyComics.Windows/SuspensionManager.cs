using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace JimmyComics
{
    class SuspensionManager
    {
        public static string CurrentQuery { get; set; }

        private const string FILENAME = "_sessionState.txt";

        static async public Task SaveAsync()
        {
            if (String.IsNullOrEmpty(CurrentQuery))
            {
                CurrentQuery = String.Empty;
            }
            IStorageFile storageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(FILENAME, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(storageFile, CurrentQuery);
        }

        static async public Task RestoreAsync()
        {
            IStorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(FILENAME);
            CurrentQuery = await FileIO.ReadTextAsync(storageFile);
        }
    }
}