using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using TestRepo.Repository.Repository;
using TestRepo.Business.StudentBusiness;

namespace DesktopSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtAttach.Visible = false;
            txtBody.Visible = false;
            txtSubject.Visible = false;
            btnSend.Visible = false;
            btnAttach.Visible = false;
            txtTo.Visible = false;
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() ==DialogResult.OK)
            {
                txtAttach.Text = openFileDialog1.FileName.ToString();//this method is for selecting your file.
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient("smtp.gmail.com");//change your client if you not using gmail
                mail.From = new MailAddress("your email");
                mail.To.Add(txtTo.Text);
                mail.Subject = txtSubject.Text;
                mail.Body = txtBody.Text;
                if (txtAttach.Text != "")
                {
                    mail.Attachments.Add(new Attachment(txtAttach.Text));
                }
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("your email", "your password");
                client.EnableSsl = true;
                client.Send(mail);
                MessageBox.Show("Email Sent Successfully!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*this method below ensure security is kept.
         you would only be able to send the email if the student number is found
         then only would the names and email field would be populated.
         */

        private void btnSearch_Click(object sender, EventArgs e)
        {
            StudentBusiness buss = new StudentBusiness();
            var std = buss.search(Convert.ToInt32(txtStudentNum.Text));
            if (std!=null)
            {
                txtName.Text = std.Name;
                txtSurname.Text = std.Surname;
                txtTo.Visible = true;
                txtTo.Text = std.email;
                txtAttach.Visible = true;
                txtBody.Visible = true;
                txtSubject.Visible = true;
                btnSend.Visible = true;
                btnAttach.Visible = true;

            }

        }
    }
}
