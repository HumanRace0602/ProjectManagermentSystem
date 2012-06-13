<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyJoinProjectMessage.aspx.cs" Inherits="SystemWebUI.UserPage.MyJoinProjectMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h2 style=" color:Green">项目邀请信息</h2>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Width="100%">
            <Columns>
                <asp:BoundField DataField="projectName" HeaderText="项目名称" 
                    SortExpression="projectName" />
                <asp:BoundField DataField="projectOwner" HeaderText="建立者" 
                    SortExpression="projectOwner" />
                <asp:BoundField DataField="projectDescription" HeaderText="简介" 
                    SortExpression="projectDescription" />
                <asp:BoundField DataField="role" HeaderText="邀请角色" SortExpression="role" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" 
                            CommandArgument='<%# Eval("id") %>' oncommand="Accept_Command">接受</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" 
                            CommandArgument='<%# Eval("id") %>' oncommand="deny_Command">拒绝</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetMessage" TypeName="BusinessLogicLib.UserProject" 
            DeleteMethod="AcceptProject">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:SessionParameter Name="username" SessionField="userName" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
