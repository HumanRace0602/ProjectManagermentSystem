<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogOn.aspx.cs" Inherits="SystemWebUI.Account.LogOn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		
		<title>项目管理系统 | 登陆</title>		
	  
		<!-- Reset Stylesheet -->
		<link rel="stylesheet" href="../resources/css/reset.css" type="text/css" media="screen" />
	  
		<!-- Main Stylesheet -->
		<link rel="stylesheet" href="../resources/css/style.css" type="text/css" media="screen" />	
        <script type="text/javascript">
            function fGetCode() {
                document.getElementById("ImageCaptcha").src = document.getElementById("ImageCaptcha").src + "?";
            } 


        </script>			
	</head>
  
	<body id="login">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>	
		<div id="login-wrapper" class="png_bg">
			<div id="login-top">
                <img id="logo" src="../resources/images/loginlogo.gif" alt="欢迎光临O(∩_∩)O" />
			</div> 
			
			<div id="login-content">						
				  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
					<p>
						<label>用户名：</label>
						<input name="userName" id="userName" class="text-input" type="text" runat="server" />
					</p>
					<div class="clear"></div>
					<p>
						<label>密码：</label>
						<input name="password" id="password" class="text-input" type="password" runat="server" />
					</p>
                    <div class="clear"></div>
					<p>
						<label>验证码：</label>
                        <input name="inputCaptcha" class="text-input"  style=" width:60px;" type="text" />
                        <asp:Image ID="ImageCaptcha" runat="server" ImageUrl="~/Account/Captcha.aspx" 
                                                     height="23px" 
                                                     width="71px" 
                                                     alt="验证码"
                                                     style="padding-left:18px"/>

                        <a href="javascript:fGetCode()" >换一个</a> 
					</p>
                    <br/><br/>
                    <div class="clear"></div>
                    <p>                      
                        <asp:Button ID="Button1" runat="server" Text="登陆" class="button" 
                            style=" width:50px" onclick="Button1_Click"/>
					</p>
                       <asp:Label ID="LabelResult" runat="server" Text="" Font-Size="Medium" ForeColor="Red" ClientIDMode="Inherit"></asp:Label>
                     <div class="clear"></div>
                     <p>
                        <label style="width: 250px;">还没有账号？点击这里进行<a href="UserRegister.aspx">[注册]</a></label>
                     </p>
                </ContentTemplate>
                </asp:UpdatePanel>
				
			</div> <!-- End #login-content -->
			
		</div> <!-- End #login-wrapper -->
		</form>
  </body>
</html>
