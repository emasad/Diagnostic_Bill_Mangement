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
    public partial class TestRequestEntry : System.Web.UI.Page
    {
        TestRequest aTestRequest= new TestRequest();
        public int billNumber=0;
        private int testRequestId;
        private int testSetupId;
        private double Sum=0;
        private double lastItem=0;
        private double total = 0;
        TestRequestManager aTestRequestManager= new TestRequestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                LoadTestNameDropdown();

            }

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (ViewState["Id"] == null)
            {

                if (patientNameTextBox.Text == "" || mobileNoTextBox.Text == "" || dateBirthTextBox.Text=="")
                {
                    messageLabel.Text = "Please Fill All Textbox.";

                }
                else
                {
                    aTestRequest.PatientName = patientNameTextBox.Text;
                    aTestRequest.DateOfBirth = Convert.ToDateTime(dateBirthTextBox.Text);
                    aTestRequest.MobileNo = mobileNoTextBox.Text;
                    
                    
                    aTestRequestManager.Save(aTestRequest);
                    
                    testRequestId=aTestRequestManager.GetTestRequestId();

                    billNumber = testRequestId + 10000;
                    aTestRequestManager.SaveBillNumber(testRequestId, billNumber.ToString());

                    testSetupId = Convert.ToInt32(testTypeDropDown.SelectedValue);

                    if (aTestRequestManager.SetRelations(testRequestId, testSetupId))
                    {
                        messageLabel.Text = "ID no "+testSetupId+" is inseted.";
                    }
                    else
                    {
                        messageLabel.Text = "Fail.";
                    }

                    LoadTestNameGridView();
                    

                    ViewState["Id"] = testRequestId;

                }
                


            }

            else
            {
                testRequestId = aTestRequestManager.GetTestRequestId();
                testSetupId = Convert.ToInt32(testTypeDropDown.SelectedValue);

                if (aTestRequestManager.SetRelations(testRequestId, testSetupId))
                {
                    messageLabel.Text ="ID no "+testSetupId+"is insered.";
                }
                else
                {
                    messageLabel.Text = "Fail.";
                }
                LoadTestNameGridView();
                
            }
            List<TestRequest> aTestTypes = aTestRequestManager.GetAllTypeNameFee(testRequestId);

            total = aTestTypes.Sum(item => item.Fee);
            testRequestTotalTextBox.Text = total.ToString();
            feeTextBox.Text = aTestTypes.Last().Fee.ToString();

        }

        private void LoadTestNameDropdown()
        {
            List<TestSet> aTestSets = aTestRequestManager.GetAllTestName();
            testTypeDropDown.DataSource = aTestSets;
            testTypeDropDown.DataValueField = "TestId";
            testTypeDropDown.DataTextField = "TestName";
            testTypeDropDown.DataBind();
        }

        protected void totalSaveButton_Click(object sender, EventArgs e)
        {
            
            //double result = aTestRequestManager.TotalFee(testRequestId);
            testRequestId = aTestRequestManager.GetTestRequestId();

            DateTime today = DateTime.Today;
            double paidBill = 0;

            List<TestRequest> aTestTypes = aTestRequestManager.GetAllTypeNameFee(testRequestId);

            total = aTestTypes.Sum(item => item.Fee);

            bool isUpaded= aTestRequestManager.UpdateDateBill(testRequestId, total, paidBill, today);
            if (isUpaded)
            {
                totalSaveLabel.Text = "All info Succesfully inserted.";
            }
            else
            {
                totalSaveLabel.Text = "Insertion is Fail.";
                
            }
            ViewState["Id"] = null;
            patientNameTextBox.Text="";
            dateBirthTextBox.Text = "";
            mobileNoTextBox.Text="";
            showTestRequestGridView.DataSource = null;
            showTestRequestGridView.DataBind();


        }

        private void LoadTestNameGridView()
        {
            List<TestRequest> aTestTypes = aTestRequestManager.GetAllTypeNameFee(testRequestId);
            showTestRequestGridView.DataSource = aTestTypes;
            showTestRequestGridView.DataBind();
        }
    }
}