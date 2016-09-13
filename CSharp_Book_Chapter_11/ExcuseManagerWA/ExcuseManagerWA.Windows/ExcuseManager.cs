using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace ExcuseManagerWA 
{
    class ExcuseManager : INotifyPropertyChanged
    {
        private Random _random = new Random();
        private IStorageFolder _excuseFolder = null;
        private IStorageFile _excuseFile;

        public ExcuseManager()
        {
            NewExcuseAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Excuse CurrentExcuse { get; set; }
        public string FileDate { get; private set; }
        
        async public void NewExcuseAsync()
        {
            CurrentExcuse = new Excuse();
            _excuseFile = null;
            OnPropertyChanged(nameof(CurrentExcuse));
            await UpDateFileAsync();
        }

        public async Task UpDateFileAsync()
        {
            if(_excuseFile != null)
            {
                BasicProperties basicProperties = await _excuseFile.GetBasicPropertiesAsync();
                FileDate = basicProperties.DateModified.ToString();
            }
            else
            {
                FileDate = "(no file loaded)";
                OnPropertyChanged(nameof(FileDate));
            }
        }
        public async Task<bool> ChooseNewFolderAsync()
        {
            FolderPicker folderPicker = new FolderPicker()
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            folderPicker.FileTypeFilter.Add(".xml");
            IStorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if(folder != null)
            {
                _excuseFolder = folder;
                return true;
            }
            MessageDialog warningDialog = new MessageDialog("No excuse folder chosen.");
            await warningDialog.ShowAsync();
            return false;
        }
        
        public async void OpenExcuseAsync()
        {
            FileOpenPicker picker = new FileOpenPicker()
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                CommitButtonText = "Open Excuse File"
            };
            picker.FileTypeFilter.Add(".xml");
            _excuseFile = await picker.PickSingleFileAsync();
            if(_excuseFile != null)
            {
                await ReadExcuseAsync();
            }
        }

        public async void OpenRandomExcuseAsync()
        {
            IReadOnlyList<IStorageFile> files = await _excuseFolder.GetFilesAsync();
            _excuseFile = files[_random.Next(0, files.Count())];
            await ReadExcuseAsync();
        }

        public async void SaveCurrentExcuseAsync()
        {
            if(CurrentExcuse == null)
            {
                await new MessageDialog("No excuse loaded").ShowAsync();
                return;
            }
            if (String.IsNullOrEmpty(CurrentExcuse.Description))
            {
                await new MessageDialog("Current excuse doesnt have a description").ShowAsync();
                return;
            }
            if(_excuseFile == null)
            {
                _excuseFile = await _excuseFolder.CreateFileAsync($"{CurrentExcuse.Description}.xml", CreationCollisionOption.ReplaceExisting);
            }
        }

        public async Task ReadExcuseAsync()
        {
            //oriols suggestion without serializer 
            using (StreamReader reader = new StreamReader(await _excuseFile.OpenStreamForReadAsync()))
            {
                string[] nextLine = new string[10];
                for(int i = 0; reader.ReadLineAsync() != null; i++)
                {
                    nextLine[i] = await reader.ReadLineAsync();
                }
                CurrentExcuse.Description = nextLine[0];
                CurrentExcuse.Results = nextLine[1];
                CurrentExcuse.LastUsed = Convert.ToDateTime(nextLine[2]);
            }

            //or solution of the book:
            /*
            using (IRandomAccessStream stream = await _excuseFile.OpenAsync(FileAccessMode.Read))
            using (Stream inputStream = stream.AsStreamForRead())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Excuse));
                CurrentExcuse = serializer.ReadObject(inputStream) as Excuse;
            }
            */
        
            await new MessageDialog($"Excuse read from {_excuseFile.Name}").ShowAsync();
            OnPropertyChanged(nameof(CurrentExcuse));
            await UpDateFileAsync();
        }

        public async Task WriteExcuseAsync()
        {
            if(_excuseFile != null && CurrentExcuse != null)
            {
                using (StreamWriter writer = new StreamWriter(await _excuseFile.OpenStreamForWriteAsync()))
                {
                    await writer.WriteLineAsync(CurrentExcuse.Description);
                    await writer.WriteLineAsync(CurrentExcuse.Results);
                    await writer.WriteLineAsync(CurrentExcuse.LastUsed.ToString());
                }
                await new MessageDialog($"Excuse read from {_excuseFile.Name}").ShowAsync();
                await UpDateFileAsync();
            }
        }

        public async void SaveCurrentExcuseAsAsync()
        {
            if (_excuseFile == null)
            {
                FileSavePicker picker = new FileSavePicker()
                {
                    SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                    SuggestedFileName = CurrentExcuse.Description,
                    CommitButtonText = "Save File Excuse"
                };
                picker.FileTypeChoices.Add("XMl File", new List<string>() { ".xml" });
                picker.FileTypeChoices.Add("All Types (*.*)", new List<string>() { "" });
                IStorageFile newExcuseFile = await picker.PickSaveFileAsync();
                if (newExcuseFile != null)
                {
                    _excuseFile = newExcuseFile;
                    await WriteExcuseAsync();
                    await new MessageDialog($"Wrote: {_excuseFile.Name}").ShowAsync();
                }
            }  
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
