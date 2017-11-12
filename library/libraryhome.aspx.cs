using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class library : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void BtnUserSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("/users/usersubmit.aspx");
    }

    protected void BtnUserLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("/users/userlogin.aspx");
    }

   
}