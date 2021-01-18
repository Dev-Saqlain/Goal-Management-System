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
    public partial class Goals : Form
    {
        public static string passgoal;
        public Goals()
        {
            InitializeComponent();
        }
        public Goals(string rolname, string roletype)
        {
            InitializeComponent();
            textBox1.Text = rolname;
            comboBox1.Text = roletype;
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

        private void Goals_Load(object sender, EventArgs e)
        {
            textBox1.Text = Roles.passname;
            comboBox1.Text = Roles.passtype;
            datashow();

        }

        private void btn_goal_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client myserver = new ServiceReference1.Service1Client();
            ServiceReference1.Roles myrole = new ServiceReference1.Roles();
            ServiceReference1.Goal mygoal = new ServiceReference1.Goal();
            mygoal.Golname = textBox2.Text;
            myserver.addGoal(mygoal);
            datashow();
        }
        private void datashow()
        {
            ServiceReference1.Service1Client myclient = new ServiceReference1.Service1Client();
            BindingSource abc = new BindingSource();
            abc.DataSource = myclient.getGoalList();
            dataGridView1.DataSource = abc;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ServiceReference1.Service1Client myserver = new ServiceReference1.Service1Client();
            if (e.ColumnIndex == 1)
            {
                ServiceReference1.Goal mypost = new ServiceReference1.Goal();
                int index = this.dataGridView1.SelectedCells[0].RowIndex;
                mypost = myserver.getgoal(index);
                EditGoal editpost = new EditGoal(mypost, index);
                this.Show();
                editpost.Show();
            }
            if (e.ColumnIndex == 2)
            {
                myserver.delGoal(e.RowIndex);
                datashow();
            }
            if (e.ColumnIndex == 3)
            {
                passgoal= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                ToDocs todo = new ToDocs();
                this.Hide();
                todo.Show();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
