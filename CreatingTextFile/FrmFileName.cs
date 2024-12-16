using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatingTextFile
{
    public partial class FrmFileName : Form
    {
        public FrmFileName()
        {
            InitializeComponent();
        }

        public static string FileName { get; private set; }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            FileName = txtFileName.Text + ".txt";
            this.Close();  
        }


        public static string SetFileName(string fileName)
        {
            string conFileName = string.Concat(fileName, ".txt");
            return fileName;
        }
    }
}
