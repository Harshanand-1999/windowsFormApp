using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        studentDBDataContext db;
        List<student> lst;
        int index;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           /* studentDBDataContext db= new studentDBDataContext();
            DataGrid.datasource = db.students;
            Table<student> stdtable = db.students;
            IDataGrid.source = stdtable;*/
            db=new studentDBDataContext();
            lst= db.students.ToList();
            Display();



        }
        public void Display()
        {
            IDtextBox.Text = lst[index].Id.ToString();
            NAMEtextbox.Text = lst[index].name;
            AGEtextbox.Text = lst[index].age.ToString();
            GENDERtextbox.Text = lst[index].gender;
            STANDARDtextbox.Text = lst[index].standard.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index < lst.Count-1)
            {
                index+=1;
                Display();
            }
            else
                MessageBox.Show("this is last element");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void PREVIOUSbutton_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index -= 1;
                Display();
            }
            else
                MessageBox.Show("this is first element");
        }
    }
}
