using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.DAL
{
    public class TestTypeGateway
    {
        string connectionString = "Server=ASAD;Database=DiagnosticDB;Integrated Security=true";

        public int Save(TestType aTestType)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_typename(TypeName) VALUES('" + aTestType.TypeName + "')";

            SqlCommand command= new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }

        public List<TestType> GetAllTestTestTypes()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT *FROM t_typename ORDER BY TypeName";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<TestType> testTypes= new List<TestType>();

            if (reader.HasRows)
            {
                int i = 0;
                while (reader.Read())
                {
                    TestType aTestType= new TestType();
                    i++;
                    aTestType.Id = i;
                    aTestType.TypeName = reader["TypeName"].ToString();
                    testTypes.Add(aTestType);
                }
                reader.Close();

            }
            connection.Close();
            return testTypes;
        }

        public bool GetTypeTestByTypeName(string typeName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT *FROM t_typename WHERE TypeName='"+typeName+"'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        



    }
}