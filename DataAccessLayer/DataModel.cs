using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Methods

        public Manager ManagerLogin(string mail, string password)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Managers WHERE Email= @m AND mPassword = @p "; // for security
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@p", password);
                con.Open();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                if (number > 0)
                {
                    cmd.CommandText = "SELECT ID,ManagerTypeID,Name,Surname,Email,mPassword,mStatus FROM Managers WHERE Email=@m AND mPassword = @p";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@p", password);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Manager m = null; // initial value
                    while (reader.Read())
                    {
                        m = new Manager();
                        m.ID = reader.GetInt32(0);
                        m.ManagerTypeID = reader.GetInt32(1);
                        m.Name = reader.GetString(2);
                        m.Surname = reader.GetString(3);
                        m.Email = reader.GetString(4);
                        m.mPassword = reader.GetString(5);
                        m.mStatus = reader.GetBoolean(6);
                    }
                    return m;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #region Add Methods

        public bool AddCategory(Category c)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Categories(Name) VALUES(@n)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@n", c.Name);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool AddWriter(Writer w)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Writers(Name,Surname,Title) VALUES(@n,@s,@t)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@n", w.Name);
                cmd.Parameters.AddWithValue("@s", w.Surname);
                cmd.Parameters.AddWithValue("@t", w.Title);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool AddPublisher(Publisher p)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Publishers(Name,Phone,pAddress) VALUES(@n,@p,@a)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@n", p.Name);
                cmd.Parameters.AddWithValue("@p", p.Phone);
                cmd.Parameters.AddWithValue("@a", p.pAddress);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool AddBook(Book b)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Books VALUES(@cID,@wID,@pID,@n,@np)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cID", b.Category_ID);
                cmd.Parameters.AddWithValue("@wID", b.Writer_ID);
                cmd.Parameters.AddWithValue("@pID", b.Publisher_ID);
                cmd.Parameters.AddWithValue("@n", b.Name);               
                cmd.Parameters.AddWithValue("@np", b.NumberOfPage);   
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        

        #endregion

        #region List Methods

        public List<Category> ListCategories()
        {
            try
            {
                List<Category> categories = new List<Category>();

                cmd.CommandText = "SELECT ID,Name FROM Categories";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category c = new Category();
                    c.ID = reader.GetInt32(0);
                    c.Name = reader.GetString(1);
                    categories.Add(c);
                }
                return categories;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Writer> ListWriters()
        {
            try
            {
                List<Writer> writers = new List<Writer>();

                cmd.CommandText = "SELECT ID,Name,Surname,Title FROM Writers";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Writer w = new Writer();
                    w.ID = reader.GetInt32(0);
                    w.Name = reader.GetString(1);
                    w.Surname = reader.GetString(2);
                    w.Title = reader.GetString(3);
                    writers.Add(w);
                }
                return writers;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Publisher> ListPublishers()
        {
            try
            {
                List<Publisher> publishers = new List<Publisher>();

                cmd.CommandText = "SELECT ID,Name,Phone,pAddress FROM Publishers";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Publisher p = new Publisher();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Phone = reader.GetString(2);
                    p.pAddress = reader.GetString(3);
                    publishers.Add(p);
                }
                return publishers;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Book> ListBooks()
        {
            try
            {
                List<Book> books = new List<Book>();

                cmd.CommandText = " SELECT B.ID , B.Name ,W.Name + ' ' + W.Surname AS WriterName , B.NumberOfPage , C.Name AS CategoryName , P.Name AS PublisherName FROM Books As B JOIN Categories As C ON B.Category_ID=C.ID JOIN Writers As W ON B.Writer_ID= W.ID JOIN Publishers As P ON B.Publisher_ID=P.ID";
                //cmd.CommandText = "SELECT ID,Category_ID,Writer_ID,Publisher_ID,Name,NumberOfPage FROM Books";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Book b = new Book();
                    b.ID = reader.GetInt32(0);
                    b.Name = reader.GetString(1);
                    b.WriterName = reader.GetString(2);
                    b.NumberOfPage = reader.GetInt16(3);
                    b.CategoryName= reader.GetString(4);
                    b.PublisherName = reader.GetString(5);
                    
                   
                    books.Add(b);
                }
                return books;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Bring Methods

        public Category BringCategory(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Name FROM Categories WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Category c = new Category();

                while (reader.Read())
                {
                    c.ID = reader.GetInt32(0);
                    c.Name = reader.GetString(1);
                }
                return c;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Writer BringWriter(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID,Name,Surname,Title FROM Writers WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Writer w = new Writer();

                while (reader.Read())
                {
                    w.ID = reader.GetInt32(0);
                    w.Name = reader.GetString(1);
                    w.Surname = reader.GetString(2);
                    w.Title = reader.GetString(3);
                }
                return w;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Publisher BringPublisher(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Name, Phone, pAddress FROM Publishers WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Publisher p = new Publisher();

                while (reader.Read())
                {
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Phone = reader.GetString(2);
                    p.pAddress = reader.GetString(3);
                }
                return p;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Book BringBook(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID , Category_ID, Writer_ID, Publisher_ID, Name, NumberOfPage FROM Books WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Book b = new Book();

                while (reader.Read())
                {
                    b.ID = reader.GetInt32(0);
                    b.Category_ID = reader.GetInt32(1);
                    b.Writer_ID = reader.GetInt32(2);
                    b.Publisher_ID = reader.GetInt32(3);
                    b.Name = reader.GetString(4);
                    b.NumberOfPage = reader.GetInt16(5);

                }
                return b;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Delete Methods

        public bool DeleteCategory(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Categories WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool DeleteWriter(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Writers WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool DeletePublisher(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Publishers WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool DeleteBook(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Books WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Update Methods

        public bool UpdateCategory(Category c)
        {
            try
            {
                cmd.CommandText = "UPDATE Categories SET Name = @n WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@n", c.Name);
                cmd.Parameters.AddWithValue("@id", c.ID);
                con.Open();

                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UpdateWriter(Writer w)
        {
            try
            {
                cmd.CommandText = "UPDATE Writers SET Name = @n, Surname = @sn, Title = @t WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@n", w.Name);
                cmd.Parameters.AddWithValue("@sn", w.Surname);
                cmd.Parameters.AddWithValue("@t", w.Title);
                cmd.Parameters.AddWithValue("@id", w.ID);
                con.Open();

                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UpdatePublisher(Publisher p)
        {
            try
            {
                cmd.CommandText = "UPDATE Publishers SET Name = @n, Phone= @p, pAddress=@a WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@n", p.Name);
                cmd.Parameters.AddWithValue("@p", p.Phone);
                cmd.Parameters.AddWithValue("@a", p.pAddress);
                cmd.Parameters.AddWithValue("@id", p.ID);
                con.Open();

                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UpdateBook(Book b)
        {
            try
            {
                cmd.CommandText = "UPDATE Books SET Category_ID= @cID , Writer_ID=@wID , Publisher_ID=@pID, Name = @n , NumberOfPage =@np  WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cID", b.Category_ID);
                cmd.Parameters.AddWithValue("@wID", b.Writer_ID);
                cmd.Parameters.AddWithValue("@pID", b.Publisher_ID);
                cmd.Parameters.AddWithValue("@n", b.Name);
                cmd.Parameters.AddWithValue("@np", b.NumberOfPage);
                cmd.Parameters.AddWithValue("@id", b.ID);
                con.Open();

                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }


        #endregion
























        #endregion
    }
}
