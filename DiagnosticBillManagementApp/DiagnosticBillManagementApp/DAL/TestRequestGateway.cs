﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.DAL
{
    public class TestRequestGateway
    {

        string connectionString = "Server=ASAD;Database=DiagnosticDB;Integrated Security=true";

        public List<TestSet> GetAllTestName()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            string query = "SELECT Id, TestName FROM t_testsetup";
            command.Connection = connection;
            command.CommandText = query;
            List<TestSet> testTypes = new List<TestSet>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestSet aTestSet = new TestSet();
                    aTestSet.TestId = int.Parse(reader["Id"].ToString());
                    aTestSet.TestName = reader["TestName"].ToString();


                    testTypes.Add(aTestSet);
                }
                reader.Close();
            }
            connection.Close();
            return testTypes;
        }

        public int Save(TestRequest aTestRequest)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_testrequest(PatientName, MobileNo, DateOfBirth) VALUES('" +aTestRequest.PatientName + "', '" + aTestRequest.MobileNo + "', '" + aTestRequest.DateOfBirth +
                           "')";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }

        public int SetRelations(int tRequest, int tSetup)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_requestsetup(TestRequestId,TestSetupId) VALUES('" + tRequest + "', '" + tSetup +
                           "')";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }

        public int GetTestRequestId()
        {
            int id = 0;
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT TOP 1 Id FROM t_testrequest ORDER BY Id DESC";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                reader.Read();
                id = int.Parse(reader["Id"].ToString());
                reader.Close();

            }
            connection.Close();
            return id;
        }


    }
}