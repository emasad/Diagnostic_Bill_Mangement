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
                        <EditItemTemplate>
    <asp:TextBox ID="typeFromDateTextBox" runat="server" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date"></asp:TextBox>
</EditItemTemplate>
                        
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>To Date</td>
                    <td>
                        <EditItemTemplate>
    <asp:TextBox ID="typeToDateTextBox" runat="server" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date"></asp:TextBox>
</EditItemTemplate>
                        
                       
&nbsp;&nbsp;
                        <asp:Button ID="typeShowButton" runat="server" Text="Show" OnClick="typeShowButton_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <asp:Label ID="messageLabel" runat="server" EnableTheming="True"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="typeGridView" runat="server" AutoGenerateColumns="False">
                
                  <Columns>
               <asp:TemplateField HeaderText="SL">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Test Type Name">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("TestTypeName") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                 <asp:TemplateField HeaderText="Total no Of Test">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("TotalNoOfTest") %>'></asp:Label>
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
            <asp:Button ID="typePdfButton" runat="server" Text="Pdf" OnClick="typePdfButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="typeTotalTextBox" runat="server"></asp:TextBox>
            <br />
            

        </fieldset>
    
    
    
    </div>
    </form>
</body>
</html>
