using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class checkborrow : System.Web.UI.Page
{
    static sqlsentence SQL = new sqlsentence();
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Session["UserName"].ToString();
        string sql = "select * from userbooklend where UserName = N'" + username + "'";
        DataTable dt = new DataTable();
        SQL.sqldt(sql, dt);
        //把查询出的数据放入datatable
        rptList.DataSource = dt;
        rptList.DataBind();
    }
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());
        string sql = "Select * from userbooklend where id = '" + id + "'";
        DataTable dt = new DataTable();
        SQL.sqldt(sql, dt);
        string BookName = dt.Rows[0][2].ToString();
        int BookId = Convert.ToInt32(dt.Rows[0][1]);
        if (e.CommandName == "RenewBooks")
        { 
            DateTime OldDate = Convert.ToDateTime(dt.Rows[0][6]);
            Session["OldDate"] = OldDate;
            Session["BookName"] = BookName;
            Session["BookId"] = BookId;
            Session.Timeout = 40;
            Response.Redirect("RenewBooks.aspx?id=" + BookId + "");
        }
        if(e.CommandName == "ReturnBooks")
        { 
            int UserId = Convert.ToInt32(dt.Rows[0][3]);
            string UserName = Session["UserName"].ToString();
            Session["BookId"] = BookId;
            Session["id"] = id;
            Session["BookName"] = BookName;
            Session.Timeout = 40;
            sql = "Insert into ReturnBooks values ('" + UserId + "','" + UserName + "','" + BookId + "',N'" + BookName + "')";
            SQL.sqlIDU(sql);
            Response.Write("<script>alert('归还成功!请等待管理员的确认');</script>");
        }
    }

    protected void BtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("welcome.aspx");
    }
}