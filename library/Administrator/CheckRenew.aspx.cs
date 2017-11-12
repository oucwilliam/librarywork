using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_CheckRenew : System.Web.UI.Page
{
    static sqlsentence SQL = new sqlsentence();
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "select * from RenewBooks";
        DataTable dt = new DataTable();
        SQL.sqldt(sql, dt);
        //把查询出的数据放入datatable
        rptList.DataSource = dt;
        rptList.DataBind();
    }
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Agree")
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string sql = "Select * from RenewBooks where id = " + Id + "";
            DataTable mdt = new DataTable();
            SQL.sqldt(sql, mdt);
            int BookId = Convert.ToInt32(mdt.Rows[0][3]);
            int UserId = Convert.ToInt32(mdt.Rows[0][1]);
            DateTime OldDate = Convert.ToDateTime(mdt.Rows[0][5]);
            DateTime NewDate = Convert.ToDateTime(mdt.Rows[0][6]);
            sql = "Update userbooklend set EndDate = '" + NewDate + "' where UserId = '" + UserId + "' and BookId = '" + BookId + "'";
            SQL.sqlIDU(sql);
            sql = "Delete from RenewBooks where id = " + Id + "";
            SQL.sqlIDU(sql);
            Response.Write("<script>alert('处理成功');</script>");
        }
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdmHome.aspx");
    }
}