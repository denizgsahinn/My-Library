using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyLibrary.Manager
{
    public partial class AddBook : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_name.Text) && !string.IsNullOrEmpty(tb_writer.Text) && !string.IsNullOrEmpty(tb_numPage.Text) && !string.IsNullOrEmpty(tb_category.Text) && !string.IsNullOrEmpty(tb_publisher.Text))
            {
                Book b = new Book();
                b.Name = tb_name.Text;
                b.Writer_ID = Convert.ToInt32(tb_writer.Text);
                b.NumberOfPage = Convert.ToInt16(tb_numPage.Text);
                b.Category_ID = Convert.ToInt32(tb_category.Text);
                b.Publisher_ID = Convert.ToInt32(tb_publisher.Text);


                if (dm.AddBook(b))
                {
                    pnl_successful.Visible = true;
                    pnl_failed.Visible = false;
                    tb_name.Text = "";
                    tb_writer.Text = "";
                    tb_numPage.Text = "";
                    tb_category.Text = "";
                    tb_publisher.Text = "";
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