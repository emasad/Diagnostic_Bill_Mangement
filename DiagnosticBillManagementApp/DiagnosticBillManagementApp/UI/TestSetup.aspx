<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSetup.aspx.cs" Inherits="DiagnosticBillManagementApp.UI.TestSetup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
            Test Setup</p>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Test Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="testNameTextBox" runat="server" Width="229px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Fee</td>
                <td>
                    <asp:TextBox ID="feeTextBox" runat="server" Height="18px" Width="227px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Test Type</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="testTypeDropDown" runat="server" Height="20px" style="margin-bottom: 17px" Width="235px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="saveButton" runat="server" Text="Save" Width="102px" OnClick="saveButton_Click" />
                </td>
            </tr>
        </table>
        <p>
            <asp:Label ID="messageLabel" runat="server"></asp:Label>
        </p>
        <p>
            <asp:GridView ID="showTestInfoGridView" runat="server" AutoGenerateColumns="False">
                
                <Columns>
               <asp:TemplateField HeaderText="SL">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("TestId") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Test Name">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("TestName") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                
                    <asp:TemplateField HeaderText="Fee">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("Fee") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                
                 
               <asp:TemplateField HeaderText="Type">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("TypeName") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>     

            </Columns>

            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    
    
    </div>
    </form>
</body>
</html>
