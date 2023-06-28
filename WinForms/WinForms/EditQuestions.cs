using WinForms.Models;
using MaterialSkin.Controls;

namespace WinForms
{

	public partial class EditQuestions : MaterialForm
	{
		public EditQuestions()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{


			List<Answer> answers = new List<Answer>
			{
				new Answer(textBox1.Text),
				new Answer(textBox2.Text),
				new Answer( textBox3.Text),
				new Answer( textBox4.Text),
				new Answer( textBox5.Text)
			};
			QuestionOneAnswer question = new QuestionOneAnswer()
			{
				Answers = answers,
				Question = new Question(textBox6.Text),
				RightAnswer = textBox7.Text
			};
			Exam exam = Exam.GetExam();
			exam.QuestionsOneAnswer.Add(question);
			Exam.SaveExam(exam);
			MessageBox.Show("Succesfully added");
		}
	}
}