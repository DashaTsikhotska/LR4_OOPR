using WinForms.Models;

namespace WinForms.CRUD
{ 
    public class ExamService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ExamService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Create(Exam exam)
        {
            _applicationDbContext.Exams.Add(exam);
            _applicationDbContext.SaveChanges();
        }
        public List<Exam> GetAll()
        {
            List<Exam> exams = _applicationDbContext.Exams
                .ToList();
            if (exams != null)
            {
                return exams;
            }
            return null;
        }
        public Exam GetById(int id)
        {
            Exam exam = _applicationDbContext.Exams
                .Where(exa => exa.Id == id)
                .FirstOrDefault();
            if (exam == null)
            {
                return null;
            }
            return exam;
        }
        public void Update(Exam ex)
        {
			try
			{
				Exam e = _applicationDbContext.Exams
				.Where(exa => exa.Id == ex.Id)
				.FirstOrDefault();
				if (e == null)
				{
					return;
				}
                e.ExamName = ex.ExamName;
                e.QuestionsOneAnswer = ex.QuestionsOneAnswer;
                e.MinutesForSolution = ex.MinutesForSolution;

				_applicationDbContext.SaveChanges();
			}
			catch (Exception excep)
			{
				throw new Exception(excep.Message);
			}
        }
        public bool Delete(int id)
        {
            Exam exa = _applicationDbContext.Exams
                .Where(e => e.Id == id)
                .FirstOrDefault();
            if (exa == null)
            {
                return false;
            }
            _applicationDbContext.Remove(exa);
            _applicationDbContext.SaveChanges();
            return true;
        }
    }
}
