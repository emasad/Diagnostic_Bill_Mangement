using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace DiagnosticBillManagementApp.MODEL
{
    public class TestRequest
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public int  BillNumber { get; set; }
        public DateTime CurrentDate { get; set; }
        public double  PaidBill { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}