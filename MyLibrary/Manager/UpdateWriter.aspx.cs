using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyLibrary.Manager
{
    public partial class UpdateWriter : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count != 0)
                {
                    int id = Convert.ToInt32(Request.QueryString["wid"]);
                    Writer w = dm.BringWriter(id);

                    tb_ID.Text = w.ID.ToString();
                    tb_name.Text = w.Name;
                    tb_surname.Text = w.Surname;
                    tb_title.Text = w.Title;
                }
                else
                {
                    Response.Redirect("WriterList.aspx");
                }
            }
        }

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["wid"]);
            Writer w = dm.BringWriter(id);
            w.Name = tb_name.Text;
            w.Surname = tb_surname.Text;
            w.Title = tb_title.Text;

            if (dm.UpdateWriter(w))
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