<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckReturn.aspx.cs" Inherits="Administrator_CheckReturn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" >
             <HeaderTemplate>
            <table>
                <tr>
                    <th>用户名</th>
                    <th>书名</th>
                </tr>
             </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td><%# Eval("UserName") %></td>
                    <td><%# Eval("BookName") %></td>
                    <td><asp:LinkButton runat="server" ID="BtnReturn" CommandName="Return" Text="确定已归还" CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('确定该用户已归还该图书吗？')"></asp:LinkButton></td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater><br />
            <asp:Button ID="BtnBack" runat="server" Text="返回" OnClick="BtnBack_Click" />
        </div>
    </form>
</body>
</html>
