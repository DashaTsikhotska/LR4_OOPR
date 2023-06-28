using MaterialSkin.Controls;

namespace WinForms
{
    public partial class Admin : MaterialForm
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditInstruction editInstruction = new EditInstruction();
            editInstruction.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditQuestions editQuestions = new EditQuestions();
            editQuestions.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditApplicants editApplicants = new EditApplicants();
            editApplicants.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}