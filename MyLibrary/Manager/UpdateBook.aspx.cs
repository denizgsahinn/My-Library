using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyLibrary.Manager
{
    public partial class UpdateBook : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count != 0)
                {
                    int id = Convert.ToInt32(Request.QueryString["bkid"]);
                    Book b = dm.BringBook(id);

                    tb_ID.Text = b.ID.ToString();
                    tb_category.Text = b.Category_ID.ToString();
                    tb_writer.Text = b.Writer_ID.ToString();
                    tb_publisher.Text = b.Publisher_ID.ToString();
                    tb_name.Text = b.Name;
                    tb_numPage.Text = b.NumberOfPage.ToString();            
                }
                else
                {
                    Response.Redirect("BookList.aspx");
                }
            }
        }

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["bkid"]);
            Book b = dm.BringBook(id);
            b.Name = tb_name.Text;
            b.WriterName = tb_writer.Text;
            b.NumberOfPage = Convert.ToInt16(tb_numPage.Text);
            b.CategoryName = tb_category.Text;
            b.PublisherName = tb_publisher.Text;

            if (dm.UpdateBook(b))
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