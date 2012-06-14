<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeRequestor.aspx.cs" Inherits="SystemWebUI.UserPage.ChangeRequestor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    现有的需求分析人员：<asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server">添加或更改</asp:LinkButton>
    </div>
    <div style=" padding-top:5px; margin:5px 0 20px 15px">
        <asp:Label ID="Label3" runat="server" Text="用户名："></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Width="209px"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" Text="查找" onclick="Button3_Click" />
        <br />
            
        <table class="style3">
            <tr>
                <td class="style4">
                    <asp:ListBox ID="ListBox1" runat="server" Height="157px" Width="190px">
                    </asp:ListBox>
                </td>
                <td class="style5">
                    <asp:Button ID="Button4" runat="server" Text="添加&gt;&gt;" 
                        onclick="Button4_Click" />
                    <br />
                    <asp:Button ID="Button5" runat="server" Text="&lt;&lt;移除" 
                        onclick="Button5_Click" />
                </td>
                <td>
                    <asp:ListBox ID="ListBox2" runat="server" Height="157px" Width="190px">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <br />
        <div style=" text-align:right; width: 453px;">
            <asp:Button ID="Button6" runat="server" Text="提交" onclick="Button6_Click" />
            <asp:Button ID="Button7" runat="server" Text="取消" />
        </div>
    </div>
    </form>
</body>
</html>
