using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyLibrary.Manager
{
    public partial class AddWriter : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_name.Text) && !string.IsNullOrEmpty(tb_surname.Text) && !string.IsNullOrEmpty(tb_title.Text))
            {
                Writer w = new Writer();
                w.Name = tb_name.Text;
                w.Surname = tb_surname.Text;
                w.Title = tb_title.Text;

                if (dm.AddWriter(w))
                {
                    pnl_successful.Visible = true;
                    pnl_failed.Visible = false;
                    tb_name.Text = "";
                    tb_surname.Text = "";
                    tb_title.Text = "";
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
                lbl_message.Text = "No field can be empty !";
            }
        }
    }
}