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
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WinForms.CRUD;

namespace WinForms
{
    public partial class EditApplicants : MaterialForm
    {
        private readonly ApplicationDbContext context;
        private readonly ApplicantService aplicantService;
        public EditApplicants()
        {
            context = new ApplicationDbContext();   
            aplicantService = new ApplicantService(context);
            InitializeComponent();
            UpdatePage();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                try
                {

                    Applicant applicant = aplicantService.GetAll().Where(a => a.Email == comboBox1.SelectedItem.ToString()).FirstOrDefault();
                    applicant.IsAplied = true;
                    aplicantService.Update(applicant);
                    context.SaveChanges();
                    MessageBox.Show("Succesfully applied");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select Item");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                try
                {
                    Applicant applicant = aplicantService.GetAll().Where(a => a.Email == comboBox1.SelectedItem.ToString()).FirstOrDefault();
                    applicant.IsAplied = false;
                    aplicantService.Update(applicant);
                    context.SaveChanges();
                    //List<Applicant> appls = aplicantService.GetAll()//Applicant.GetApplicants();
                    //Applicant applicant = appls.Where(p => p.Email == comboBox1.SelectedItem.ToString()).FirstOrDefault();// lambda
                    //applicant.IsAplied = false;
                    //appls.Remove(appls.Where(p => p.Email == comboBox1.SelectedItem.ToString()).FirstOrDefault());// lambda
                    //appls.Add(applicant);
                    //Applicant.SaveApplicants(appls);
                    MessageBox.Show("Succesfully denied");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select Item");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdatePage();
        }
        private void UpdatePage()
        {
            dataGridView1.Columns.Clear();
            List<Applicant> applicants = aplicantService.GetAll().Where(p => p.IsAdmin == false && p.ExamMark != null).ToList();// lambda
            dataGridView1.Columns.Add("FirstNameColumn", "FirstName");
            dataGridView1.Columns.Add("LastNameColumn", "LastName");
            dataGridView1.Columns.Add("EmailColumn", "Email");
            dataGridView1.Columns.Add("PhoneColumn", "Phone");
            dataGridView1.Columns.Add("BirthDateColumn", "BirthDate");
            dataGridView1.Columns.Add("PasswordColumn", "Password");
            dataGridView1.Columns.Add("ExamMarkColumn", "ExamMark");
            dataGridView1.Columns.Add("IsApliedColumn", "IsAplied");
            foreach (Applicant applicant in applicants)
            {
                comboBox1.Items.Add(applicant.Email);
            }

            dataGridView1.Rows.Clear();
            foreach (Applicant applicant in applicants)
            {
                dataGridView1.Rows.Add(applicant.FirstName,
                    applicant.LastName,
                    applicant.Email,
                    applicant.PhoneNumber,
                    applicant.BirthDate,
                    applicant.Password,
                    applicant.ExamMark.Value,
                    applicant.IsAplied
                    );
            }

        }
    }
}