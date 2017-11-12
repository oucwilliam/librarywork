using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_DeleteBooks : System.Web.UI.Page
{
    static RegularExpression RE = new RegularExpression();
    static sqlsentence SQL = new sqlsentence();
    static string str = @"server=DESKTOP-DU96QJS;Integrated Security=SSPI;database=library;";
    protected void Page_Load(object sender, EventArgs e)
    {

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
    protected void BtnFind_Click(object sender, EventArgs e)
    {
        string Book = TxtFind.Text.ToString();
        if (RE.nobookname.IsMatch(Book))
            Response.Write("<script>alert('请输入合法字符');</script>");
        else
        {
            RptBook.Visible = true;
            string sql = "select * from librarybooks where BookName like '%" + Book + "%'";
            SqlConnection conn = new SqlConnection(str);
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            conn.Close();
            //把查询出的数据放入datatable
            RptBook.DataSource = dt;
            RptBook.DataBind();
        }
    }
    protected void RptBook_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "Delete")
        {
            int BookId = Convert.ToInt32(e.CommandArgument.ToString());
            string sql = "Select * from librarybooks where id =  '" + BookId + "'";
            DataTable dt = new DataTable();
            SQL.sqldt(sql, dt);
            int All = Convert.ToInt32(dt.Rows[0][4]);
            int Available = Convert.ToInt32(dt.Rows[0][5]);
            if (All != Available)
                Response.Write("<script>alert('有人借阅了此图书，无法删除');</script>");
            else
            {
                sql = "Delete from librarybooks where id = '" + BookId + "'";
                SQL.sqlIDU(sql);
                Response.Write("<script>alert('删除成功');location='ManageBooks.aspx'</script>");
            }
        }
    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("welcome.aspx");
    }
}