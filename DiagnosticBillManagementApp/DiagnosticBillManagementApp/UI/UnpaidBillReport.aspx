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
                        <asp:TextBox ID="billFromDateTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>To Date</td>
                    <td>
                        <asp:TextBox ID="billToDateTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                        <asp:Button ID="billShowButton" runat="server" Text="Show" OnClick="billShowButton_Click" style="height: 26px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <asp:GridView ID="billGridView" runat="server">
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
