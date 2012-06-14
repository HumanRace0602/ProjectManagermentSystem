<%@ Page Title="" Language="C#" MasterPageFile="~/Common/SiteCommon.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SystemWebUI.UserPage.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>项目管理系统 | 用户页面</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <iframe id="Content" src="Test.aspx" name="Content"  class="Iframe">
    </iframe>
</asp:Content>
