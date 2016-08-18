<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeWiseReport.aspx.cs" Inherits="DiagnosticBillManagementApp.UI.TypeWiseReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        &nbsp;Type Wise Report<br />
        
        <fieldset>
            

            <br />
            <table class="auto-style1">
                <tr>
                    <td>From Date</td>
                    <td>
                        <asp:TextBox ID="typeFromDateTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>To Date</td>
                    <td>
                        <asp:TextBox ID="typeToDateTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                        <asp:Button ID="typeShowButton" runat="server" Text="Show" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <asp:GridView ID="typeGridView" runat="server">
            </asp:GridView>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="typePdfButton" runat="server" OnClick="showButton_Click" Text="Pdf" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="typeTotalTextBox" runat="server"></asp:TextBox>
            <br />
            

        </fieldset>
    
    
    
    </div>
    </form>
</body>
</html>
