﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userlogin.aspx.cs" Inherits="userlogin"  ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Login" runat="server" visible ="true">
            普通用户登录：<br />
            用户名：<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
            密码：<asp:TextBox ID="txtUserPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            验证码：
            <asp:TextBox ID="tbx_yzm" runat="server" Width="70px"></asp:TextBox>
            <asp:ImageButton ID="ibtn_yzm" runat="server" />
            <a href="javascript:changeCode()"style="text-decoration: underline; font-size:10px;">换一张</a>
            <script type="text/javascript">
            function changeCode() 
            {
             document.getElementById('ibtn_yzm').src = document.getElementById('ibtn_yzm').src + '?';
             }
             </script><br />
            <asp:Button ID="BtnLogin" runat="server" Text="登录" Onclick="BtnLogin_Click"/>
            <asp:Button ID="BtnUserSubmit" runat="server" Text="注册" OnClick="BtnUserSubmit_Click" />
            <asp:Button ID="BtnFindPassword" runat="server" Text="找回密码" OnClick="BtnFindPassword_Click" />
            <asp:Button ID="BackHome" runat="server" Text="返回主页" OnClick="BackHome_Click" />
        </div>
    </form>
</body>
</html>
