<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuildNewProject.aspx.cs" Inherits="SystemWebUI.UserPage.BuildNewProject" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .bgcolor{ background-color:#000000;filter:alpha(opacity=50);}
        .style1
        {
            width: 80%;
            height: 230px;
        }
        .style2
        {
            width: 32%;
        }
        .style3
        {
            width: 40%;
        }
        .style4
        {
            width: 183px;
        }
        .style5
        {
            width: 61px;
        }
        input,textarea { padding: 6px;
                font-size: 13px;
                background: #FFEFD5 url('..resources/images/bg-form-field.gif') top left repeat-x;
                border: 1px solid #d5d5d5;
				color: #00FF00;
				}
		span
		{ color:#CD853F; font-size:18px
		    }
    </style>
</head>
<body runat="server" id="body" visible="true">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div style=" padding-top:20px; padding-left:150px">
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
        <asp:Label ID="Label1" runat="server" Text="项目名称："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1"
            runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
        <asp:Label ID="Label2" runat="server" Text="项目简述："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2"
            runat="server" Height="101px" MaxLength="250" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
        <asp:Label ID="Label4" runat="server" Text="需求分析人："></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LabelRequest" runat="server"></asp:Label>
                    <asp:Button ID="ButtonAddRequest" runat="server" Text="添加" onclick="ButtonAddRequest_Click" 
                        />
                </td>
            </tr>
            <tr>
                <td class="style2">
        <asp:Label ID="Label5" runat="server" Text="执行人："></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LabelExecute" runat="server"></asp:Label>
                    <asp:Button ID="ButtonAddExecute" runat="server" Text="添加" 
                        onclick="ButtonAddExecute_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label7" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td style=" text-align:right">
                    <asp:Button ID="Button1" runat="server" Text="确定" onclick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="取消" />
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="Panel1" runat="server" BackColor="AntiqueWhite">
        <asp:Label ID="Label6" runat="server" Text="查找/添加用户" BackColor="#66FF33" 
            Font-Size="22px" Height="30px" Width="700px"></asp:Label>
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
    </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
            PopupControlID="Panel1" TargetControlID="ButtonAddExecute"  
             DropShadow="True" BackgroundCssClass="bgcolor" CancelControlID="Button7" Enabled="True" 
            >
        </asp:ModalPopupExtender>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <div style=" width:60%; color:Green;padding-left:150px; padding-top:30px">
    <p>注：如果是添加需求分析人员，提交时会是列表中第一项而不是选中项。</p>
    </div>
</body>
</html>
