using System.ComponentModel.DataAnnotations;

namespace WinForms.Models
{

    public class QuestionOneAnswer : Question
    {
        [Key]
        public int Id { get; set; }
        public Question Question { get; set; }
        public string RightAnswer { get; set; }
        public List<Answer> Answers { get; set; }

        public Exam Exam { get; set; }
        public int? ExamId { get; set; }

        public QuestionOneAnswer() { }
        public bool isAnswered { get; set; }
        public QuestionOneAnswer(string question, List<Answer> answers, string rightAnswer) : base(question)
        {
            Question = new Question(question);
            Answers = answers;
            RightAnswer = rightAnswer;
            //Node newNode = new Node { Value = value };
        }


        private void Method()
        {
            List<int> ints = new List<int>() { 1, 2, 3, };
            int a = 0;
            foreach (int i in ints)
            {
                a = i;
                string b = i.ToString();
                File.AppendAllText("path", b);
            }
        }
        private void stupidMethod()
        {
            Question question = new Question();
            List<Question> questions = new List<Question>()
            {
               question
            };

        }
        public override string ToString()//8
        {
            return "Some string";
        }
    }
}