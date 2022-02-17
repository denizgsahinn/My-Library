using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyLibrary.Manager
{
    public partial class UpdatePublisher : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count != 0)
                {
                    int id = Convert.ToInt32(Request.QueryString["pid"]);
                    Publisher p = dm.BringPublisher(id);

                    tb_ID.Text = p.ID.ToString();
                    tb_name.Text = p.Name;
                    tb_phone.Text = p.Phone;
                    tb_address.Text = p.pAddress;
                }
                else
                {
                    Response.Redirect("PublisherList.aspx");
                }
            }
        }

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["pid"]);
            Publisher p = dm.BringPublisher(id);
            p.Name = tb_name.Text;
            p.Phone = tb_phone.Text;
            p.pAddress = tb_address.Text;

            if (dm.UpdatePublisher(p))
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