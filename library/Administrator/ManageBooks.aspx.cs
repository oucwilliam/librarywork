using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_ManageBooks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddBooks.aspx");
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdmHome.aspx");
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        Response.Redirect("DeleteBooks.aspx");
    }
}