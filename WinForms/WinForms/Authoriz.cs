using WinForms.Models;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WinForms.CRUD;

namespace WinForms
{
    public partial class Authoriz : MaterialForm
    {
        private readonly ApplicationDbContext context;
        private readonly ApplicantService aplicantService;
        public Authoriz()
        {
            context = new ApplicationDbContext();
            aplicantService = new ApplicantService(context);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Applicant.SaveApplicants(new List<Applicant>()
            //{
            //	new Applicant("John","Doe","1@gmail.com","+38094324",DateTime.Now,"1",false),
            //	new Applicant("Michael","Smith","2@gmail.com","+380314324",DateTime.Now,"2",true)
            //});
            if (!aplicantService.GetAll().Where(a => a.IsAdmin).Any())
            {
                aplicantService.Create(new Applicant
                {
                    FirstName = "admin",
                    BirthDate = DateTime.MinValue,
                    Email = "admin",
                    IsAdmin = true,
                    LastName = "admin",
                    Password = "1",
                    PhoneNumber = "1",

                });
            }
            List<Applicant> applicants = aplicantService.GetAll();//Applicant.GetApplicants();
            bool suchPeopleExists = false;
            foreach (Applicant applicant in applicants)
            {
                if (textBox1.Text == applicant.Email && textBox2.Text == applicant.Password)
                {
                    suchPeopleExists = true;
                    break;
                }
            }
            if (suchPeopleExists)
            {
                Applicant currentApplicant = applicants.Where(p => p.Email == textBox1.Text && p.Password == textBox2.Text).FirstOrDefault();//lambda
                if (currentApplicant.IsAdmin)
                {
                    Admin admin = new Admin();
                    admin.ShowDialog(this);

                }
                else
                {
                    Menu menu = new Menu(currentApplicant);
                    menu.ShowDialog(this);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
        }
    }
}