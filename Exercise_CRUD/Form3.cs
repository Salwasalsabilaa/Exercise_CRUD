using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_CRUD
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            string Code;

            // TODO: This line of code loads data into the 'exerciseKueDataSet.Karyawan' table. You can move, or remove it, as needed.
            this.karyawanTableAdapter.Fill(this.exerciseKueDataSet.Karyawan);
            //This line of code loads data into the hRDataSet.Empdetails table. this would appear in form 1 load event
            this.karyawanTableAdapter.Fill(this.exerciseKueDataSet.Karyawan);
            txtid.Enabled = false;
            txtnama.Enabled = false;
            txtemail.Enabled = false;
            cmdSave.Enabled = false;

        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            string Code;

            cmdSave.Enabled = true;
            txtnama.Enabled = true;
            txtnama.Text = "";
            txtemail.Text = "";
            int ctr, len;
            string codeval;
            dt = exerciseKueDataSet.Tables["Karyawan"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            Code = dr["Id_Karyawan"].ToString();
            codeval = Code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if ((ctr >= 0) && (ctr < 9))
            {
                ctr = ctr + 1;
                txtid.Text = "KR110" + ctr;
            }
            else if ((ctr >= 9) && (ctr < 99))
            {
                ctr = ctr + 1;
                txtid.Text = "KR11" + ctr;
            }
            else if (ctr >= 99)
            {
                ctr = ctr + 1;
                txtid.Text = "KR1" + ctr;
            }
            cmdAdd.Enabled = false;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            string Code;

            dt = exerciseKueDataSet.Tables["Karyawan"];
            dr = dt.NewRow();
            dr[0] = txtid.Text;
            dr[1] = txtnama.Text;
            dr[2] = txtemail.Text;
    
            dt.Rows.Add(dr);
            karyawanTableAdapter.Update(exerciseKueDataSet);
            txtid.Text = System.Convert.ToString(dr[0]);
            txtid.Enabled = false;
            txtnama.Enabled = false;
            txtemail.Enabled = false;
          
            this.karyawanTableAdapter.Fill(this.exerciseKueDataSet.Karyawan);
            cmdAdd.Enabled = true;
            cmdSave.Enabled = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            string Code;

            Code = txtid.Text;
            dr = exerciseKueDataSet.Tables["Karyawan"].Rows.Find(Code);
            dr.Delete();
            karyawanTableAdapter.Update(exerciseKueDataSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Menu().Show();
        }
    }
    
}
