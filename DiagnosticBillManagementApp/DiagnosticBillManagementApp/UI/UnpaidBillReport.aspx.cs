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
                        ViewState["GridData"] = aTestWises;

                        ViewState["Total"] = billTotalTextBox.Text;

                    }

                }



            }



        }

        protected void billPdfButton_Click(object sender, EventArgs e)
        {
            GeneratePdf();

        }


        public void GeneratePdf()
        {
            billGridView.DataSource = (List<UnpaidBillcs>)ViewState["GridData"];

            List<UnpaidBillcs> aTypeWises = (List<UnpaidBillcs>)ViewState["GridData"];

            billGridView.DataBind();
            int CoulmnCount = billGridView.HeaderRow.Cells.Count;
            PdfPTable pdfPTable = new PdfPTable(CoulmnCount);


            foreach (TableCell tableCell in billGridView.HeaderRow.Cells)
            {
                PdfPCell pdfPCell = new PdfPCell(new Phrase(tableCell.Text));
                pdfPCell.BackgroundColor = new BaseColor(billGridView.BackColor);
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

            foreach (UnpaidBillcs aTestWise in aTypeWises)
            {
                pdfPTable.AddCell(aTestWise.Id.ToString());
                pdfPTable.AddCell(aTestWise.BillNumber.ToString());
                pdfPTable.AddCell(aTestWise.ContactNo);
                pdfPTable.AddCell(aTestWise.PatientName);
                pdfPTable.AddCell(aTestWise.BillAmount.ToString());


            }

            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            string expdate = Convert.ToString(DateTime.Now);
            Phrase expir = new Phrase("Time: " + expdate + "\n\n\n");

            pdfDocument.Add(expir);

            Paragraph par1 = new Paragraph("Unpaid Bill Reports\n\n\n");
            pdfDocument.Add(par1);


            pdfDocument.Add(pdfPTable);

            //string total ="\n\n\nTotal Amount: "+ ViewState["Total"].ToString()+"\n";
            Phrase total = new Phrase("\n\n\nTotal : " + Convert.ToString(ViewState["Total"]) + "\n");
            pdfDocument.Add(total);

            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=Unpaid Bill Reports.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }




        
    }
}