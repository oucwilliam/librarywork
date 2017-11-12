<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lendbook.aspx.cs" Inherits="lendbook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="RptCategory" runat="server" OnItemDataBound="RptCategory_ItemDataBound">
        <ItemTemplate>
            <h2>
               类别：
           <%#Eval("Category")%>
                </h2>
            
            <%--嵌套Repeater，显示每个人的书籍 --%>
            <asp:Repeater ID="RptBook" runat="server" OnItemCommand="RptBook_ItemCommand">
                <HeaderTemplate>
                 <table>
                <tr>
                    <th>书名</th>
                    <th>作者名</th>
                    <th>馆藏数量</th>
                    <th>可借数量</th>
                </tr>
                 </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                   <td><%# Eval("BookName") %></td> 
                   <td><%# Eval("Author") %></td>
                   <td><%# Eval("AllAmount") %></td>
                   <td><%# Eval("Available") %></td>
                     <td><asp:LinkButton runat="server" ID="btnLend" CommandName="lend" Text="借阅" CommandArgument='<%# Eval("id") %>'></asp:LinkButton></td>
                </tr>
                        </ItemTemplate>
                <FooterTemplate>
                </table>
                </FooterTemplate>
            </asp:Repeater>
            <%--嵌套Repeater结束--%>
            <br />
        </ItemTemplate>
    </asp:Repeater>
        <asp:Button ID="btnUp" runat="server" Text="上一页" OnClick="btnUp_Click" />
        <asp:Button ID="btnDown" runat="server" Text="下一页"  OnClick="btnDown_Click"/>
        <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnFirst_Click" />
        <asp:Button ID="btnLast" runat="server" Text="尾页"  OnClick="btnLast_Click"/>
        页次：<asp:Label ID="lbNow" runat="server" Text="1"></asp:Label>
        /<asp:Label ID="lbTotal" runat="server" Text="1"></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" runat="server" Width="16px"></asp:TextBox>
        <asp:Button ID="btnJump" runat="server" Text="Go"  OnClick="btnJump_Click"/><br />
            
           <asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>

