using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticBillManagementApp.DAL;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.BLL
{
    public class TestSetupManager
    {
        TestSetupGateway aTestSetupGateway= new TestSetupGateway();

        public List<TestType> GetAllTypeName()
        {
            return aTestSetupGateway.GetAllTypeName();
        }

        public bool Save(TestSet aTestType)
        {
            bool isSaved = aTestSetupGateway.Save(aTestType)>0;
            return isSaved;

        }

        public bool SearchTestNameByName(string testName)
        {
            return aTestSetupGateway.GetTestNameByName(testName);
        }

        public List<TestSet> GetAllTestNames()
        {
            return aTestSetupGateway.GetAllTestNames();
        }

    }
}