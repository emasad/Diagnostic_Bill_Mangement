using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticBillManagementApp.DAL;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.BLL
{
    public class TestTypeManager
    {
        TestTypeGateway aTestTypeGateway = new TestTypeGateway();

        public bool Save(TestType aTestType)
        {
            bool isSaved = aTestTypeGateway.Save(aTestType)>0;
            return isSaved;
        }

        public List<TestType> GetAllTestTypes()
        {
            return aTestTypeGateway.GetAllTestTestTypes();

        }

        public bool SearchTestByTypeName(string typeName)
        {
            return aTestTypeGateway.GetTypeTestByTypeName(typeName);
        }



    }
}