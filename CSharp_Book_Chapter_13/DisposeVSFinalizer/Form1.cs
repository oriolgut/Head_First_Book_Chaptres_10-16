using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisposeVSFinalizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnButtonCreateClone1Click(object sender, EventArgs e)
        {
            using(Clone clone1 = new Clone(1))
            {

            }
        }

        private void OnButtonCreateClone2Click(object sender, EventArgs e)
        {
            Clone clone2 = new Clone(2);
            clone2 = null;
        }

        private void OnButtonGarbageCollectorClick(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}
