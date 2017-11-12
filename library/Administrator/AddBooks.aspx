<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddBooks.aspx.cs" Inherits="Administrator_AddBooks"  ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>添加图书：
            书名：<asp:TextBox ID="TxtBookName" runat="server"></asp:TextBox><br />
            作者：<asp:TextBox ID="TxtAuthor" runat="server"></asp:TextBox><br />
            类别：<asp:TextBox ID="TxtCategory" runat="server"></asp:TextBox><br />
            总数: <asp:TextBox ID="TxtAll" runat="server"></asp:TextBox><br />
            <asp:Button ID="BtnAdd" runat="server" Text="添加" OnClick="BtnAdd_Click" />
        </div>
    </form>
</body>
</html>
