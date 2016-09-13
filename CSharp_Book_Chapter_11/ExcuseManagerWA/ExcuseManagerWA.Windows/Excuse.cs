using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace ExcuseManagerWA
{
    [DataContract]
    class Excuse : INotifyPropertyChanged
    {
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Results { get; set; }
        [DataMember]
        public DateTimeOffset LastUsed { get; set; }

        public Excuse()
        {
            LastUsed = DateTimeOffset.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}