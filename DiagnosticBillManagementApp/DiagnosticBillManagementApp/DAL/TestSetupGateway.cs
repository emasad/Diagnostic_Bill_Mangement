using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.DAL
{
    public class TestSetupGateway
    {
        string connectionString = "Server=ASAD;Database=DiagnosticDB;Integrated Security=true";

        public List<TestType> GetAllTypeName()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            string query = "SELECT *FROM t_typename";
            command.Connection = connection;
            command.CommandText = query;
            List<TestType> testTypes = new List<TestType>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestType aTestType  = new TestType();
                    aTestType.Id = int.Parse(reader["Id"].ToString());
                    aTestType.TypeName = reader["TypeName"].ToString();


                    testTypes.Add(aTestType);
                }
                reader.Close();
            }
            connection.Close();
            return testTypes;


        }

        public int Save(TestSet aTestType)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_testsetup(TestName, Fee, TestTypeId) VALUES('" + aTestType.TestName + "', '" + aTestType.Fee + "', '" + aTestType.TypeNameId + "')";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }

        public bool GetTestNameByName(string testName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT *FROM t_testsetup WHERE TestName='" + testName + "'";
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

        public List<TestSet> GetAllTestNames()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT *FROM ViewTestSetupWithTypeName ORDER BY TestName";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<TestSet> testTypes = new List<TestSet>();

            if (reader.HasRows)
            {
                int i = 0;
                while (reader.Read())
                {
                    TestSet aTestSet = new TestSet();
                    i++;
                    aTestSet.TestId = i;
                    aTestSet.TestName = reader["TestName"].ToString();
                    aTestSet.Fee = Convert.ToDouble(reader["Fee"]);
                    aTestSet.TypeName = reader["TypeName"].ToString();
                    testTypes.Add(aTestSet);
                }
                reader.Close();

            }
            connection.Close();
            return testTypes;
        }


    }
}