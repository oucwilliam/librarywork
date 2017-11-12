using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_CheckReturn : System.Web.UI.Page
{
    static sqlsentence SQL = new sqlsentence();
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "select * from ReturnBooks";
        DataTable dt = new DataTable();
        SQL.sqldt(sql, dt);
        //把查询出的数据放入datatable
        rptList.DataSource = dt;
        rptList.DataBind();
    }
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Return")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string sql = "Delete from ReturnBooks where id = '" + id + "'";
            SQL.sqlIDU(sql);
            id = Convert.ToInt32(Session["id"]);
            sql = "Delete from userbooklend where id = '" + id + "'";
            SQL.sqlIDU(sql);
            string BookName = Session["BookName"].ToString();
            sql = "Select Available from librarybooks where BookName = '" + BookName + "'";
            DataTable dt = new DataTable();
            SQL.sqldt(sql, dt);
            int Available = Convert.ToInt32(dt.Rows[0][0]);
            int NewAvailable = Available + 1;
            sql = "Update librarybooks set Available = '" + NewAvailable + "' where BookName = '" + BookName + "'";
            SQL.sqlIDU(sql);
            Response.Write("<script>alert('处理成功');</script>");
        }
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdmHome.aspx");
    }
}