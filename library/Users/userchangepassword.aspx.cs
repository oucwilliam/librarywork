using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userchangepassword : System.Web.UI.Page
{
    static Check us = new Check();
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
            Response.Write("<script>alert('请您输入合法字符串。');location='libraryhome.aspx'</script>");
            Server.ClearError(); // 如果不ClearError()这个异常会继续传到Application_Error()。
        }
        else
        {
            Response.Write("<script>alert('请您不要乱来！');location='libraryhome.aspx'</script>");
        }
    }

    protected void BtnChangePassword_Click(object sender, EventArgs e)
    {
        string Name = Session["UserName"].ToString();
        string OldPassword = txtOldPassword.Text;
        string NewPassword = txtNewPassword.Text;
        string CheckPassword = txtCheckPassword.Text;
        string Phone = txtPhone.Text;
        if ((RE.others.IsMatch(Name) || RE.others.IsMatch(OldPassword)) == true)
            Response.Write("<script>alert('请不要输入非法字符！');</script>");
        else
        {
            //select * from libraryusers where username = N'"Name"'
            string sql = "select * from libraryusers where username = N'" + Name + "'";
            int count = SQL.sqlSelect(sql);
            if (count == 0)
                Response.Write("<script>alert('用户名不存在');</script>");
            else
            {
                DataTable dt = new DataTable();
                SQL.sqldt(sql, dt);
                string password = dt.Rows[0][2].ToString();
                string phone = dt.Rows[0][3].ToString();
                if (OldPassword != password)
                    Response.Write("<script>alert('原密码不正确');</script>");
                else if (us.Space(NewPassword) == false)
                    Response.Write("<script>alert('新密码不能含有空格');</script>");
                else if (CheckPassword != NewPassword)
                    Response.Write("<script>alert('两次输入的密码一样');</script>");
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
                    { //update libraryusers set password = N'NewPassword' where username = 'Name'
                        sql = "update libraryusers set password = N'" + NewPassword + "' where username = '" + Name + "'";
                        SQL.sqlIDU(sql);
                        Response.Write("<script>alert('修改成功！');Location='welcome.aspx'</script>");
                    }
                }
            }
        }
    }
    protected void BackHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("../books/welcome.aspx");
    }
}