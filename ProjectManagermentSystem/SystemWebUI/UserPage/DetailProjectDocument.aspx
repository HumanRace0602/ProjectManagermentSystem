<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailProjectDocument.aspx.cs" Inherits="SystemWebUI.UserPage.DetailProjectDocument" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="content" runat="server">
    
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UserPage/ProjectDocuments/Request.aspx">需求文档</asp:HyperLink>&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/UserPage/ProjectDocuments/Plan.aspx">计划文档</asp:HyperLink>&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UserPage/ProjectDocuments/Execute.aspx">执行文档</asp:HyperLink>&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/UserPage/ProjectDocuments/Final.aspx">结案文档</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
