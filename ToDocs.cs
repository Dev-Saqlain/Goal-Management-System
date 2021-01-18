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
    public partial class ToDocs : Form
    {
        public ToDocs()
        {
            InitializeComponent();
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

        private void ToDocs_Load(object sender, EventArgs e)
        {
            textBox4.Text = Goals.passgoal;
            textBox1.Text = Roles.passname;
            textBox3.Text = Roles.passtype;
            datashow();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client myserver = new ServiceReference1.Service1Client();
            ServiceReference1.Roles myrole = new ServiceReference1.Roles();
            ServiceReference1.Goal mygoal = new ServiceReference1.Goal();
            ServiceReference1.ToDo todo = new ServiceReference1.ToDo();
            todo.Todos = textBox2.Text;
            todo.Date = dateTimePicker1.Text;
            myserver.AddToDo(todo);
            datashow();
        }
        private void datashow()
        {
            ServiceReference1.Service1Client myclient = new ServiceReference1.Service1Client();
            BindingSource abc = new BindingSource();
            abc.DataSource = myclient.getToDoList();
            dataGridView1.DataSource = abc;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ServiceReference1.Service1Client myserver = new ServiceReference1.Service1Client();
            if (e.ColumnIndex == 0)
            {
                ServiceReference1.ToDo mypost = new ServiceReference1.ToDo();
                int index = this.dataGridView1.SelectedCells[0].RowIndex;
                mypost = myserver.getToDo(index);
                EditToDo editpost = new EditToDo(mypost, index);
                editpost.Show();
            }
            if (e.ColumnIndex == 3)
            {
                myserver.DelToDo(e.RowIndex);
                datashow();
            }
        }
    }
    
}
