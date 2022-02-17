using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyLibrary.Manager
{
    public partial class UpdateCategory : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count != 0)
                {
                    int id = Convert.ToInt32(Request.QueryString["kid"]);
                    Category c = dm.BringCategory(id);

                    tb_ID.Text = c.ID.ToString();
                    tb_name.Text = c.Name;
                }
                else
                {
                    Response.Redirect("CategoryList.aspx");
                }
            }
        }

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["kid"]);
            Category c = dm.BringCategory(id);
            c.Name = tb_name.Text;

            if (dm.UpdateCategory(c))
            {
                pnl_succesful.Visible = true;
                pnl_failed.Visible = false;
            }
            else
            {
                pnl_succesful.Visible = false;
                pnl_failed.Visible = true;
                lbl_message.Text = "Something went wrong !";
            }
        }
    }
}