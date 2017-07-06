using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string db = "dp2";
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString =
            "Data Source =serversql;" +
            "Initial Catalog=dp2;" +
            "Integrated Security=SSPI;";
            //"connection timeout=30");
            //ConnectionState.Open();
            try
            {
                Conn.Open();
                MessageBox.Show("You bet your ass it did" + Environment.NewLine + db, "Did database1 connect?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("You failed!", "Title" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //make connection to new server IP
            //$hostName = "184.168.194.58";
            // $connectionInfo = array("Database"=>"OLP", "UID"=>"OLPUser", "PWD"=>"Snoopy#09*Dog");
            //  $conn2 = sqlsrv_connect($hostName, $connectionInfo) or die (print_r(sqlsrv_errors(), true));
            string db = "OLP";
            SqlConnection Conn2 = new SqlConnection();
            Conn2.ConnectionString =
            "Data Source =184.168.194.58;" +
            "Initial Catalog=OLP;" +
            "User id=OLPUser;" +
            "Password=Snoopy#09*Dog;";
            try
            {
                Conn2.Open();
                MessageBox.Show("You bet your ass it did" + Environment.NewLine + db, "Did database2 connect?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("You failed!" + ex.Message, "Title");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string db = "local-dp2copy";
            SqlConnection Conn2 = new SqlConnection();
            Conn2.ConnectionString =
            "Data Source = BLAIR-SURF-P4\\SQLEXPRESS;" +
            "Initial Catalog=dp2copy;" +
            "Integrated Security=SSPI;";
            try
            {
                Conn2.Open();
                MessageBox.Show("You betbet your ass it did" + Environment.NewLine + db, "Did database2 connect?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("You failed!" + ex.Message, "Title");
            }
        }
    }
}
