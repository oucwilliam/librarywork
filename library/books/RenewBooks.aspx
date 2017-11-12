<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RenewBooks.aspx.cs" Inherits="books_RenewBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"> </script>
            续借图书：<br />
            原结束日期：<asp:Label ID="LabOld" runat="server" Text=""></asp:Label><br />
            新结束日期：<asp:TextBox ID="TxtNew" runat="server"></asp:TextBox><br />
            理由:<br /><asp:TextBox ID="TxtReason" runat="server" Width="250px"   Height="108px" OnTextChanged="TxtReason_TextChanged" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="BtnRenewBooks" runat="server" Text="提交" OnClick="BtnRenewBooks_Click"  OnClientClick="return confirm('确定要续借吗？')" />
            <asp:Button ID="BtnBack" runat="server" Text="返回" OnClick="BtnBack_Click" />
        </div>
    </form>
</body>
</html>
