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
                        ViewState["GridData"] = aTestWises;

                        ViewState["Total"] = testTotalTextBox.Text;

                    }
                    
                }
               


            }



        }

        protected void testPdfButton_Click(object sender, EventArgs e)
        {
            GeneratePdf();

        }

        public void GeneratePdf()
        {
            testGridView.DataSource = (List<TestWise>)ViewState["GridData"];

            List<TestWise> aTypeWises = (List<TestWise>)ViewState["GridData"];

            testGridView.DataBind();
            int CoulmnCount = testGridView.HeaderRow.Cells.Count;
            PdfPTable pdfPTable = new PdfPTable(CoulmnCount);


            foreach (TableCell tableCell in testGridView.HeaderRow.Cells)
            {
                PdfPCell pdfPCell = new PdfPCell(new Phrase(tableCell.Text));
                pdfPCell.BackgroundColor = new BaseColor(testGridView.BackColor);
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

            foreach (TestWise aTestWise in aTypeWises)
            {
                pdfPTable.AddCell(aTestWise.Id.ToString());
                pdfPTable.AddCell(aTestWise.TestName);
                pdfPTable.AddCell(aTestWise.TotalTest.ToString());
                pdfPTable.AddCell(aTestWise.TotalAmount.ToString());

            }

            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            string expdate = Convert.ToString(DateTime.Now);
            Phrase expir = new Phrase("Time: " + expdate + "\n\n\n");

            pdfDocument.Add(expir);

            Paragraph par1 = new Paragraph("Test Wise Report\n\n\n");
            pdfDocument.Add(par1);


            pdfDocument.Add(pdfPTable);

            //string total ="\n\n\nTotal Amount: "+ ViewState["Total"].ToString()+"\n";
            Phrase total = new Phrase("\n\n\nTotal : " + Convert.ToString(ViewState["Total"]) + "\n");
            pdfDocument.Add(total);

            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=Test Wise Report.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
    }
}