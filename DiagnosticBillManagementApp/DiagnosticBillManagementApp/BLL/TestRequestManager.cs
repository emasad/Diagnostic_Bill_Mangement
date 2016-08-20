using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticBillManagementApp.DAL;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.BLL
{
    public class TestRequestManager
    {
        TestRequestGateway aTestRequestGateway= new TestRequestGateway();
        
         
        public List<TestSet> GetAllTestName()
        {
            return aTestRequestGateway.GetAllTestName();
        }


        public bool Save(TestRequest aTestRequest)
        {
            bool isSaved = aTestRequestGateway.Save(aTestRequest) > 0;
            return isSaved;

        }

        public int GetTestRequestId()
        {
            return aTestRequestGateway.GetTestRequestId();
        }

        public bool SetRelations(int tRequest, int tSetup)
        {
            bool saveStatus = aTestRequestGateway.SetRelations(tRequest, tSetup) > 0;
            return saveStatus;
        }
    }
}