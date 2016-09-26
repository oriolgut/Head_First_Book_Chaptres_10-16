using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisposeVSFinalizer
{
    [Serializable]
    class Clone : IDisposable
    {
        public int ID { get; private set; }
        public Clone(int id)
        {
            ID = id;
        }
        public void Dispose()
        {
            string fileName = @"C:\Temp\Clone.dat";
            string dirName = @"C:\Temp\";

            if(File.Exists(fileName) == false)
            {
                Directory.CreateDirectory(dirName);
            }

            BinaryFormatter bf = new BinaryFormatter();

            using(Stream output = File.OpenWrite(fileName))
            {
                bf.Serialize(output, this);
            }

            MessageBox.Show("Must...serialize...object!", $"Clone #{ID} says...");
        }
        ~Clone()
        {
            MessageBox.Show("Aaargh! you got me!", $"Clone #{ID} says...");
        }
    }
}
