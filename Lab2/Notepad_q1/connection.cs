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



namespace Oracle_Connectivity
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
            conn = new OracleConnection("DATA SOURCE=172.16.54.24:1521/ictorcl;USER ID=IT188;PASSWORD=student");




            try
            {
                conn.Open();
                MessageBox.Show("Connection done \n");
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



       private void button1_Click(object sender, EventArgs e)
        {
            ConnectDB();
            comm = new OracleCommand();
            comm.CommandText = "select * from instructor";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_instructor");
            dt = ds.Tables["Tbl_instructor"];
            int t = dt.Rows.Count;



           MessageBox.Show(t.ToString());
            dr = dt.Rows[i];
            textBox1.Text = dr["id"].ToString();
            textBox2.Text = dr["name"].ToString();
            textBox3.Text = dr["deptname"].ToString();
            textBox4.Text = dr["salary"].ToString();
            conn.Close();
            
        }



       private void textBox3_TextChanged(object sender, EventArgs e)
        {



       }
    }
}
