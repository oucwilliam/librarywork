<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkborrow.aspx.cs" Inherits="checkborrow" %>

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
                    <th>书名</th>
                    <th>开始日期</th>
                    <th>结束日期</th>
                </tr>
             </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td><%# Eval("BookName") %></td>
                    <td><%# Eval("StartDate") %></td>
                    <td><%# Eval("EndDate") %></td>
                    <td><asp:LinkButton runat="server" ID="BtnReturn" CommandName="ReturnBooks" Text="归还"  CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('确定要归还吗？')"></asp:LinkButton></td>
                    <td><asp:LinkButton runat="server" ID="BtnRenewBooks" CommandName="RenewBooks" Text="续借" CommandArgument='<%# Eval("id") %>'></asp:LinkButton></td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater><br />
            <asp:Button ID="BtnHome" runat="server" Text="返回" OnClick="BtnHome_Click" />
        </div>
        
    </form>
</body>
</html>
