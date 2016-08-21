using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticBillManagementApp.DAL;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.BLL
{
    public class UnpaidBillManager
    {
        UnpaidBillGateWay aUnpaidBillGateWay = new UnpaidBillGateWay();

        public double GetTotalUnapidBill(DateTime fromDateTime, DateTime toDateTime)
        {
            return aUnpaidBillGateWay.GetTotalUnapidBill(fromDateTime, toDateTime);
        }

        public List<UnpaidBillcs> GetUnpaidBillcsessBill(DateTime fromDateTime, DateTime toDateTime)
        {
            return aUnpaidBillGateWay.GetUnpaidBillcsessBill(fromDateTime, toDateTime);
        }
    }
}