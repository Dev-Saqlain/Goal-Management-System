using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "" || txtsurname.Text == "" || txtmail.Text == "" || txtusername.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("Fill form carefully.", "Error.");

                Signup s = new Signup();
                this.Hide();
                s.Show();
            }
            else
            {
                ServiceReference1.Service1Client myserver = new ServiceReference1.Service1Client();
                ServiceReference1.User myuser = new ServiceReference1.User();
                myuser.Username = txtusername.Text;
                myuser.Password = txtpass.Text;
                myserver.Adduser(myuser);
                MessageBox.Show("SignUp Successfully");
                Login login = new Login();
                this.Hide();
                login.Show();
            }

        }
    }
}
