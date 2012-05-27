<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyProject.aspx.cs" Inherits="SystemWebUI.UserPage.MyProject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../resources/css/reset.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../resources/css/style.css" type="text/css" media="screen" />
    <style type="text/css">
        table{ width:100%; text-align: center;}
        #GridViewMyProject th{ width:25%; text-align:center}
        #GridViewMyProject td{ text-align:center}
        .table1{ text-align:center}
    </style>
    	
</head>
<body  style="background-color:transparent">
    <form id="form1" runat="server">
    <div>
        <h2 style=" color:Green">我建立的项目</h2>
        <div style=" text-align:right">
            <asp:HyperLink ID="HyperLink2" runat="server" Font-Size="Medium" 
                NavigateUrl="~/UserPage/BuildNewProject.aspx">新建项目</asp:HyperLink>
        </div>
    </div>
    <div style=" text-align:center">
    <asp:GridView ID="GridViewMyProject" runat="server" AutoGenerateColumns="False" AllowPaging="True" 
        DataSourceID="ObjectDataSource1" Font-Size="20px" align="center" class="table1">
        <Columns>
            <asp:BoundField DataField="projectName" HeaderText="项目名称"
                SortExpression="projectName" />         
            <asp:BoundField DataField="projectPublishTime" HeaderText="建立时间" 
                SortExpression="projectPublishTime" />
            <asp:BoundField DataField="projectStateString" HeaderText="是否完成" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl='<%# Eval("id","DetailProject.aspx?id={0}&") + Eval("projectName","projectName={0}") %>' 
                        Text="详细"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetUserSetupProjects" TypeName="BusinessLogicLib.UserProject">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="userName" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
