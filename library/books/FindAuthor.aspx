﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FindAuthor.aspx.cs" Inherits="books_FindAuthor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             查找图书:<asp:TextBox ID="TxtFind" runat="server"></asp:TextBox>
            <asp:Button ID="BtnFind" runat="server" Text="查询" OnClick="BtnFind_Click" />
             <asp:Repeater ID="RptBook" runat="server" OnItemCommand="RptBook_ItemCommand" Visible="false">
                <HeaderTemplate>
                 <table>
                <tr>
                    <th>书名</th>
                    <th>作者名</th>
                    <th>类别</th>
                    <th>馆藏数量</th>
                    <th>可借数量</th>
                </tr>
                 </HeaderTemplate>
                <ItemTemplate>
                 <tr>
                   <td><%# Eval("BookName") %></td> 
                   <td><%# Eval("Author") %></td>
                   <td><%# Eval("Category") %></td>
                   <td><%# Eval("AllAmount") %></td>
                   <td><%# Eval("Available") %></td>
                   <td><asp:LinkButton runat="server" ID="btnLend" CommandName="lend" Text="借阅" CommandArgument='<%# Eval("id") %>'></asp:LinkButton></td>
                </tr>
                </ItemTemplate>
                <FooterTemplate>
                </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Button ID="BtnBack" runat="server" Text="返回" OnClick="BtnBack_Click" />
        </div>
    </form>
</body>
</html>
