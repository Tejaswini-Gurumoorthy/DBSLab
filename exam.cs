using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace WindowsFormsApplication11
{
    public partial class Form1 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;

        public void ConnectDB()
        {
            conn= new OracleConnection("DATA SOURCE=172.16.54.24:1521/ictorcl;USER ID=IT202;PASSWORD=student");
            try
            {
                conn.Open();
                MessageBox.Show("Connection Done\n");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            ConnectDB();
            comm = new OracleCommand();
            comm.CommandText = "select * from student";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Student");
            dt = ds.Tables["Student"];
            int t = dt.Rows.Count;

            MessageBox.Show(t.ToString());
                dr = dt.Rows[i];
                textBox1.Text = dr["regno"].ToString();
                textBox2.Text = dr["name"].ToString();
                textBox3.Text = dr["major"].ToString();
                textBox4.Text = dr["bdate"].ToString();
            //conn.Close();


        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            i++;
            if (i > dt.Rows.Count)
                i = 0;
            dr = dt.Rows[i];
            textBox1.Text = dr["regno"].ToString();
            textBox2.Text = dr["name"].ToString();
            textBox3.Text = dr["major"].ToString();
            textBox4.Text = dr["bdate"].ToString();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            i--;
            if (i < 0)
                i = dt.Rows.Count;
            dr = dt.Rows[i];
            textBox1.Text = dr["regno"].ToString();
            textBox2.Text = dr["name"].ToString();
            textBox3.Text = dr["major"].ToString();
            textBox4.Text = dr["bdate"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDB();
            int regno = int.Parse(textBox1.Text);
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            cm.CommandText = "insert into student values(textBox1.Text, textBox2.Text , textBox3.Text )";
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();
            MessageBox.Show("Inserted!");
            conn.Close();

        }
    }
}
