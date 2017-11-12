<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdmHome.aspx.cs" Inherits="Administrator_AdmHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            欢迎您，管理员<asp:Label ID="LabAdm" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="LabRB" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="LabReturn" runat="server" Text=""></asp:Label><br />
            <asp:Button ID="BtnBooks" runat="server" Text="管理书籍" OnClick="BtnBooks_Click" /><br />
            <asp:Button ID="BtnUsers" runat="server" Text="管理用户" OnClick="BtnUsers_Click" /><br />
            <asp:Button ID="BtnRenewBooks" runat="server" Text="管理图书续借" OnClick="BtnRenewBooks_Click" /><br />
            <asp:Button ID ="BtnReturn" runat="server" Text="管理图书归还" OnClick="BtnReturn_Click" />
            <asp:Button ID="BtnBack" runat="server" Text="返回主页" OnClick="BtnBack_Click" />
        </div>
    </form>
</body>
</html>
