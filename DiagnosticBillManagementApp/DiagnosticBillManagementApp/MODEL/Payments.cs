using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementApp.MODEL
{
    public class Payments
    {
        public int Id { get; set; }
        public int BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public double TotalFee { get; set; }
        public double PaidAmount { get; set; }
        public double Due { get; set; }
        public double Amount { get; set; }
        public string Test { get; set; }
        public double Fee { get; set; }
    }
}