<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnpaidBillReport.aspx.cs" Inherits="DiagnosticBillManagementApp.UI.UnpaidBillReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        Unpaid Bill Report<br />
        
        <fieldset>
            

            <br />
            <table class="auto-style1">
                <tr>
                    <td>From Date</td>
                    <td>
                        <EditItemTemplate>
    <asp:TextBox ID="billFromDateTextBox" runat="server" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date"></asp:TextBox>
</EditItemTemplate>
                        
                        
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>To Date</td>
                    <td>
                        
                        <EditItemTemplate>
    <asp:TextBox ID="billToDateTextBox" runat="server" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date" OnTextChanged="billToDateTextBox_TextChanged"></asp:TextBox>
</EditItemTemplate>
                        
                        

                        
&nbsp;&nbsp;
                        <asp:Button ID="billShowButton" runat="server" Text="Show" OnClick="billShowButton_Click" style="height: 26px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:Label ID="messageLabel" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="billGridView" runat="server" AutoGenerateColumns="False">
                
                <Columns>
               <asp:TemplateField HeaderText="Bill Number">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Contact No">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("ContactNo") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                 <asp:TemplateField HeaderText="Patient Name">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("PatientName") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Bill Amount">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("BillAmount") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>

                
            </Columns>
            </asp:GridView>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="billPdfButton" runat="server" Text="Pdf" OnClick="billPdfButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="billTotalTextBox" runat="server"></asp:TextBox>
            <br />
            

        </fieldset>
    
    
    
    
    </div>
    </form>
</body>
</html>
