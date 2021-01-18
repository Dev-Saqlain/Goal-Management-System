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
    public partial class EditToDo : Form
    {
        private ServiceReference1.ToDo edittodo = new ServiceReference1.ToDo();
        private ServiceReference1.Service1Client server = new ServiceReference1.Service1Client();
        int index;
        public EditToDo()
        {
            InitializeComponent();
        }
        public EditToDo(ServiceReference1.ToDo todo, int a)
        {
            InitializeComponent();
            edittodo = todo;
            index = a;
        }

        private void EditToDo_Load(object sender, EventArgs e)
        {
            textBox1.Text = edittodo.Todos;
            textBox2.Text = edittodo.Date;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            edittodo.Todos = textBox1.Text;
            edittodo.Date = textBox2.Text;
            server.DelToDo(index);
            server.saveToDo(edittodo, index);
            //this.Close();
            ToDocs todo = new ToDocs();
            todo.Show();
        }
    }
}
