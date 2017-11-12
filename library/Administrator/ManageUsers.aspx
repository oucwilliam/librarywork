<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="Administrator_ManageUsers" %>

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
                    <th>所绑定的手机号</th>
                </tr>
             </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td><%# Eval("username") %></td>
                    <td><%# Eval("phone") %></td>
                    <td><asp:LinkButton runat="server" ID="BtnReset" CommandName="Reset" Text="重置密码" CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('确定要重置该用户的密码吗？')"></asp:LinkButton></td>
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
