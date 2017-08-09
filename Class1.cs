using System;
using System.Data;
using System.Data.SqlClient;


class Program
{
    static void Main()
    {
        string connectdp2 = "Data Source =serversql;" +
            "Initial Catalog=dp2;" +
            "User id=riley;" +
            "Password=riley455;";
        string connectOLP = "Data Source =184.168.194.58;" +
            "Initial Catalog= OLP;" +
            "User id=OLPUser;" +
            "Password=Snoopy#09*Dog;";
        ReadOrderData(str);
        string queryString =
            "SELECT *  FROM dbo.Orders;";
    }

    private static void ReadOrderData(string connectionString,string queryString)
    {
        ;

        using (SqlConnection connection =
                   new SqlConnection(connectionString))
        {
            SqlCommand command =
                new SqlCommand(queryString, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            // Call Close when done reading.
            reader.Close();
        }
    }

    private static void ReadSingleRow(IDataRecord record)
    {
        Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
    }

}