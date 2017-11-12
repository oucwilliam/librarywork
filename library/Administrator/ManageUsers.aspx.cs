using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_ManageUsers : System.Web.UI.Page
{
    static sqlsentence SQL = new sqlsentence();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql = "select * from libraryusers";
            DataTable dt = new DataTable();
            SQL.sqldt(sql, dt);
            //把查询出的数据放入datatable
            rptList.DataSource = dt;
            rptList.DataBind();
        }
    }
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Reset")
        {
            int UserId = Convert.ToInt32(e.CommandArgument.ToString());
            string sql = "Update libraryusers set password = '123456' where id = '" + UserId + "'";
            SQL.sqlIDU(sql);
            Response.Write("<script>alert('重置成功');</script>");
        }
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdmHome.aspx");
    }
}