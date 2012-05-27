<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailProject.aspx.cs" Inherits="SystemWebUI.UserPage.DetailProject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div style=" color:Green; font-size:20px">
    
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
            DataSourceID="ObjectDataSource1" Height="50px" Width="100%">
            <Fields>
                <asp:BoundField DataField="projectName" HeaderText="项目名称" 
                    SortExpression="projectName" />
                <asp:BoundField DataField="projectContext" HeaderText="项目简介" 
                    SortExpression="projectContext" />
                <asp:BoundField DataField="projectPublishTime" HeaderText="项目建立时间" 
                    SortExpression="projectPublishTime" />
                <asp:BoundField DataField="projectStateString" HeaderText="是否完成" 
                    SortExpression="projectStateString" />
            </Fields>
        </asp:DetailsView>
        <p style=" color:Red; font-size:18px">
            项目角色：
        </p>
        <asp:Table ID="Table1" runat="server" Width="100%"  cellspacing="0" rules="all" border="1" style="height:50px;width:100%;border-collapse:collapse;">
        <asp:TableRow>
            <asp:TableCell Width="33%">
                建立人：
            </asp:TableCell>
            <asp:TableCell ID="TableCell1" Width="33%">
            </asp:TableCell>
            <asp:TableCell ID="TableCell5" Width="34%">
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                需求分析人：
            </asp:TableCell>
            <asp:TableCell ID="TableCell2">
            </asp:TableCell>
            <asp:TableCell ID="TableCell6">
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                执行人员
            </asp:TableCell>
            <asp:TableCell ID="TableCell3">
            </asp:TableCell>
            <asp:TableCell ID="TableCell7">
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                审核人员：
            </asp:TableCell>
            <asp:TableCell ID="TableCell4">
            </asp:TableCell>
            <asp:TableCell ID="TableCell8">
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetUserSetupProjectById" TypeName="BusinessLogicLib.UserProject">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="id" QueryStringField="id" 
                    Type="Int32" />
                <asp:SessionParameter Name="username" SessionField="userName" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
