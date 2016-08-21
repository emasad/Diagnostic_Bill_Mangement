using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.DAL
{
    public class UnpaidBillGateWay
    {

        string connectionString = "Server=ASAD;Database=DiagnosticDB;Integrated Security=true";
        
        public double GetTotalUnapidBill(DateTime fromDateTime, DateTime toDateTime)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            string query = "select sum(BillAmount) as TotalBill from(select (TotalBill-PaidBill) as BillAmount  from t_testrequest where (TotalBill-PaidBill)>0 AND Date between '"+fromDateTime+"' AND '"+toDateTime+"') as Test";
            command.Connection = connection;
            command.CommandText = query;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            double totalAmount = 0;
            if (reader.HasRows)
            {

                reader.Read();
                totalAmount = Convert.ToDouble(reader["TotalBill"].ToString());



                reader.Close();
            }

            connection.Close();
            return totalAmount;
        }

        public List<UnpaidBillcs> GetUnpaidBillcsessBill(DateTime fromDateTime, DateTime toDateTime)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            string query = "select BillNumber, MobileNo, PatientName, (TotalBill-PaidBill) as BillAmount  from t_testrequest where (TotalBill-PaidBill)>0 AND Date between '"+fromDateTime+"' AND '"+toDateTime+"' ";
            command.Connection = connection;
            command.CommandText = query;
            connection.Open();

            List<UnpaidBillcs> aTypeWiseList = new List<UnpaidBillcs>();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {

                int i = 0;
                while (reader.Read())
                {
                    UnpaidBillcs aUnpaidBillcs = new UnpaidBillcs();
                    i++;
                    aUnpaidBillcs.Id = i;
                    aUnpaidBillcs.BillNumber = int.Parse(reader["BillNumber"].ToString());

                    aUnpaidBillcs.ContactNo = reader["MobileNo"].ToString();
                    aUnpaidBillcs.PatientName =reader["PatientName"].ToString();
                    aUnpaidBillcs.BillAmount =Convert.ToDouble(reader["BillAmount"].ToString());

                    aTypeWiseList.Add(aUnpaidBillcs);
                }


                reader.Close();
            }

            connection.Close();
            return aTypeWiseList;
        }
    }


}
