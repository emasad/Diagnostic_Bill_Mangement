using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticBillManagementApp.BLL;
using DiagnosticBillManagementApp.MODEL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

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
                    ViewState["PatientName"] = patientNameTextBox.Text;
                    ViewState["Date"] = dateBirthTextBox.Text;
                    ViewState["MobileNo"] = mobileNoTextBox.Text;
                    
                    aTestRequestManager.Save(aTestRequest);
                    
                    testRequestId=aTestRequestManager.GetTestRequestId();

                    billNumber = testRequestId + 10000;
                    ViewState["BillNumber"] = billNumber;
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
                    messageLabel.Text ="ID no "+testSetupId+" is insered.";
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
            LoadTestNameGridView();

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
            ViewState["Total"] = total;
            bool isUpaded= aTestRequestManager.UpdateDateBill(testRequestId, total, paidBill, today);
            if (isUpaded)
            {
                totalSaveLabel.Text = "All info Succesfully inserted.";
            }
            else
            {
                totalSaveLabel.Text = "Insertion is Fail.";
                
            }

            totalSaveLabel.Text = "All info Succesfully inserted.";

            GeneratePdf();

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
            ViewState["GridData"] = aTestTypes;

            showTestRequestGridView.DataBind();
        }

        public void GeneratePdf()
        {
            showTestRequestGridView.DataSource = (List<TestRequest>)ViewState["GridData"];

            List<TestRequest> aTypeWises = (List<TestRequest>)ViewState["GridData"];

            showTestRequestGridView.DataBind();
            int CoulmnCount = showTestRequestGridView.HeaderRow.Cells.Count;
            PdfPTable pdfPTable = new PdfPTable(CoulmnCount);


            foreach (TableCell tableCell in showTestRequestGridView.HeaderRow.Cells)
            {
                PdfPCell pdfPCell = new PdfPCell(new Phrase(tableCell.Text));
                pdfPCell.BackgroundColor = new BaseColor(showTestRequestGridView.BackColor);
                pdfPTable.AddCell(pdfPCell);
            }
            //foreach (GridViewRow gridViewRows in typeGridView.Rows)
            //{
            //    if(gridViewRows.RowType==DataControlRowType.DataRow)
            //    foreach (TableCell tableCells in gridViewRows.Cells)
            //    {
            //        PdfPCell pdfPCell = new PdfPCell(new Phrase(tableCells.Text));
            //        pdfPTable.AddCell(pdfPCell);
            //    }

            //}

            foreach (TestRequest aTestRequest in aTypeWises)
            {
                pdfPTable.AddCell(aTestRequest.Id.ToString());
                pdfPTable.AddCell(aTestRequest.Test);
                pdfPTable.AddCell(aTestRequest.Fee.ToString());
                

            }

            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            string expdate = Convert.ToString(DateTime.Now);
            Phrase expir = new Phrase("Time: " + expdate + "\n\n\n");

            pdfDocument.Add(expir);

            Paragraph par1 = new Paragraph("Patient Information");
            pdfDocument.Add(par1);

            Paragraph billNumber = new Paragraph("Bill Number: " + ViewState["BillNumber"] + "\n\n\n");
            pdfDocument.Add(billNumber);
            

            Paragraph name = new Paragraph("          Name of the Patient: " + ViewState["PatientName"]);
            pdfDocument.Add(name);
            Paragraph birthDay = new Paragraph("          Date of Birth: " + ViewState["Date"]);
            pdfDocument.Add(birthDay);
            Paragraph mobile = new Paragraph("          Mobile No: " + ViewState["MobileNo"]+"\n");
            pdfDocument.Add(mobile);


            Paragraph par2 = new Paragraph("Patient Selected Test\n\n");
            pdfDocument.Add(par2);

            pdfDocument.Add(pdfPTable);
            Paragraph total = new Paragraph("          Total Bill: " + ViewState["Total"]);
            pdfDocument.Add(total);
            //string total ="\n\n\nTotal Amount: "+ ViewState["Total"].ToString()+"\n";
            //Phrase total = new Phrase("\n\n\nTotal Amount: " + Convert.ToString(ViewState["Total"]) + "\n");
            //pdfDocument.Add(total);

            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=Test Request Entry.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }

        protected void testTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = 1;
        }
    }
}