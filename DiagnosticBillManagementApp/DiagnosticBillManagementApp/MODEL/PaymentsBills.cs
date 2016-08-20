using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementApp.MODEL
{
    public class PaymentsBills
    {
        public DateTime BillDate { get; set; }
        public double TotalFee { get; set; }
        public double Amount { get; set; }
    }
}