using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class books_RenewBooks : System.Web.UI.Page
{
    static sqlsentence SQL = new sqlsentence();
    static RegularExpression RE = new RegularExpression();
    protected void Page_Load(object sender, EventArgs e)
    {
        TxtNew.Attributes.Add("onfocus", "WdatePicker({skin:'whyGreen',dateFmt:'yyyy年M月dd日'})");
        DateTime OldDate = Convert.ToDateTime(Session["OldDate"]);
        LabOld.Text = OldDate.ToShortDateString();
    }
    protected void TxtReason_TextChanged(object sender, EventArgs e)
    {
        if (TxtReason.Text.Length > 50)
        {
            Response.Write("<script>alert('理由不能超过50个字符!');</script>");
        }
    }

    protected void BtnRenewBooks_Click(object sender, EventArgs e)
    {
        DateTime OldDate = Convert.ToDateTime(Session["OldDate"]);
        DateTime NewDate = Convert.ToDateTime(TxtNew.Text);
        TimeSpan ts = NewDate - OldDate;
        int days = ts.Days;
        if (OldDate > NewDate)
            Response.Write("<script>alert('请输入正确的日期形式');</script>");
        else if (days > 7)
            Response.Write("<script>alert('最多只能续借7天');</script>");
        else
        {
            int BookId = Convert.ToInt32(Session["BookId"]);
            int UserId = Convert.ToInt32(Session["UserId"]);
            string UserName = Convert.ToString(Session["UserName"]);
            string BookName = Convert.ToString(Session["BookName"]);
            string Reason = TxtReason.Text;
            if (RE.other.IsMatch(Reason))
                Response.Write("<script>alert('请不要输入非法字符');</script>");
            else
            {
                string sql = "Insert into RenewBooks values ('" + UserId + "','" + UserName + "','" + BookId + "','" + BookName + "','" + OldDate + "','" + NewDate + "','" + Reason + "')";
                SQL.sqlIDU(sql);
                Response.Write("<script>alert('提交成功！请等待您申请的结果');location='checkborrow.aspx'</script>");
            }
        }
    }



    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("checkborrow.aspx");
    }
}