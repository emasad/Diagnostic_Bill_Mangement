<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWiseReport.aspx.cs" Inherits="DiagnosticBillManagementApp.UI.TestWiseReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Test Wise Report<br />
        
        <fieldset>
            

            <br />
            <table class="auto-style1">
                <tr>
                    <td>From Date</td>
                    <td>
                        <EditItemTemplate>
    <asp:TextBox ID="testFromDateTextBox" runat="server" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date"></asp:TextBox>
</EditItemTemplate>
                        
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>To Date</td>
                    <td>
                        <EditItemTemplate>
    <asp:TextBox ID="testToDateTextBox" runat="server" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date"></asp:TextBox>
</EditItemTemplate>
                       
&nbsp;&nbsp;
                        <asp:Button ID="testShowButton" runat="server" Text="Show" OnClick="testShowButton_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:Label ID="messageLabel" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="testGridView" runat="server" AutoGenerateColumns="False">
                
                <Columns>
               <asp:TemplateField HeaderText="SL">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Test Name">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("TestName") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                 <asp:TemplateField HeaderText="Total Test">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("TotalTest") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Total Amount">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>

                
            </Columns>

            </asp:GridView>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="testPdfButton" runat="server" Text="Pdf" OnClick="testPdfButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="testTotalTextBox" runat="server"></asp:TextBox>
            <br />
            

        </fieldset>
    
    
    
    </div>
    </form>
</body>
</html>
