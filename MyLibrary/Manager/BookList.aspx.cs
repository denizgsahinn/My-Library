using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyLibrary.Manager
{
    public partial class BookList : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            lv_books.DataSource = dm.ListBooks();
            lv_books.DataBind();
        }

        protected void lv_books_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "deletee")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (!dm.DeleteBook(id))
                {
                    pnl_failed.Visible = true;
                    lbl_message.Text = "Something went wrong!";
                }
            }
            lv_books.DataSource = dm.ListBooks();
            lv_books.DataBind();
        }
    }
}