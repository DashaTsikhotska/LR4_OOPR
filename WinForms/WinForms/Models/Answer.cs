using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Models
{
    public class Answer
    {
        public Answer() { }
        public Answer(string answerWord)
        {
            AnswerWord = answerWord;
        }
        public int Id { get; set; }
        public string AnswerWord { get; set; }
        public int? QuestionOneAnswerId { get; set; }
        public QuestionOneAnswer QuestionOneAnswer { get; set; }
    }
}
