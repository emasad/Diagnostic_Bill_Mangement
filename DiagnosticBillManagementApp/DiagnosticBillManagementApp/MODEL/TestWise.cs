using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementApp.MODEL
{
    public class TestWise
    {

        public int Id { get; set; }
        public string TestName { get; set; }
        public int TotalTest { get; set; }
        public double TotalAmount { get; set; }
        public double SumAllAmount { get; set; }

    }
}