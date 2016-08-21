using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticBillManagementApp.BLL;
using DiagnosticBillManagementApp.MODEL;

namespace DiagnosticBillManagementApp.UI
{
    public partial class TypeWiseReport : System.Web.UI.Page
    {
        TypeWiseManager aTypeWiseManager= new TypeWiseManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void typeShowButton_Click(object sender, EventArgs e)
        {
            if (typeFromDateTextBox.Text == "" || typeFromDateTextBox.Text == "")
            {
                messageLabel.Text = "Please Fill Both Box.";
            }
            else
            {
                DateTime fromDateTime = Convert.ToDateTime(typeFromDateTextBox.Text);
                DateTime toDateTime = Convert.ToDateTime(typeToDateTextBox.Text);

                if (fromDateTime >= toDateTime)
                {
                    messageLabel.Text = "Please Select Both Dates Correct formate.";


                }

                else
                {

                    List<TypeWise> aTypeWises = aTypeWiseManager.GetPaymentsInfoTypesWises(fromDateTime, toDateTime);

                    if (aTypeWises == null)
                    {
                        messageLabel.Text = "You have no data between these dates.";

                    }

                    else
                    {
                        typeGridView.DataSource = aTypeWises;
                        typeGridView.DataBind();

                        typeTotalTextBox.Text = aTypeWiseManager.GetTotalAmountOfTypes(fromDateTime, toDateTime).ToString();


                    }

                }



            }



        }

        protected void typePdfButton_Click(object sender, EventArgs e)
        {

        }
    }
}