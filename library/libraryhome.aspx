<%@ Page Language="C#" AutoEventWireup="true" CodeFile="libraryhome.aspx.cs" Inherits="library" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="home" runat="server" visible="true">
            欢迎：<br />
            <asp:Button ID="BtnUserSubmit" runat="server" Text="注册" OnClick="BtnUserSubmit_Click" />
            <asp:Button ID="BtnUserLogin" runat="server" Text="登录" OnClick="BtnUserLogin_Click" />
        </div>
    </form>
</body>
</html>
