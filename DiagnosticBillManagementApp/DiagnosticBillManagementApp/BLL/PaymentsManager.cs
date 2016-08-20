using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticBillManagementApp.DAL;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.BLL
{
    public class PaymentsManager
    {
        PaymentsGateway aPaymentsGateway= new PaymentsGateway();

        public bool UpdateDateBill(int billNumber, double paidBill)
        {
            bool isUpdate = aPaymentsGateway.UpdateDateBill(billNumber, paidBill) > 0;
            return isUpdate;
        }

        public PaymentsBills GetPaymentsInfo(int billNumber)
        {
            return aPaymentsGateway.GetPaymentsInfo(billNumber);
        }
        
        
        public List<Payments> GetAllTypeNameFee(int billNumber)
        {
            return aPaymentsGateway.GetAllTypeNameFee(billNumber);
        }

    }
}