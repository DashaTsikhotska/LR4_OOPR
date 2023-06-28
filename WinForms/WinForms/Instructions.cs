using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Instructions : MaterialForm
    {
        public Instructions()
        {
            InitializeComponent();
            string path = "Instruction.txt";
            richTextBox1.Text = File.ReadAllText(path, Encoding.UTF8);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}