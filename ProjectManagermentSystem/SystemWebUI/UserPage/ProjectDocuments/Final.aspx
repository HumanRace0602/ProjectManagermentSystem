﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Final.aspx.cs" Inherits="SystemWebUI.UserPage.ProjectDocuments.Final" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p style=" color:Lime" id="title" runat="server"></p>
    <asp:Button ID="Button1" runat="server" Text="Button" Visible="False" 
            onclick="Button1_Click" /> 
    <div id="divContext" runat="server">
    
    </div>
    </form>
</body>
</html>
