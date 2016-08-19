using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementApp.MODEL
{
    public class TestSet
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public double Fee { get; set; }
        public int TypeNameId { get; set; }
        public string TypeName { get; set; }

    }
}