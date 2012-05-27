<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FreeTextBox.aspx.cs" Inherits="SystemWebUI.UserPage.ProjectDocuments.FreeTextBox" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        <asp:Button ID="Button1" runat="server" Text="保存" onclick="Button1_Click" 
            Visible="False" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2"
            runat="server" Text="取消" Visible="False" onclick="Button2_Click" /></p>
    <div>
        <FTB:FreeTextBox ID="FreeTextBox2" runat="server" Width="100%" Language="zh-CN">
        </FTB:FreeTextBox>
    </div>
    </form>
</body>
</html>
