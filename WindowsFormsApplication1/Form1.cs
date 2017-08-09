using System;
using System.Collections.Generic;
using System.Collections;
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

            using(SqlConnection Conn = new SqlConnection()){

            Conn.ConnectionString =
            "Data Source =serversql;" +
            "Initial Catalog=dp2;" +
            "User id=riley;" +
            "Password=riley455;";
                //"Integrated Security=SSPI;";
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //make connection to new server IP
            //$hostName = "184.168.194.58";
            // $connectionInfo = array("Database"=>"OLP", "UID"=>"OLPUser", "PWD"=>"Snoopy#09*Dog");
            //  $conn2 = sqlsrv_connect($hostName, $connectionInfo) or die (print_r(sqlsrv_errors(), true));
            string db = "OLP";
            ArrayList columnsList = new ArrayList(); //arraylist to hold names of columns in SQL table
            ArrayList valuesList = new ArrayList(); //arraylist to hold values in SQL table
            using(SqlConnection Conn2 = new SqlConnection()){
            Conn2.ConnectionString =
            "Data Source =184.168.194.58;" +
            "Initial Catalog= OLP;" +
            "User id=OLPUser;" +
            "Password=Snoopy#09*Dog;";
            try
            {
                
                Conn2.Open();

                //Read columns names from the database into arraylist
                SqlCommand command = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME LIKE 'TFLOrders'", Conn2);
                SqlDataReader dataReader = command.ExecuteReader(); 
                while (dataReader.Read())
                {
                            columnsList.Add(dataReader[0].ToString());
                } //add column names from table into arraylist named columnslist
                dataReader.Close();
                
                //read table data into arraylist
                command = new SqlCommand("SELECT * FROM TFLOrders", Conn2);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                            for(int i = 0;i<columnsList.Count;i++)
                                valuesList.Add(dataReader[i].ToString());
                } //read data values from table into arraylist named values list
                dataReader.Close();


                    MessageBox.Show("You bet your ass it did" + Environment.NewLine + valuesList, "Did database2 connect?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    //MessageBox.Show("You bet your ass it did" + Environment.NewLine + db, "Did database2 connect?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            catch (SqlException ex)
            {
                MessageBox.Show("You failed!" + ex.Message, "Title");
            }
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
        private static void ReadSingleRow(IDataRecord record)
        {

            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
