using PMAFileAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_project
{
    public partial class Form1 : Form
    {
        PMANode root;
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String path = dialog.FileName;

                root = PMAFile.read(path);
            }
        }

        

        

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PMAFile.write(root, "D://test.txt");
        }
    }
}
