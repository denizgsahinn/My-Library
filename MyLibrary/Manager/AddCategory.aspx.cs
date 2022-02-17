using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyLibrary.Manager
{
    public partial class AddCategory : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_name.Text))
            {
                Category c = new Category();
                c.Name = tb_name.Text;

                if (dm.AddCategory(c))
                {
                    pnl_successful.Visible = true;
                    pnl_failed.Visible = false;
                    tb_name.Text = "";
                }
                else
                {
                    pnl_successful.Visible = false;
                    pnl_failed.Visible = true;
                    lbl_message.Text = "Something went wrong!";
                }
            }
            else
            {
                pnl_successful.Visible = false;
                pnl_failed.Visible = true;
                lbl_message.Text = "Category Name cannot be empty !";
            }
        }
    }
}