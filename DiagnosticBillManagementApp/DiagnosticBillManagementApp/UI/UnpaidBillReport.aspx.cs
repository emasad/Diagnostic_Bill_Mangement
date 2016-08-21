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
    public partial class UnpaidBillReport : System.Web.UI.Page
    {
        UnpaidBillManager aUnpaidBillManager = new UnpaidBillManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void billShowButton_Click(object sender, EventArgs e)
        {
            if (billFromDateTextBox.Text == "" || billToDateTextBox.Text == "")
            {
                messageLabel.Text = "Please Fill Both.";
            }
            else
            {
                DateTime fromDateTime = Convert.ToDateTime(billFromDateTextBox.Text);
                DateTime toDateTime = Convert.ToDateTime(billToDateTextBox.Text);

                if (fromDateTime >= toDateTime)
                {
                    messageLabel.Text = "Please Select Both Dates Correct formate.";


                }

                else
                {
                    List<UnpaidBillcs> aTestWises = aUnpaidBillManager.GetUnpaidBillcsessBill(fromDateTime, toDateTime);

                    if (aTestWises == null)
                    {
                        messageLabel.Text = "You have no data between these dates.";

                    }

                    else
                    {
                        billGridView.DataSource = aTestWises;
                        billGridView.DataBind();

                        billTotalTextBox.Text = aUnpaidBillManager.GetTotalUnapidBill(fromDateTime, toDateTime).ToString();


                    }

                }



            }



        }

        protected void billPdfButton_Click(object sender, EventArgs e)
        {

        }

        protected void billToDateTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}