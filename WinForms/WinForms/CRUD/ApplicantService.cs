using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using WinForms.Models;

namespace WinForms.CRUD
{
    public class ApplicantService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ApplicantService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Create(Applicant applicant)
        {
            _applicationDbContext.Applicants.Add(applicant);
            _applicationDbContext.SaveChanges();
        }
        public List<Applicant> GetAll()
        {
            List<Applicant> applicants = _applicationDbContext.Applicants
                .Include(a=>a.ExamMark)
                .ToList();
            if (applicants != null)
            {
                return applicants;
            }
            return null;
        }
        public Applicant GetById(int id)
        {
            Applicant applicant = _applicationDbContext.Applicants
                .Where(app => app.Id == id)
                .FirstOrDefault();
            if (applicant == null)
            {
                return null;
            }
            return applicant;
        }
        public void Update(Applicant applicant)
        {
			try
			{
				Applicant a = _applicationDbContext.Applicants
				.Where(app => app.Id == applicant.Id)
				.FirstOrDefault();
                if(a == null)
                {
                    return;
                }
                a.FirstName = applicant.FirstName;
                a.LastName= applicant.LastName;
                a.Email = applicant.Email;
                a.PhoneNumber=applicant.PhoneNumber;
                a.BirthDate = applicant.BirthDate;
                a.Password = applicant.Password;
                a.ExamMark = applicant.ExamMark;
                a.IsAdmin = applicant.IsAdmin;
                a.IsAplied = applicant.IsAplied;

                _applicationDbContext.SaveChanges();
			}
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //_applicationDbContext.Applicants.Update(applicant);
            //_applicationDbContext.SaveChanges();
        }
        public bool Delete(int id)
        {
            Applicant applicant = _applicationDbContext.Applicants
                .Where(app => app.Id == id)
                .FirstOrDefault();
            if (applicant == null)
            {
                return false;
            }
            _applicationDbContext.Applicants.Remove(applicant);
            _applicationDbContext.SaveChanges();
            return true;
        }
		#region Lab7
		public List<Applicant> GetApplicantsByCriteria(string criteria)
		{
			List<Applicant> filteredApplicants = _applicationDbContext.Applicants
				.Where(applicant => applicant.FirstName.Contains(criteria) || applicant.LastName.Contains(criteria))
				.ToList();

			return filteredApplicants;
		}
		public Dictionary<string, List<Applicant>> GroupApplicantsByCity()
		{
			Dictionary<string, List<Applicant>> groupedApplicants = _applicationDbContext.Applicants
				.GroupBy(applicant => applicant.FirstName)
				.ToDictionary(group => group.Key, group => group.ToList());

			return groupedApplicants;
		}
		public List<Applicant> GetApplicantsWithExamMarks()
		{
			List<Applicant> applicantsWithExamMarks = _applicationDbContext.Applicants
				.Join(_applicationDbContext.Marks,
					applicant => applicant.Id,
					examMark => examMark.ApplicantId,
					(applicant, examMark) => applicant)
				.ToList();

			return applicantsWithExamMarks;
		}
		public List<object> GetApplicantDetails()
		{
			List<object> applicantDetails = _applicationDbContext.Applicants
				.Select(applicant => new
				{
					FullName = applicant.FirstName + " " + applicant.LastName,
					Age = DateTime.Now.Year - applicant.BirthDate.Year
				})
				.ToList<object>();

			return applicantDetails;
		}
		public List<Applicant> GetApplicantsWithMinExamMark(int minMark)
		{
			List<Applicant> applicants = _applicationDbContext.Applicants
				.Where(applicant => applicant.ExamMark.Value >= minMark)
				.ToList();

			return applicants;
		}
		public Applicant GetApplicantWithMaxGrade()
		{
			Applicant applicant = _applicationDbContext.Applicants
				.OrderByDescending(applicant => applicant.ExamMark)
				.FirstOrDefault();

			return applicant;
		}
		public List<Applicant> GetSortedApplicantsByLastName()
		{
			List<Applicant> sortedApplicants = _applicationDbContext.Applicants
				.OrderBy(applicant => applicant.LastName)
				.ToList();

			return sortedApplicants;
		}
		public List<object> GetApplicantsWithCityAndExamMark()
		{
			List<object> applicantsWithCityAndExamMark = _applicationDbContext.Applicants
				.Join(_applicationDbContext.Marks,
					applicant => applicant.Id,
					examMark => examMark.ApplicantId,
					(applicant, examMark) => new
					{
						FullName = applicant.FirstName + " " + applicant.LastName,
						ExamMark = examMark.Value
					})
				.ToList<object>();

			return applicantsWithCityAndExamMark;
		}
		public List<Applicant> GetUniqueApplicants(List<Applicant> applicants1, List<Applicant> applicants2)
		{
			List<Applicant> uniqueApplicants = applicants1.Union(applicants2).ToList();

			return uniqueApplicants;
		}
		public int GetTotalApplicantCount()
		{
			int totalApplicantCount = _applicationDbContext.Applicants.Count();

			return totalApplicantCount;
		}

		#endregion
	}
}