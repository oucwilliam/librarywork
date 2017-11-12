<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            欢迎:<asp:Label ID="labwelcome" runat="server" Text=""></asp:Label><br />
            <asp:Button ID="BtnLendBook" runat="server" Text="根据类别查找图书" OnClick="BtnLendBook_Click" />
            <asp:Button ID="BtnFind" runat="server" Text="根据书名粗略查找图书" OnClick="BtnFind_Click" />
            <asp:Button ID="BtnFindAuthor" runat="server" Text="根据作者粗略查找图书" OnClick="BtnFindAuthor_Click" />
            <asp:Button ID="BtnCheckBorrow" runat="server" Text="查询借阅情况" OnClick="BtnCheckBorrow_Click" />
            <asp:Button ID="BtnChangePassword" runat="server" Text="修改密码" OnClick="BtnChangePassword_Click" />
            <asp:Button ID="BtnCancel" runat="server" Text="注销" OnClick="BtnCancel_Click" /><br />
            <asp:Button ID="BtnAdm" runat="server" Text="管理员权限" OnClick="BtnAdm_Click" />

        </div>
    </form>
</body>
</html>
