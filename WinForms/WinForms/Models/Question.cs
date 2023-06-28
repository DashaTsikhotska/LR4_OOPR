using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Item { get; set; }
        public int QuestionOneAnswerId { get; set; }
        public QuestionOneAnswer QuestionOneAnswer { get; set; }
        public Question() { }
        public Question(string item)
        {
            Item = item;

        }
    }
}