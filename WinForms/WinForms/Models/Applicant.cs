using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WinForms.Models;

namespace WinForms.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public Mark? ExamMark { get; set; }
        public bool IsAdmin { get; set; }
        public bool? IsAplied { get; set; }
        public Applicant() { }
        public Applicant(string firstName, string lastName, string email, string phoneNumber, DateTime birthDate, string password, bool isAdmin)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Password = password;
            IsAdmin = isAdmin;
        }
        //public static List<Applicant> GetApplicants()
        //{

        //    List<Applicant> list = new List<Applicant>();

        //    string json = File.ReadAllText("user.json");
        //    list = JsonConvert.DeserializeObject<List<Applicant>>(json);
        //    return list;
        //}
        //public static void SaveApplicants(List<Applicant> applicants)
        //{
        //    string json = JsonConvert.SerializeObject(applicants);
        //    File.WriteAllText("user.json", json);
        //}

    }
}