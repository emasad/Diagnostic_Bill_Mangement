using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.DAL
{
    public class TypeWiseGateWay
    {
        string connectionString = "Server=ASAD;Database=DiagnosticDB;Integrated Security=true";

        public double GetTotalAmountOfTypes(DateTime fromDateTime, DateTime toDateTime)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            string query = "select Sum(Fees) as Total from(select Sum(Fee) as Fees from ViewTypeWiseReports  where Date >= '" + fromDateTime + "' AND Date <='" + toDateTime + "' group by TypeName) as Test";
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

        public List<TypeWise> GetPaymentsInfoTypesWises(DateTime fromDateTime, DateTime toDateTime)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            string query = "select TypeName, Count(TypeName) as TotalTest, Sum(Fee) as TotalAmount from ViewTypeWiseReports  where Date >= '" + fromDateTime + "' AND Date <='" + toDateTime + "' group by TypeName  ";
            command.Connection = connection;
            command.CommandText = query;
            connection.Open();

            List<TypeWise> aTypeWiseList = new List<TypeWise>();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {

                int i = 0;
                while (reader.Read())
                {
                    TypeWise aTypeWise = new TypeWise();
                    i++;
                    aTypeWise.Id = i;
                    aTypeWise.TestTypeName = reader["TypeName"].ToString();

                    aTypeWise.TotalNoOfTest = Convert.ToInt32(reader["TotalTest"].ToString());
                    aTypeWise.TotalAmount = Convert.ToDouble(reader["TotalAmount"].ToString());
                    aTypeWiseList.Add(aTypeWise);
                }


                reader.Close();
            }

            connection.Close();
            return aTypeWiseList;
        }
    }
}