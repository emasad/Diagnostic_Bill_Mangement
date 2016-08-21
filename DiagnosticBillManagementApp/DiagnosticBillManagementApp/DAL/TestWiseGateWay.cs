using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.DAL
{
    public class TestWiseGateWay
    {
        string connectionString = "Server=ASAD;Database=DiagnosticDB;Integrated Security=true";

        public double GetTotalAmount(DateTime fromDateTime, DateTime toDateTime)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            string query = "select sum(Fees) as Total from(select Sum(Fee) as Fees from ViewTestWiseReport where Date >= '" + fromDateTime + "' AND Date <='" + toDateTime + "' group by TestName) as Test";
            command.Connection = connection;
            command.CommandText = query;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            double totalAmount = 0;
            if (reader.HasRows)
            {

                reader.Read();
                totalAmount = Convert.ToDouble(reader["Total"].ToString());
                


                reader.Close();
            }

            connection.Close();
            return totalAmount;
        }

        public List<TestWise> GetPaymentsInfo(DateTime fromDateTime, DateTime toDateTime)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            string query = "select TestName, Count(TestName) As Total, Sum(Fee) as Fee from ViewTestWiseReport where Date >= '" + fromDateTime + "' AND Date <='" + toDateTime + "' group by TestName  ";
            command.Connection = connection;
            command.CommandText = query;
            connection.Open();

            List<TestWise> aTestWiseList=new List<TestWise>();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {

                int i = 0;
                while (reader.Read())
                {
                    TestWise aTestWise =new TestWise();
                    i++;
                    aTestWise.Id = i;
                    aTestWise.TestName = reader["TestName"].ToString();
                    
                    aTestWise.TotalTest = Convert.ToInt32(reader["Total"].ToString());
                    aTestWise.TotalAmount = Convert.ToDouble(reader["Fee"].ToString());
                    aTestWiseList.Add(aTestWise);
                }


                reader.Close();
            }

            connection.Close();
            return aTestWiseList;
        }
    }
}