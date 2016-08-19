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
    public partial class TestSetup : System.Web.UI.Page
    {
        TestTypeManager aTestTypeManager= new TestTypeManager();
        TestSetupManager aTestSetupManager= new TestSetupManager();
        TestType aTestType=new TestType();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTypeNameDropdown();
        }

        

        protected void saveButton_Click(object sender, EventArgs e)
        {

            TestSet aTestSet = new TestSet();

            if (testNameTextBox.Text=="" || feeTextBox.Text=="")
            {
                messageLabel.Text = "Please Fill All Field.";
                
                
            }
            else
            {

                aTestSet.TestName = testNameTextBox.Text;
                aTestSet.Fee = Convert.ToDouble(feeTextBox.Text);
                aTestSet.TypeNameId = Convert.ToInt32(testTypeDropDown.SelectedValue);

                if (aTestSetupManager.SearchTestNameByName(aTestSet.TestName))
                {
                    messageLabel.Text = "TestName Already Exists.";
                    

                }

                else
                {
                    aTestSetupManager.Save(aTestSet);
                    messageLabel.Text = "Successfully Inserted.";


                }

            }
            LoadTestTypeGridView();
            
        }


        private void LoadTypeNameDropdown()
        {
            List<TestType> aTestTypes = aTestTypeManager.GetAllTestTypes();
            testTypeDropDown.DataSource = aTestTypes;
            testTypeDropDown.DataValueField = "Id";
            testTypeDropDown.DataTextField = "TypeName";
            testTypeDropDown.DataBind();
        }


        private void LoadTestTypeGridView()
        {
            List<TestSet> aTestTypes = aTestSetupManager.GetAllTestNames();
            showTestInfoGridView.DataSource = aTestTypes;
            showTestInfoGridView.DataBind();
        }

    }
}