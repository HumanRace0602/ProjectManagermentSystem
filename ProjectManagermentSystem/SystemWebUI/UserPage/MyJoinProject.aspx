<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyJoinProject.aspx.cs" Inherits="SystemWebUI.UserPage.MyJoinProject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h2 style=" color:Green">我参与的项目</h2>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1" Width="100%">
            <Columns>
                <asp:BoundField DataField="projectName" HeaderText="项目名称" 
                    SortExpression="projectName" />
                <asp:BoundField DataField="projectPublishTime" HeaderText="发布时间" 
                    SortExpression="projectPublishTime" />
                <asp:BoundField DataField="projectStateString" HeaderText="是否完成" 
                    SortExpression="projectStateString" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%# Eval("id", "DetailProject.aspx?id={0}") %>'>详细</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetProjectsByAuthority" TypeName="BusinessLogicLib.UserProject">
            <SelectParameters>
                <asp:SessionParameter Name="username" SessionField="userName" Type="String" />
                <asp:Parameter DefaultValue="false" Name="flag" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
