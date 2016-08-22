using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementApp.MODEL
{[Serializable]
    
    public class TypeWise
    {
        public int Id { get; set; }
        public string TestTypeName { get; set; }
        public int TotalNoOfTest { get; set; }
        public double TotalAmount { get; set; }

    }
}