<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageBooks.aspx.cs" Inherits="Administrator_ManageBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="BtnDelete" runat="server" Text="删除图书" OnClick="BtnDelete_Click" />
            <asp:Button ID="BtnAdd" runat="server" Text="添加图书" OnClick="BtnAdd_Click" /><br />
            <asp:Button ID="BtnBack" runat="server" Text="返回" OnClick="BtnBack_Click" />
        </div>
    </form>
</body>
</html>
