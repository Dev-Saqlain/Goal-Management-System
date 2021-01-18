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
    public partial class EditGoal : Form
    {
        private ServiceReference1.Goal editgoal = new ServiceReference1.Goal();
        private ServiceReference1.Service1Client server = new ServiceReference1.Service1Client();
        int index;
        public EditGoal()
        {
            InitializeComponent();
        }
        public EditGoal(ServiceReference1.Goal goal, int a)
        {
            InitializeComponent();
            editgoal = goal;
            index = a;
        }

        private void EditGoal_Load(object sender, EventArgs e)
        {
            textBox2.Text = editgoal.Golname;

        }

        private void btnSaveGoal_Click(object sender, EventArgs e)
        {
            editgoal.Golname = textBox2.Text;
            server.delGoal(index);
            server.saveGoal(editgoal, index);
            //this.Close();
            Goals goal = new Goals();
            goal.Show();


        }
    }
}
