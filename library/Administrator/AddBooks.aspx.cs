using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_AddBooks : System.Web.UI.Page
{
    static sqlsentence SQL = new sqlsentence();
    static RegularExpression RE = new RegularExpression();
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
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        string BookName = TxtBookName.Text.ToString();
        string Author = TxtAuthor.Text.ToString();
        string Category = TxtCategory.Text.ToString();
        string All = TxtAll.Text.ToString();
        if ((RE.nobookname.IsMatch(BookName)|| RE.nobookname.IsMatch(Author)||RE.noUppercharacter.IsMatch(Category)|| RE.nonumber.IsMatch(All)) == true)
            Response.Write("<script>('请输入合法字符');</script>");
        else
        {
            string sql = "Insert into librarybooks values (N'" + BookName + "','" + Author + "','" + Category + "','" + All + "','" + All + "')";
            SQL.sqlIDU(sql);
            Response.Write("<script>alert('添加成功');location='ManageBooks.aspx'</script>");
        }
        
     
        
    }
}