using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticBillManagementApp.DAL;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.BLL
{
    public class TestWiseManager
    {
        TestWiseGateWay aTestWiseGateWay= new TestWiseGateWay();

        public List<TestWise> GetPaymentsInfo(DateTime fromDateTime, DateTime toDateTime)
        {
            return aTestWiseGateWay.GetPaymentsInfo(fromDateTime, toDateTime);
        }

        public double GetTotalAmount(DateTime fromDateTime, DateTime toDateTime)
        {
            double result = aTestWiseGateWay.GetTotalAmount(fromDateTime, toDateTime);
            return result;
        }

    }
}