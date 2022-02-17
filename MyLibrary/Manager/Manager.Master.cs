using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyLibrary.Manager
{
    public partial class Manager : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["manager"] != null)
            {
                DataAccessLayer.Manager mng = (DataAccessLayer.Manager)Session["manager"]; // unboxing 
                lbl_user.Text = mng.Name + " " + mng.Surname;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void lbt_logout_Click(object sender, EventArgs e)
        {
            Session["manager"] = null;  // burda sessionu sıfırlıyoruz
            Response.Redirect("Login.aspx");
        }
    }
}