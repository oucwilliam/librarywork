<%@ Page Language="C#" AutoEventWireup="true" CodeFile="borrowconfirm.aspx.cs" Inherits="borrowconfirm" ValidateRequest="false"%>

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
            借阅日期选择：<br />
            开始日期：<asp:TextBox ID="txtStartDate" runat="server" value="选择您的开始借阅日期" ></asp:TextBox><br />
            结束日期：<asp:TextBox ID="txtEndDate" runat="server" value="选择您的结束借阅日期" ></asp:TextBox><br />
            (格式:年-月-日)<br />
            <asp:Button ID="Btnlend" runat="server" Text="确认" OnClick="Btnlend_Click"  OnClientClick="return confirm('确认借阅吗？')"/>
            <asp:Button ID="BtnBack" runat="server" Text="取消" OnClick="BtnBack_Click" />
        </div>
    </form>
</body>
</html>
