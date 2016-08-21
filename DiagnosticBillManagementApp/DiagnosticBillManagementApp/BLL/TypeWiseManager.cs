using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticBillManagementApp.DAL;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.BLL
{
    public class TypeWiseManager
    {
        TypeWiseGateWay aTypeWiseGateWay= new TypeWiseGateWay();

        public List<TypeWise> GetPaymentsInfoTypesWises(DateTime fromDateTime, DateTime toDateTime)
        {
            return aTypeWiseGateWay.GetPaymentsInfoTypesWises(fromDateTime, toDateTime);
        }

        public double GetTotalAmountOfTypes(DateTime fromDateTime, DateTime toDateTime)
        {
            return aTypeWiseGateWay.GetTotalAmountOfTypes(fromDateTime, toDateTime);
        }
    }
}