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
    public partial class TestWiseReport : System.Web.UI.Page
    {
        TestWiseManager aTestWiseManager= new TestWiseManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void testShowButton_Click(object sender, EventArgs e)
        {
            if (testFromDateTextBox.Text == "" || testToDateTextBox.Text == "" )
            {
                messageLabel.Text = "Please Fill Both.";
            }
            else
            {
                DateTime fromDateTime = Convert.ToDateTime(testFromDateTextBox.Text);
                DateTime toDateTime = Convert.ToDateTime(testToDateTextBox.Text);

                if (fromDateTime >= toDateTime)
                {
                    messageLabel.Text = "Please Select Both Dates Correct formate.";
                    

                }

                else
                {
                    List<TestWise> aTestWises = aTestWiseManager.GetPaymentsInfo(fromDateTime, toDateTime);

                    if (aTestWises == null)
                    {
                        messageLabel.Text = "You have no data between these dates.";

                    }

                    else
                    {
                        testGridView.DataSource = aTestWises;
                        testGridView.DataBind();

                        testTotalTextBox.Text = aTestWiseManager.GetTotalAmount(fromDateTime, toDateTime).ToString();


                    }
                    
                }
               


            }



        }

        protected void testPdfButton_Click(object sender, EventArgs e)
        {

        }
    }
}