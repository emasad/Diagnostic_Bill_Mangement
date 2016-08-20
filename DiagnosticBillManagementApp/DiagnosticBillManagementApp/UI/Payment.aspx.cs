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
    public partial class Payment : System.Web.UI.Page
    {
        private int billNumber;
        PaymentsBills aPayments = null;
        private double result = 0;
        private double dueNum = 0;
        PaymentsManager aPaymentsManager= new PaymentsManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {

            if (billNoTextBox.Text == "")
            {

                messageLabel.Text = "Please Fill Testbox.";
                return;

            }
            else
            {
                billNumber = Convert.ToInt32(billNoTextBox.Text);


                List<Payments> aTestTypes = aPaymentsManager.GetAllTypeNameFee(billNumber);
                if (aTestTypes == null)
                {
                    messageLabel.Text = "Please Enter Correct BillNumber.";
                    return;
                }
                else
                {
                    paymentGridView.DataSource = aTestTypes;
                    paymentGridView.DataBind();
                }

                aPayments = aPaymentsManager.GetPaymentsInfo(billNumber);

                billDateLabel.Text = (aPayments.BillDate).ToString();
                totalFeeLabel.Text = aPayments.TotalFee.ToString();
                paidAmountLabel.Text = aPayments.Amount.ToString();
                dueAmountLabel.Text = (aPayments.TotalFee - aPayments.Amount).ToString();
                
            }
           

            

        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            if (amountTextBox.Text == "" || billNoTextBox.Text == "")
            {
                messageLabel.Text = "Please Fill the Textbox.";
                return;
            }
            else
            {
                //double v;Double.TryParse(amountTextBox.Text.Trim(), out v) &&
                if ((Convert.ToDouble(totalFeeLabel.Text)-Convert.ToDouble(paidAmountLabel.Text)) > 0 )
                {

                    billNumber = Convert.ToInt32(billNoTextBox.Text);
                    //dueNum=Convert.ToDouble(amountTextBox.Text);
                    result = Convert.ToDouble(amountTextBox.Text);
                    if (aPaymentsManager.UpdateDateBill(billNumber, result))
                    {
                        messageLabel.Text = "Due is Reduced.";
                        
                    }
                    else
                    {
                        messageLabel.Text = "Due is not Reduced.";
                        
                    }
               }

                else if ((Convert.ToDouble(totalFeeLabel.Text) - Convert.ToDouble(paidAmountLabel.Text)) == 0)
                {
                    messageLabel.Text = "You have no due.";
                    
                }
                else
                {
                    messageLabel.Text = "Please Enter Numeric Values.";
                    
                }
            }

            amountTextBox.Text = "";
            billNoTextBox.Text = "";

            billDateLabel.Text = "";
            totalFeeLabel.Text = "";
            paidAmountLabel.Text ="";
            dueAmountLabel.Text = "";
        }


    }
}