using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class welcome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Session["UserName"].ToString();
        if(Session["UserName"] == null)
        {
            Response.Redirect("userlogin.aspx");
        }
        else
        {  
            labwelcome.Text = username;
        }
            
    }
    protected void BtnChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("../users/userchangepassword.aspx");
    }

    protected void BtnLendBook_Click(object sender, EventArgs e)
    {
        Response.Redirect("lendbook.aspx");
    }

    protected void BtnCheckBorrow_Click(object sender, EventArgs e)
    {
        Response.Redirect("checkborrow.aspx");
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("/libraryhome.aspx");
    }

    protected void BtnAdm_Click(object sender, EventArgs e)
    {
        string Identity = Session["Identity"].ToString();
        if (Identity == "1")
            Response.Write("<script>alert('未获取管理员权限');</script>");
        else
        {
            string username = Session["UserName"].ToString();
            Response.Write("<script>alert('管理员" + username + "欢迎回来');location='../Administrator/AdmHome.aspx'</script>");
        }
    }

    protected void BtnFind_Click(object sender, EventArgs e)
    {
        Response.Redirect("FindBook.aspx");
    }

    protected void BtnFindAuthor_Click(object sender, EventArgs e)
    {
        Response.Redirect("FindAuthor.aspx");
    }
}