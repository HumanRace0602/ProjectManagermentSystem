<%@ Page Title="" Language="C#"   CodeBehind="UserRegister.aspx.cs" Inherits="SystemWebUI.Account.UserRegister" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
		
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		
		<title>项目管理系统 | 注册</title>		
	  
		<link rel="stylesheet" href="../resources/css/reset.css" type="text/css" media="screen" />

		<link rel="stylesheet" href="../resources/css/style.css" type="text/css" media="screen" />
        <script type="text/javascript" src="../resources/scripts/check.js"></script>			
	</head>
  
	<body id="login">
    <div id="login-wrapper" style=" text-align:center;margin:0px auto;" class="png_bg">  
        <div id="login-top">
                <img id="logo" src="../resources/images/项目管理系统注册.gif" alt="欢迎光临O(∩_∩)O" />
	    </div> 
        
            <div id="login-content" style=" width:600px; padding-left:170px">
                <form action="Register.aspx?" method="post">						
					<p>
                        <label style=" width:auto; float:left; color:Red">*&nbsp;</label>
						<label>用户名：</label>
						<input id="userName" name="userName" onblur="fanalUserCheck()" oninput="fanalUserCheck()" onpropertychange="fanalUserCheck()" class="text-input" type="text" style="float: left;"  />
                        <label id="userNameResult" style="color:Red; width:250px"></label>
					</p>
					<div class="clear"></div>
					<p>
                        <label style=" width:auto; float:left; color:Red">*&nbsp;</label>
						<label>密码：</label>
						<input id="password" name="password" class="text-input" onblur="fanalPasswordCheck()" oninput="fanalPasswordCheck()" onpropertychange="fanalPasswordCheck()" type="password" style="float: left;" />
                        <label id="passwordResult" style="color:Red; width:250px"></label>
					</p>
                    <div class="clear"></div>
					<p>
                        <label style=" width:auto; float:left; color:Red">*&nbsp;</label>
						<label>重复输入：</label>
                        <input id="passwordAgain" name="passwordAgain" class="text-input" onblur="fanalPasswordAgainCheck()" oninput="fanalPasswordAgainCheck()" onpropertychange="fanalPasswordAgainCheck()"  type="password"  style="float: left;"/>
                        <label id="passwordAgainResult" style="color:Red; width:250px"></label>
					</p>
                    <div class="clear"></div>
					<p>
                        <label style=" width:auto; float:left; color:Red">&nbsp;&nbsp;</label>
						<label>邮箱地址：</label>
                        <input name="email" id="email" class="text-input" onblur="fanalEmailCheck()" oninput="fanalEmailCheck()" onpropertychange="fanalEmailCheck()"  type="text"  style="float: left;"/>
                        <label id="emailResult" style="color:Red; width:250px"></label>
					</p>
                    <br/><br/>
                    <div class="clear"></div>
                    <p  style="padding-left:250px">                    
                        <input id="btn" type="submit" disabled="disabled" value="提交" style=" width:50px; float:left;" class="button"/>
					</p>                      
                     <div class="clear"></div>
                     <p>
                        <label style=" width:450px; color:Green">注：用户名须为字母、数字、下划线组合的字符串；密码为6～20位，其中至少包括一位非数字字符</label>
                     </p>   
                 </form>              
            </div>                   
        </div>
</body>
</html>
