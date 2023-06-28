using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms.Models;

namespace WinForms.CRUD
{
    public class QuestionOneAnswerService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public QuestionOneAnswerService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Create(QuestionOneAnswer q)
        {
            _applicationDbContext.QuestionOneAnswers.Add(q);
            _applicationDbContext.SaveChanges();
        }
        public List<QuestionOneAnswer> GetAll()
        {
            List<QuestionOneAnswer> marks = _applicationDbContext.QuestionOneAnswers
                .ToList();
            if (marks != null)
            {
                return marks;
            }
            return null;
        }
        public QuestionOneAnswer GetById(int id)
        {
            QuestionOneAnswer mar = _applicationDbContext.QuestionOneAnswers
                .Where(app => app.Id == id)
                .FirstOrDefault();
            if (mar == null)
            {
                return null;
            }
            return mar;
        }
        public void Update(QuestionOneAnswer q)
        {
			try
			{
				QuestionOneAnswer ques = _applicationDbContext.QuestionOneAnswers
				.Where(qe => qe.Id == q.Id)
				.FirstOrDefault();
				if (ques == null)
				{
					return;
				}
                ques.Question = q.Question;
                ques.RightAnswer = q.RightAnswer;
                ques.Answers = q.Answers;
                ques.ExamId = q.ExamId;

				_applicationDbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
        public bool Delete(int id)
        {
            QuestionOneAnswer ma = _applicationDbContext.QuestionOneAnswers
                .Where(app => app.Id == id)
                .FirstOrDefault();
            if (ma == null)
            {
                return false;
            }
            _applicationDbContext.QuestionOneAnswers.Remove(ma);
            _applicationDbContext.SaveChanges();
            return true;
        }
    }
}
