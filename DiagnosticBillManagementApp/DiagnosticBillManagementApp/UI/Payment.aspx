<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="DiagnosticBillManagementApp.UI.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        PayBill<br />
        <br />

    <fieldset    >
        

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table class="auto-style1">
            <tr>
                <td>Bill No</td>
                <td>
                    <asp:TextBox ID="billNoTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="searchButton" runat="server" Text="Search" />
                </td>
            </tr>
        </table>
        
    
    </fieldset>
     <br />
        <br />
        <br />   
        
    <fieldset>
        

        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label runat="server" Text="Bill Date"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="billDateLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Total Fee"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="totalFeeLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Paid Amount"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="paidAmountLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Due Amount"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="dueAmountLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Amount"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="amountTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="payButton" runat="server" Text="Pay" />
                </td>
            </tr>
        </table>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        

    </fieldset>
    
    
    </div>
    </form>
</body>
</html>
