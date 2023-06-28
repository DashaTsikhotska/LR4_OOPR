using WinForms.Models;
using MaterialSkin.Controls;
using System.Data;
using WinForms.CRUD;

namespace WinForms
{
    public partial class Test : MaterialForm
    {
        public static int currentQuestion;
        public static int currentMark;
        public static int numberQuestions;
        public static Exam exam;
        private readonly Applicant _currentApplicant;
        private readonly ApplicationDbContext _context;
        private readonly ApplicantService applicantService;
        public Test(Applicant currentApplicant)
        {
            _context = new ApplicationDbContext();
            applicantService = new ApplicantService(_context);
            InitializeComponent();

            currentQuestion = 0;
            _currentApplicant = currentApplicant;
            exam = Exam.GetExam();
            numberQuestions = exam.QuestionsOneAnswer.Count();

            CheckPagination();
            CreateQuestion(exam.QuestionsOneAnswer[currentQuestion], exam.QuestionsOneAnswer[currentQuestion].Answers, testPanel);
        }
        public void CreateQuestion(QuestionOneAnswer questionOneAnswer, List<Answer> answers, Panel panel)
        {

            panel.Controls.Clear();
            Label label = new Label()
            {
                Width = this.Width
            };

            label.Text = questionOneAnswer.Question.Item;
            panel.Controls.Add(label);

            int y = label.Bottom + 10;
            for (int i = 0; i < questionOneAnswer.Answers.Count(); i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Text = answers[i].AnswerWord;
                radioButton.Location = new Point(10, y);
                panel.Controls.Add(radioButton);

                y += radioButton.Height + 5;
            }
            CheckPagination();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            currentQuestion++;
            CreateQuestion(exam.QuestionsOneAnswer[currentQuestion], exam.QuestionsOneAnswer[currentQuestion].Answers, testPanel);
            CheckPagination();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentQuestion--;
            CreateQuestion(exam.QuestionsOneAnswer[currentQuestion], exam.QuestionsOneAnswer[currentQuestion].Answers, testPanel);
            CheckPagination();
        }
        private void CheckPagination()
        {
            if (currentQuestion == 0)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
            if (currentQuestion == exam.QuestionsOneAnswer.Count - 1)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }

            // If there are no more questions, hide the answer button
            if (exam.QuestionsOneAnswer.Count == 0)
            {
                Answer.Visible = false;
            }
        }
        private void Answer_Click(object sender, EventArgs e)
        {
            // Get the selected radio button from the panel
            RadioButton selectedRadioButton = testPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton != null)
            {
                if (exam.QuestionsOneAnswer[currentQuestion].RightAnswer == selectedRadioButton.Text) currentMark++;
                // Remove the current question from the questionOneAnswers list
                exam.QuestionsOneAnswer.RemoveAt(currentQuestion);

                testPanel.Controls.Clear(); // Remove all controls from the panel
                currentQuestion = 0; // Move to the next question

                if (currentQuestion < exam.QuestionsOneAnswer.Count)
                {
                    // If there are more questions, create the next question
                    CreateQuestion(exam.QuestionsOneAnswer[currentQuestion], exam.QuestionsOneAnswer[currentQuestion].Answers, testPanel);
                    CheckPagination();
                }
                else
                {
                    double totalMark = (double)currentMark / numberQuestions * 100;
                    if (numberQuestions % 2 != 0 && totalMark > 99.5)
                    {
                        totalMark = 100;
                    }
                    // If all questions have been answered, show the final score
                    MessageBox.Show($"Final score: {totalMark}/{100}");
                    Answer.Enabled = false;

                    //зберегти для цього апліканта результат проходження
                    _currentApplicant.ExamMark = new Mark((int)Math.Round(totalMark));
                    applicantService.Update(_currentApplicant);
                    
                    this.Close();
                    Menu menu = new Menu(_currentApplicant);
                    menu.ShowDialog();
                }
            }
        }
    }
}