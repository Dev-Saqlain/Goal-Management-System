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
    public partial class Roles : Form
    {
        public static string passname;
        public static string passtype;

        public Roles()
        {
            InitializeComponent();
            


        }

        private void Roles_Load(object sender, EventArgs e)
        {
            datashow();
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client myserver = new ServiceReference1.Service1Client();
            ServiceReference1.Roles myroles = new ServiceReference1.Roles();
            myroles.RoleName = textBox1.Text;
            myroles.RoleType = comboBox1.Text;
            myserver.AddRole(myroles);
            datashow();

        }
        private void datashow()
        {
            ServiceReference1.Service1Client myclient = new ServiceReference1.Service1Client();
            BindingSource abc = new BindingSource();
            abc.DataSource = myclient.getRolesList();
            dataGridView1.DataSource = abc;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Roles roles = new Roles();
            this.Hide();
            roles.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Goals goals = new Goals();
            this.Hide();
            goals.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ToDocs toDocs = new ToDocs();
            this.Hide();
            toDocs.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            this.Hide();
            report.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ServiceReference1.Service1Client myserver = new ServiceReference1.Service1Client();
            if (e.ColumnIndex == 2)
            {
                ServiceReference1.Roles mypost = new ServiceReference1.Roles();
                int index = this.dataGridView1.SelectedCells[0].RowIndex;
                mypost = myserver.getRoles(index);
                Editformcs edit = new Editformcs(mypost, index);
                this.Hide();
                edit.Show();
            }
            if (e.ColumnIndex == 3)
            {
                myserver.Delete(e.RowIndex);
                datashow();
            }
            if (e.ColumnIndex == 4)
            {
                
                passname = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                passtype = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Goals goal = new Goals(passname, passtype);
                this.Hide();
                goal.Show();

            }
        }
    }
}
