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
    public partial class TestTypeSetup : System.Web.UI.Page
    {

        TestTypeManager aTestTypeManager= new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTestTypeGridView();


        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            TestType aTestType = new TestType();

            if (typeNameTextBox.Text=="" || typeNameTextBox.Text==" ")
            {
                messgaeLabel.Text = "Please Enter Test Type";
            }
            else
            {
                aTestType.TypeName = typeNameTextBox.Text;
                if (aTestTypeManager.SearchTestByTypeName(aTestType.TypeName))
                {
                    messgaeLabel.Text = aTestType.TypeName+", already exists in DB. Please Enter Another Type.";
                    
                }
                else
                {
                    aTestTypeManager.Save(aTestType);
                    messgaeLabel.Text = "Successfully Inseted "+aTestType.TypeName;

                }
            }

        }


        private void LoadTestTypeGridView()
        {
            List<TestType> aTestTypes = aTestTypeManager.GetAllTestTypes();
            showTypeNameGridView.DataSource = aTestTypes;
            showTypeNameGridView.DataBind();
        }
    }
}