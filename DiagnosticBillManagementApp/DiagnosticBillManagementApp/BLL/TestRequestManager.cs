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

        //public double TotalFee(int id)
        //{
        //    double result = aTestRequestGateway.TotalFee(id);
        //    return result;
        //}
        public bool UpdateDateBill(int id, double totalBill, double paidBill, DateTime aDateTime)
        {
            bool isUpdate = aTestRequestGateway.UpdateDateBill(id, totalBill, paidBill, aDateTime) > 0;
            return isUpdate;
        }

        public List<TestRequest> GetAllTypeNameFee(int testSetupId)
        {
            return aTestRequestGateway.GetAllTypeNameFee(testSetupId);
        }

        public bool SaveBillNumber(int id, string billNumber)
        {
            bool isSaved = aTestRequestGateway.SaveBillNumber(id, billNumber) > 0;
            return isSaved;
        }

         
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