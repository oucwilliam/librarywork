using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_AdmHome : System.Web.UI.Page
{
    static sqlsentence SQL = new sqlsentence();
    protected void Page_Load(object sender, EventArgs e)
    {
        string Username = Session["UserName"].ToString();
        LabAdm.Text = Username;
        string sql = "Select id from RenewBooks";
        int count = SQL.sqlSelect(sql);
        if(count != 0)
        {
            LabRB.Text = "您还有图书续借请求未处理";
        }
        sql = "Select id from ReturnBooks";
        count = SQL.sqlSelect(sql);
        if (count != 0)
            LabReturn.Text = "您还有图书归还请求未处理";
    }


    protected void BtnBooks_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageBooks.aspx");
    }

    protected void BtnUsers_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageUsers.aspx");
    }

    protected void BtnRenewBooks_Click(object sender, EventArgs e)
    {
        Response.Redirect("CheckRenew.aspx");
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../books/welcome.aspx");
    }

    protected void BtnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("CheckReturn.aspx");
    }
}