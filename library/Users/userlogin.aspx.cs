using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userlogin : System.Web.UI.Page
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
            Response.Write("<script>alert('请您输入合法字符');location='libraryhome.aspx'</script>");
            Server.ClearError();
            // 如果不ClearError()这个异常会继续传到Application_Error()。
        }
        else
        {
            Response.Write("<script>alert('请您不要乱来！');location='libraryhome.aspx'</script>");
            Server.ClearError(); // 如果不ClearError()这个异常会继续传到Application_Error()。
        }
    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        string UserName = txtUserName.Text;
        string UserPassword = txtUserPassword.Text;
        if ((RE.others.IsMatch(UserName) || RE.others.IsMatch(UserPassword)) == true)
            Response.Write("<script>alert('用户名或密码错误！');</script>");
        else
        {
            string sql = "select * from libraryusers where username = N'" + UserName + "' and password = '" + UserPassword + "'";
            //select * from libraryusers where username = N'UserName' and password = 'UserPassword' 
            int count = SQL.sqlSelect(sql);
            if (count == 0)
                Response.Write("<script>alert('用户名或密码错误！');</script>");
            else
            {
                string code = tbx_yzm.Text.ToUpper();
                HttpCookie htco = Request.Cookies["ImageV"];
                string scode = htco.Value.ToString();
                if (code != scode)
                Response.Write("<script>alert('验证码输入不正确！')</script>");
                else
                {
                    sql = "Select * from libraryusers where username = N'" + UserName + "'";
                    DataTable dt = new DataTable();
                    SQL.sqldt(sql, dt);
                    int UserId = Convert.ToInt32(dt.Rows[0][0]);
                    string Identity = Convert.ToString(dt.Rows[0][4]);
                    Session["UserId"] = UserId;
                    Session["UserName"] = UserName;
                    Session["Identity"] = Identity;
                    Session.Timeout = 40;
                    Response.Write("<script>alert('登录成功');location='../books/welcome.aspx'</script>");
                }
            }
        }     
    }
    protected void BtnFindPassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("userfindpassword.aspx");
    }

    protected void BackHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("/libraryhome.aspx");
    }
    protected void BtnUserSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("usersubmit.aspx");
    }
}