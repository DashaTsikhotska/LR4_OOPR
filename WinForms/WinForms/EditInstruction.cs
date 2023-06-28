using MaterialSkin.Controls;

namespace WinForms
{
    public delegate void SomeDelegate();
    public partial class EditInstruction : MaterialForm
    {
        private const string PATH = "Instruction.txt";
        public EditInstruction()
        {

            InitializeComponent();
            if(File.Exists(PATH))
            richTextBox1.Text = File.ReadAllText(PATH);
            else
                MessageBox.Show("File does not exist.");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Action action = () => // Anonymous method
            {
                richTextBox1.Text = "";
            };
            SomeDelegate someDelegate = BasicTask;
            someDelegate.Invoke();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.WriteAllText(PATH, richTextBox1.Text);
            MessageBox.Show("Succesfully saved");
        }
        private void BasicTask()
        {
            Console.WriteLine("Hello world!");
        }
    }
}