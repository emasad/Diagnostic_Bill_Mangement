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
                        <asp:TextBox ID="testFromDateTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>To Date</td>
                    <td>
                        <asp:TextBox ID="testToDateTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                        <asp:Button ID="testShowButton" runat="server" OnClick="testShowButton_Click" Text="Show" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <asp:GridView ID="testGridView" runat="server">
            </asp:GridView>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="testPdfButton" runat="server" Text="Pdf" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="testTotalTextBox" runat="server" OnTextChanged="totalTextBox_TextChanged"></asp:TextBox>
            <br />
            

        </fieldset>
    
    
    
    </div>
    </form>
</body>
</html>
