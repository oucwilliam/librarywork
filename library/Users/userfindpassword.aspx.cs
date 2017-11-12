using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userfindpassword : System.Web.UI.Page
{
    static sqlsentence SQL = new sqlsentence();
    static RegularExpression RE = new RegularExpression();
    protected void Page_Load(object sender, EventArgs e)
    {
        ibtn_yzm.ImageUrl = "/ImageCode.aspx";
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

    protected void BtnFindPassword_Click(object sender, EventArgs e)
    {
        string Name = txtUserName.Text;
        string Phone = txtPhone.Text;
        if (RE.others.IsMatch(Name) == true)
            Response.Write("<script>alert('用户名错误！');</script>");
        else if (RE.nonumber.IsMatch(Phone) == true)
            Response.Write("<script>alert('手机号错误！');</script>");
        else
        {
            //select * from libraryusers where username = N'"Name"'
            string sql = "select * from libraryusers where username = N'" + Name + "'";
            DataTable dt = new DataTable();
            SQL.sqldt(sql, dt);
            int count = dt.Rows.Count;
            string password = dt.Rows[0][2].ToString();
            string phone = dt.Rows[0][3].ToString();
            if (count == 0)
                Response.Write("<script>alert('用户名不存在');</script>");
            else if (Phone != phone)
                Response.Write("<script>alert('绑定的手机号不正确');</script>");
            else
            {
                string code = tbx_yzm.Text.ToUpper();
                HttpCookie htco = Request.Cookies["ImageV"];
                string scode = htco.Value.ToString();
                if (code != scode)
                    Response.Write("<script>alert('验证码输入不正确！')</script>");
                else
                    Response.Write("<script>alert('您的密码是：" + password + "');location='userlogin.aspx'</script>");
            }
        }
    }

    protected void BackHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("/libraryhome.aspx");
    }
}