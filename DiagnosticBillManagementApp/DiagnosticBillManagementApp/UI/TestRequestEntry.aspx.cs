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
        public int i = 0;
        private int testRequestId;
        private int testSetupId;
        TestRequestManager aTestRequestManager= new TestRequestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    patientNameTextBox.Text = aTestRequest.PatientName;
            //    dateBirthTextBox.Text = aTestRequest.DateOfBirth.ToString();
            //    mobileNoTextBox.Text = aTestRequest.MobileNo;
            //}

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
                    testSetupId = Convert.ToInt32(testTypeDropDown.SelectedValue);

                    if (aTestRequestManager.SetRelations(testRequestId, testSetupId))
                    {
                        messageLabel.Text = "Saved.";
                    }
                    else
                    {
                        messageLabel.Text = "Fail.";
                    }


                    ViewState["Id"] = testRequestId;

                }
                


            }

            else
            {
                testRequestId = aTestRequestManager.GetTestRequestId();
                testSetupId = Convert.ToInt32(testTypeDropDown.SelectedValue);

                if (aTestRequestManager.SetRelations(testRequestId, testSetupId))
                {
                    messageLabel.Text = "Saved.";
                }
                else
                {
                    messageLabel.Text = "Fail.";
                }
            }
            

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

        }
    }
}