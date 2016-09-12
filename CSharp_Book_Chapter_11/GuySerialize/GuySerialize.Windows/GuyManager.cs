using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace GuySerialize
{
    
    class GuyManager :INotifyPropertyChanged
    {
        private IStorageFile _latestGuyFile;
        public event PropertyChangedEventHandler PropertyChanged;

        private Guy _joe = new Guy("Joe", 37, 176.22M);
        private Guy _bob = new Guy("Bob", 45, 4.68M);
        private Guy _ed = new Guy("Ed", 43, 37.51M);

        public IStorageFile LatestGuyFile { get { return _latestGuyFile; } }
        public Guy Joe { get { return _joe; } }
        public Guy Bob { get { return _bob; } }
        public Guy Ed { get { return _ed; } }
        public Guy NewGuy { get; private set; }
        public string Path { get; set; }

        public async void ReadGuyAsync()
        {
            if (String.IsNullOrEmpty(Path))
                return;
            _latestGuyFile = await StorageFile.GetFileFromPathAsync(Path);

            using (IRandomAccessStream stream = await _latestGuyFile.OpenAsync(FileAccessMode.Read))

            using (Stream inputStream = stream.AsStreamForRead())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Guy));
                NewGuy = serializer.ReadObject(inputStream) as Guy;
            }

            OnPropertyChanged(nameof(NewGuy));
            OnPropertyChanged(nameof(LatestGuyFile));
        }

        public async void WriteGuyAsync(Guy guyToWrite)
        {
            IStorageFolder guysFolder = 
                await KnownFolders.PicturesLibrary.CreateFolderAsync("Guys", CreationCollisionOption.OpenIfExists);

            _latestGuyFile = 
                await guysFolder.CreateFileAsync($"{guyToWrite.Name}.xml", CreationCollisionOption.ReplaceExisting);

            using (IRandomAccessStream stream = await _latestGuyFile.OpenAsync(FileAccessMode.ReadWrite))

            using (Stream outputStream = stream.AsStreamForWrite())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Guy));
                serializer.WriteObject(outputStream, guyToWrite);
            }

            Path = _latestGuyFile.Path;

            OnPropertyChanged(nameof(Path));
            OnPropertyChanged(nameof(LatestGuyFile));
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
