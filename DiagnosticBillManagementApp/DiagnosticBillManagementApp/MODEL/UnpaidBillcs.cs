using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementApp.MODEL
{
    public class UnpaidBillcs
    {
        public int Id { get; set; }
        public int BillNumber { get; set; }
        public string ContactNo { get; set; }
        public double BillAmount { get; set; }
        public string PatientName { get; set; }

    }
}