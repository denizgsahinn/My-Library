using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyLibrary.Manager
{
    public partial class AddPublisher : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_name.Text) && !string.IsNullOrEmpty(tb_phone.Text) && !string.IsNullOrEmpty(tb_address.Text))
            {
                Publisher p = new Publisher();
                p.Name = tb_name.Text;
                p.Phone = tb_phone.Text;
                p.pAddress = tb_address.Text;

                if (dm.AddPublisher(p))
                {
                    pnl_successful.Visible = true;
                    pnl_failed.Visible = false;
                    tb_name.Text = "";
                    tb_phone.Text = "";
                    tb_address.Text = "";
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