using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms.Models;

namespace WinForms.CRUD
{
    public class MarkService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public MarkService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Create(Mark applicant)
        {
            _applicationDbContext.Marks.Add(applicant);
            _applicationDbContext.SaveChanges();
        }
        public List<Mark> GetAll()
        {
            List<Mark> marks = _applicationDbContext.Marks
                .ToList();
            if (marks != null)
            {
                return marks;
            }
            return null;
        }
        public Mark GetById(int id)
        {
            Mark mar = _applicationDbContext.Marks
                .Where(app => app.Id == id)
                .FirstOrDefault();
            if (mar == null)
            {
                return null;
            }
            return mar;
        }
        public void Update(Mark m)
        {
			try
			{
				Mark mark = _applicationDbContext.Marks
				.Where(mar => mar.Id == m.Id)
				.FirstOrDefault();
				if (mark == null)
				{
					return;
				}
				mark.Value = m.Value;
                mark.ApplicantId = m.ApplicantId;
				_applicationDbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			//_applicationDbContext.Update(m);
			//_applicationDbContext.SaveChanges();
		}
        public bool Delete(int id)
        {
            Mark ma = _applicationDbContext.Marks
                .Where(app => app.Id == id)
                .FirstOrDefault();
            if (ma == null)
            {
                return false;
            }
            _applicationDbContext.Marks.Remove(ma);
            _applicationDbContext.SaveChanges();
            return true;
        }
    }
}
