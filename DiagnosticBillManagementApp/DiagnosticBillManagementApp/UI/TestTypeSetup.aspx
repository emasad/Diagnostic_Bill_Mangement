<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeSetup.aspx.cs" Inherits="DiagnosticBillManagementApp.UI.TestTypeSetup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        Test Type Setup<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table class="auto-style1">
            <tr>
                <td>Type Name</td>
                <td>
                    <asp:TextBox ID="typeNameTextBox" runat="server" Height="23px" Width="224px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="saveButton" runat="server" Height="31px" OnClick="saveButton_Click" Text="Save" Width="82px" />
                </td>
            </tr>
        </table>
        <br />
                    <asp:Label ID="messgaeLabel" runat="server"></asp:Label>
        <p>
            <asp:GridView ID="showTypeNameGridView" runat="server" AutoGenerateColumns="False" >
                
                <Columns>
               <asp:TemplateField HeaderText="SL">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Type Name">
                   <ItemTemplate>
                       <asp:Label runat="server" Text='<%#Eval("TypeName") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                
                
                 
            </Columns>
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
    
    
    </div>
    </form>
</body>
</html>
