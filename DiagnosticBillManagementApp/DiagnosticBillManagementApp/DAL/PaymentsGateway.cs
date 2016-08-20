using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.DAL
{
    public class PaymentsGateway
    {
        string connectionString = "Server=ASAD;Database=DiagnosticDB;Integrated Security=true";


        public int UpdateDateBill(int billNumber, double paidBill)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE t_testrequest SET PaidBill=PaidBill+'" + paidBill + "' WHERE BillNumber='" + billNumber + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }


        public List<Payments> GetAllTypeNameFee(int billNumber)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            string query = "SELECT TestName,Fee FROM ViewTestFeeByBillNo WHERE BillNumber='" + billNumber + "'";
            command.Connection = connection;
            command.CommandText = query;
            List<Payments> testTypes = new List<Payments>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 0;
                while (reader.Read())
                {
                    Payments aTestType = new Payments();
                    i++;
                    aTestType.Id = i;
                    aTestType.Test = reader["TestName"].ToString();
                    aTestType.Fee = Convert.ToDouble(reader["Fee"].ToString());
                    testTypes.Add(aTestType);
                }
                reader.Close();
            }
            else
            {
                testTypes = null;
            }
            connection.Close();
            return testTypes;


        }

        public PaymentsBills GetPaymentsInfo(int billNumber)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            string query = "SELECT Date, TotalBill, PaidBill FROM t_testrequest WHERE BillNumber='" + billNumber + "'";
            command.Connection = connection;
            command.CommandText = query;
            connection.Open();
            PaymentsBills aTestType = null;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {

                    aTestType = new PaymentsBills();
                    reader.Read();
                    
                    aTestType.BillDate= Convert.ToDateTime(reader["Date"].ToString());
                    aTestType.TotalFee = Convert.ToDouble(reader["TotalBill"].ToString());
                    aTestType.Amount = Convert.ToDouble(reader["PaidBill"].ToString());
                    
                
                reader.Close();
            }
            
            connection.Close();
            return aTestType;
        }
            
    }

}
