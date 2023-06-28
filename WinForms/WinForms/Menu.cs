using WinForms.Models;
using MaterialSkin.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace WinForms
{
    public partial class Menu : MaterialForm
    {
        public Applicant _currentApplicant;
        public Menu(Applicant currentApplicant)
        {
            InitializeComponent();
            _currentApplicant = currentApplicant;
            if (_currentApplicant.ExamMark == null)
                button3.Enabled = false;
            else
                button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Instructions instructions = new Instructions();
            instructions.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Test test = new Test(_currentApplicant);
            test.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Result result = new Result(_currentApplicant);
            result.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}