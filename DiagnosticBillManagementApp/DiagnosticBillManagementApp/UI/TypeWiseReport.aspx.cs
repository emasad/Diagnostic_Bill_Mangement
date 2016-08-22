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
    public partial class TypeWiseReport : System.Web.UI.Page
    {
        TypeWiseManager aTypeWiseManager= new TypeWiseManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void typeShowButton_Click(object sender, EventArgs e)
        {
            if (typeFromDateTextBox.Text == "" || typeFromDateTextBox.Text == "")
            {
                messageLabel.Text = "Please Fill Both Box.";
            }
            else
            {
                DateTime fromDateTime = Convert.ToDateTime(typeFromDateTextBox.Text);
                DateTime toDateTime = Convert.ToDateTime(typeToDateTextBox.Text);

                if (fromDateTime >= toDateTime)
                {
                    messageLabel.Text = "Please Select Both Dates Correct formate.";


                }

                else
                {

                    List<TypeWise> aTypeWises = aTypeWiseManager.GetPaymentsInfoTypesWises(fromDateTime, toDateTime);

                    if (aTypeWises == null)
                    {
                        messageLabel.Text = "You have no data between these dates.";

                    }

                    else
                    {
                        typeGridView.DataSource = aTypeWises;
                        typeGridView.DataBind();
                        typeTotalTextBox.Text = aTypeWiseManager.GetTotalAmountOfTypes(fromDateTime, toDateTime).ToString();

                        ViewState["GridData"] = aTypeWises;
                        
                        ViewState["Total"] = typeTotalTextBox.Text;

                    }

                }



            }



        }

        protected void typePdfButton_Click(object sender, EventArgs e)
        {
            GeneratePdf();
        }

        public void GeneratePdf()
        {
            typeGridView.DataSource = (List<TypeWise>)ViewState["GridData"];

            List<TypeWise> aTypeWises = (List<TypeWise>)ViewState["GridData"];

            typeGridView.DataBind();
            int CoulmnCount = typeGridView.HeaderRow.Cells.Count;
            PdfPTable pdfPTable = new PdfPTable(CoulmnCount);


            foreach (TableCell tableCell in typeGridView.HeaderRow.Cells)
            {
                PdfPCell pdfPCell = new PdfPCell(new Phrase(tableCell.Text));
                pdfPCell.BackgroundColor = new BaseColor(typeGridView.BackColor);
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

            foreach (TypeWise aTypeWise in aTypeWises)
            {
                pdfPTable.AddCell(aTypeWise.Id.ToString());
                pdfPTable.AddCell(aTypeWise.TestTypeName);
                pdfPTable.AddCell(aTypeWise.TotalNoOfTest.ToString());
                pdfPTable.AddCell(aTypeWise.TotalAmount.ToString());

            }

            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            string expdate = Convert.ToString(DateTime.Now);
            Phrase expir = new Phrase("Time: " + expdate + "\n\n\n");
            
            pdfDocument.Add(expir);

            Paragraph par1 = new Paragraph("Type Wise Report\n\n\n");
            pdfDocument.Add(par1);
            
            
            pdfDocument.Add(pdfPTable);

            //string total ="\n\n\nTotal Amount: "+ ViewState["Total"].ToString()+"\n";
            Phrase total = new Phrase("\n\n\nTotal Amount: " + Convert.ToString(ViewState["Total"]) + "\n");
            pdfDocument.Add(total);

            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=Type Wise Report.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }

    }
}