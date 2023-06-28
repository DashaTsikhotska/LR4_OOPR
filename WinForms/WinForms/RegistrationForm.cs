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
    public partial class RegistrationForm : MaterialForm
    {
        private readonly ApplicationDbContext context;
        private readonly ApplicantService aplicantService;
        public RegistrationForm()
        {
            context = new ApplicationDbContext();
            aplicantService = new ApplicantService(context);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
          

            Applicant applicant = new Applicant()
            {
                FirstName = textBox1.Text,
                LastName = textBox2.Text,
                Email = textBox3.Text,
                PhoneNumber = textBox4.Text,
                BirthDate = DateTime.Now,
                Password = textBox5.Text,
            };
            aplicantService.Create(applicant);
            //List<Applicant> applicants = Applicant.GetApplicants();
            //applicants.Add(applicant);
            //Applicant.SaveApplicants(applicants);
            MessageBox.Show("Succesfully Registered");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}