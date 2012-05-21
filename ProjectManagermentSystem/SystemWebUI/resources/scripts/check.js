//判断是否为空字符串或全部为空格
function isNull(str){
	if (str == "")
		return true;
	var regu = "^[ ]+$";
	var re = new RegExp(regu);
	if (re.test(str))
	    return true;
	else
	    return false;

	return false;

}

//判断是否为字母     //测试通过
function isLetter(str){
	var regu = "^[A-Za-z]+$";
	var re = new RegExp(regu);
	return re.test(str);
	
}

//判断是否为数字       //测试通过
function isNumber(str){
	var regu = "^[0-9]+$";
	var re = new RegExp(regu);
	return re.test(str);
}
//判断是否为数字或字母 //测试通过
function isNumberOrLetter(str){
	var regu = "^[0-9a-zA-Z]+$";
	var re = new RegExp(regu);
	return re.test(str);
}

//判断是否为字母或数字或下划线 //测试通过
function isNumberOrLetterOrUnderline(str) {
	var regu = "^[0-9a-zA-Z\_]+$";
	var re = new RegExp(regu);
	return re.test(str);
}

//判断字符串是否越界     //测试通过
function isStringOverLine(str, min, max) {
	if ((min <=  str.length) && (max >= str.length))
		return false;
	else
		return true;

}

//判断数字是否越界    //测试通过
function isNumberOverLine(num, min, max) {
	if ((min < num) && (max > num))
		return false;
	else
		return true;
}

//判断两个数字或字符串是否一致     //测试通过
function isTowStringEquil(str1, str2) {
	if (str1 == str2)
		return true;
	else
		return false;
}

//判断是否为Email  //测试通过
function isEmail(str) {
	var myReg = /^[-_A-Za-z0-9]+@([_A-Za-z0-9]+\.)+[A-Za-z0-9]{2,3}$/;
	return myReg.test(str);
}

//AJAX
var userNameState = false;
var passwordState = false;
var passwordAgainState = false;
var emailState = false;
function userCheck() {
    if (isNull(document.getElementById("userName").value)) {
        document.getElementById("userNameResult").innerHTML = "* 用户名不能为空";
        document.getElementById("userNameResult").style.color = "Red"
        userNameState = false;

    } else if (!isNumberOrLetterOrUnderline(document.getElementById("userName").value)) {
        document.getElementById("userNameResult").innerHTML = "* 用户名必须为英文数字或下划线组合";
        document.getElementById("userNameResult").style.color = "Red"
        userNameState = false;
    }else if(isStringOverLine(document.getElementById("userName").value, 4, 20)){
        document.getElementById("userNameResult").innerHTML = "* 用户名长度为4～20位";
        document.getElementById("userNameResult").style.color = "Red"
        userNameState = false;
    }
    else {
        send_request('RegisterValidation.aspx' + '?userName=' + document.getElementById("userName").value + '&r=' + Math.random());
    }
}

