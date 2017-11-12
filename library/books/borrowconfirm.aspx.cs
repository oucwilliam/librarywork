using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class borrowconfirm : System.Web.UI.Page
{
    static RegularExpression RE = new RegularExpression();
    static sqlsentence SQL = new sqlsentence();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtStartDate.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年M月dd日'})");
        txtEndDate.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年M月dd日'})");
    }

    protected void Page_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
        if (ex is HttpRequestValidationException)
        {
            Response.Write("<script>alert('请您输入合法字符串。');</script>");
            Server.ClearError(); // 如果不ClearError()这个异常会继续传到Application_Error()。
        }
        else
        {
            Response.Write("<script>alert('请您不要乱来！');</script>");
        }
    }

    protected void Btnlend_Click(object sender, EventArgs e)
    {
        DateTime StartDate = Convert.ToDateTime(this.txtStartDate.Text);
        DateTime EndDate = Convert.ToDateTime(this.txtEndDate.Text);
        DateTime Today = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
        TimeSpan ts = EndDate - StartDate;
        int days = ts.Days;
        if (StartDate > EndDate || StartDate < Today)
            Response.Write("<script>alert('输入日期有错误');</script>");
        else if (days >= 15)
            Response.Write("<script>alert('图书最多只能借阅15天');</script>");
        else
        {
            string UserName = Session["UserName"].ToString();
            string BookName = Session["BookName"].ToString();
            int UserId = Convert.ToInt32(Session["UserId"]);
            int BookId = Convert.ToInt32(Session["BookId"]);
            string sql = "Select * from librarybooks where BookName = '" + BookName + "'";
            DataTable dt = new DataTable();
            dt = SQL.sqldt(sql, dt);
            int Available = Convert.ToInt32(dt.Rows[0][5]);
            int NewAvailable = Available - 1;
            sql = "Update librarybooks set Available = '" + NewAvailable + "' where BookName = '" + BookName + "'";
            SQL.sqlIDU(sql);
            sql = "Insert into userbooklend values ('" + BookId + "',N'" + BookName + "','" + UserId + "','" + UserName + "','" + StartDate + "','" + EndDate + "')";
            SQL.sqlIDU(sql);
            Response.Write("<script>alert('借阅成功');location='welcome.aspx'</script>");
        }
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("welcome.aspx");
    }
}