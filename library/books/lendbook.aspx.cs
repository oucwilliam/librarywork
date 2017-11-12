using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lendbook : System.Web.UI.Page
{
    static sqlsentence SQL = new sqlsentence();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBindToRepeater(1);
        }
    }
    void DataBindToRepeater(int currentPage)
    {
        string sql = "select * from librarybooks";
        DataTable dt = new DataTable();
        SQL.sqldt(sql, dt);
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 1;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        pds.CurrentPageIndex = currentPage - 1;//当前页数从零开始，故把接受的数减一
        RptCategory.DataSource = pds;
        RptCategory.DataBind();

    }
    protected void RptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //找到外层Repeater的数据项
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取外层Repeater的数据项的ID
            string Category = Convert.ToString(rowv["Category"]);
            //找到对应ID下的Book
            string sql = "select * from librarybooks where Category='" + Category + "'";
            DataTable dt = new DataTable();
            SQL.sqldt(sql, dt);
            //找到内嵌Repeater
            Repeater rept = (Repeater)e.Item.FindControl("RptBook");
            //数据绑定
            rept.DataSource = dt;
            rept.DataBind();
        }
    }

    protected void RptBook_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "lend")
        {
            int BookId = Convert.ToInt32(e.CommandArgument.ToString());
            string sql = "Select BookName from librarybooks where id = '" + BookId + "'";
            DataTable dt = new DataTable();
            SQL.sqldt(sql, dt);
            string BookName = dt.Rows[0][0].ToString();
            Session["BookName"] = BookName;
            Session.Timeout = 40;
            Session["BookId"] = BookId;
            Session.Timeout = 40;
            Response.Redirect("borrowconfirm.aspx?id=" + BookId + "");
        }
    }

    protected void btnUp_Click(object sender, EventArgs e)
    {
        string nowPage = lbNow.Text;
        int toPage = Convert.ToInt32(nowPage) - 1;
        if (toPage >= 1)
        {
            lbNow.Text = Convert.ToString(toPage);
            DataBindToRepeater(toPage);
        }
    }

    protected void btnDown_Click(object sender, EventArgs e)
    {
        string nowPage = lbNow.Text;
        int toPage = Convert.ToInt32(nowPage) + 1;
        if (toPage <= Convert.ToInt32(lbTotal.Text))
        {
            lbNow.Text = Convert.ToString(toPage);
            DataBindToRepeater(toPage);
        }

    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        lbNow.Text = Convert.ToString(1);
        DataBindToRepeater(1);
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        int total = Convert.ToInt32(lbTotal.Text);
        lbNow.Text = Convert.ToString(total);
        DataBindToRepeater(total);
    }

    protected void btnJump_Click(object sender, EventArgs e)
    {
        int AimPage = Convert.ToInt32(txtJump.Text);
        int total = Convert.ToInt32(lbTotal.Text);
        if (AimPage >= total)
        {
            lbNow.Text = Convert.ToString(total);
            DataBindToRepeater(total);
        }
        else if (AimPage < 1)
        {
            lbNow.Text = Convert.ToString(1);
            DataBindToRepeater(1);
        }
        else
        {
            lbNow.Text = Convert.ToString(AimPage);
            DataBindToRepeater(AimPage);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("welcome.aspx");
    }
}