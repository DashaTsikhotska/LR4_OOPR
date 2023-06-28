using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WinForms.Models
{
    public sealed class Exam//7
    {
        [Key]
        public int Id { get; set; }
        public string ExamName { get; set; }
        public List<QuestionOneAnswer>? QuestionsOneAnswer { get; set; }
        public int? MinutesForSolution;

        public Exam()
        {
            QuestionsOneAnswer = new List<QuestionOneAnswer>();
        }
        public Exam(string examName, List<QuestionOneAnswer> questionsOneAnswer)
        {
            ExamName = examName;
            QuestionsOneAnswer = questionsOneAnswer;
        }
        public static Exam GetExam()
        {
            Exam exam = new Exam();
            string json = File.ReadAllText("exam.json");
            exam = JsonConvert.DeserializeObject<Exam>(json);
            return exam;
        }
        public static void SaveExam(Exam exam)
        {
            string json = JsonConvert.SerializeObject(exam);
            File.WriteAllText("exam.json", json);
        }

    }
}