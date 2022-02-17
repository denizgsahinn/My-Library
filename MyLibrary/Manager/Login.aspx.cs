using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyLibrary.Manager
{
    public partial class Login : System.Web.UI.Page
    {
        DataModel db = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_mail.Text) && !String.IsNullOrEmpty(tb_password.Text))
            {
                string mail = tb_mail.Text;
                string password = tb_password.Text;

                DataAccessLayer.Manager m = db.ManagerLogin(mail,password);
                if (m != null)
                {
                    Session["manager"] = m;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lbl_message.Text = "Not Found User";
                    error_pnl.Visible = true;
                }

            }
            else
            {
                lbl_message.Text = "Mail and Password cannot be empty!";
                error_pnl.Visible = true;
            }
        }
    }
}