function passwordCheck() {
    if (isNull(document.getElementById("password").value)) {
        document.getElementById("passwordResult").innerHTML = "* 密码不能为空或全空格";
        document.getElementById("passwordResult").style.color = "Red"
        passwordState = false;
    } else if (isStringOverLine(document.getElementById("password").value, 6, 20)) {
        document.getElementById("passwordResult").innerHTML = "* 密码长度为6～20位";
        document.getElementById("passwordResult").style.color = "Red"
        passwordState = false;
    } else if (isNumber(document.getElementById("password").value)) {
        document.getElementById("passwordResult").innerHTML = "* 密码至少包含一个非数字字符";
        document.getElementById("passwordResult").style.color = "Red"
        passwordState = false;
    } else {
        document.getElementById("passwordResult").innerHTML = "* 密码合法";
        document.getElementById("passwordResult").style.color = "Green"
        if (document.getElementById("password").value != document.getElementById("passwordAgain").value) {
            passwordAgainState = false;
        }
        passwordState = true;
    }
}
function passwordAgainCheck() {
    if (!isTowStringEquil(document.getElementById("password").value, document.getElementById("passwordAgain").value)) {
        document.getElementById("passwordAgainResult").innerHTML = "* 两次输入不一致";
        document.getElementById("passwordAgainResult").style.color = "Red"
        passwordAgainState = false;
    } else {
        document.getElementById("passwordAgainResult").innerHTML = "* 两次输入一致";
        document.getElementById("passwordAgainResult").style.color = "Green"
        passwordAgainState = true;
    }
}
function emailCheck() {
    if (isNull(document.getElementById("email").value)) {
        document.getElementById("emailResult").innerHTML = "* 邮箱地址不能为空";
        document.getElementById("emailResult").style.color = "Red"
        emailState = false;
    } else if (!isEmail(document.getElementById("email").value)) {
        document.getElementById("emailResult").innerHTML = "* 邮箱地址格式不正确";
        document.getElementById("emailResult").style.color = "Red"
        emailState = false;
    } else {
        document.getElementById("emailResult").innerHTML = "* 邮箱地址正确";
        document.getElementById("emailResult").style.color = "Green"
        emailState = true;
    }
}
function fanalUserCheck() {
    userCheck();
    if (userNameState && passwordState && passwordAgainState && emailState)
        document.getElementById("btn").removeAttribute("disabled");
    else {
        //document.getElementById("btn").removeAttribute("disabled");
        document.getElementById("btn").setAttribute("disabled", "disabled");
    }

}
function fanalPasswordCheck() {
    passwordCheck();
    if (userNameState && passwordState && passwordAgainState && emailState)
        document.getElementById("btn").removeAttribute("disabled");
    else {
        //document.getElementById("btn").removeAttribute("disabled");
        document.getElementById("btn").setAttribute("disabled", "disabled");
    }

}
function fanalPasswordAgainCheck() {
    passwordAgainCheck();
    if (userNameState && passwordState && passwordAgainState && emailState)
        document.getElementById("btn").removeAttribute("disabled");
    else {
        //document.getElementById("btn").removeAttribute("disabled");
        document.getElementById("btn").setAttribute("disabled", "disabled");
    }

}
function fanalEmailCheck() {
   emailCheck();
    if (userNameState && passwordState && passwordAgainState && emailState)
        document.getElementById("btn").removeAttribute("disabled");
    else {
        //document.getElementById("btn").removeAttribute("disabled");
        document.getElementById("btn").setAttribute("disabled", "disabled");
    }

}
var http_request = false;
function send_request(url) {
    http_request = false;
    http_request = new ActiveXObject("Microsoft.XMLHTTP");
    if (window.XMLHttpRequest) {
        http_request = new XMLHttpRequest();
        if (http_request.overrideMimeType) {
            http_request.overrideMimeType('text/xml');
        }
    }
    else if (window.ActiveXObject) {
        try {
            http_request = new ActiveXObject("Msxm12.XMLHTTP");
        } catch (e) {
            try {
                http_request = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e) { }
        }
    }
    if (!http_request) {
        window.alert("Error!");
    }
    http_request.onreadystatechange = processRequest;
    http_request.open("GET", url, true);
    http_request.send(null);
}
function processRequest() {
    if (http_request.readyState == 4) {
        if (http_request.status == 200) {
            var str = http_request.responseText;
            showMsg(str);
        }
    }
}
function showMsg(str) {
    str = str.substr(0, 1);
    if (str == "0") {
        document.getElementById("userNameResult").innerHTML = "* 该用户名已存在";
        document.getElementById("userNameResult").style.color = "Red"
        userNameState = false;
        document.getElementById("btn").setAttribute("disabled", "disabled");
    } else {
        document.getElementById("userNameResult").style.color = "Green"
        document.getElementById("userNameResult").innerHTML = "* 可以使用该用户名";
        userNameState = true;
        if(passwordState)
            document.getElementById("btn").removeAttribute("disabled");
    }
}





