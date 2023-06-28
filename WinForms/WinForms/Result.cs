using WinForms.Models;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Result : MaterialForm
    {
        private readonly Applicant _currentApplicant;
       
        public Result(Applicant currentApplicant)
        {
            InitializeComponent();
            _currentApplicant = currentApplicant;

            if (_currentApplicant.IsAplied == null)
            {
                richTextBox1.Text = "Ваша заявка оброблюється, після опрацювання проходження тесту на вступ тут буде отриману відповідь.";
            }
            else if (_currentApplicant.IsAplied == true)
            {
                richTextBox1.Text = "Вітаємо ви були прийняті. Для отримання подальшої інформації про вступ ми з вами зв'яжемося.";

            }
            else if (_currentApplicant.IsAplied == false)
            {
                richTextBox1.Text = "Ваша заявка була відхилена.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}