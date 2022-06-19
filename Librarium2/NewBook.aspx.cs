using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Librarium2
{
    public partial class NewBook : System.Web.UI.Page
    {
        int BookID = 0;
        string author;
        string listauthors;
        string bookname;
        string isbn;
        string pages;
        string publisher;
        string year;
        string annotation;

        protected void getBook ()
        {
            try
            {
                using (DBConnection.connection =
                    new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();
                    DBConnection.command =
                        new SqlCommand(DBConnection.spGetBookByID, DBConnection.connection);
                    DBConnection.command.CommandType = CommandType.StoredProcedure;

                    DBConnection.command.Parameters.Add(new SqlParameter("@bookid", BookID));

                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@author",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@bookname",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@listauthors",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 4000,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@isbn",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@pages",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@publisher",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@year",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@annotation",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 4000,
                        Direction = ParameterDirection.Output
                    });

                    DBConnection.command.ExecuteNonQuery();

                    tbAuthor.Text = DBConnection.command.Parameters["@author"].Value.ToString().Trim();
                    tbBookName.Text = DBConnection.command.Parameters["@bookname"].Value.ToString().Trim();
                    tbISBN.Text = DBConnection.command.Parameters["@isbn"].Value.ToString().Trim();
                    tbPages.Text = DBConnection.command.Parameters["@pages"].Value.ToString().Trim();
                    tbPublisher.Text = DBConnection.command.Parameters["@publisher"].Value.ToString().Trim();
                    tbYear.Text = DBConnection.command.Parameters["@year"].Value.ToString().Trim();
                    tbAnnotation.Text = DBConnection.command.Parameters["@annotation"].Value.ToString().Trim();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Request.QueryString["BookID"] != null)
            {
                author = tbAuthor.Text;
                listauthors = tbListAuthors.Text;
                bookname = tbBookName.Text;
                isbn = tbISBN.Text;
                pages = tbPages.Text;
                publisher = tbPublisher.Text;
                year = tbYear.Text;
                annotation = tbAnnotation.Text;

                BookID = 0;
                int.TryParse(Request.QueryString["BookID"], out BookID);

                if (BookID > 0)
                {
                    getBook();
                }
                
            }

        }

        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (BookID > 0)
            {
                try
                {
                    using (DBConnection.connection =
                        new SqlConnection(DBConnection.connectionString))
                    {
                        if (!String.IsNullOrEmpty(tbAuthor.Text.Trim()) && !String.IsNullOrEmpty(tbBookName.Text.Trim()))
                        {
                            DBConnection.connection.Open();
                            DBConnection.command =
                                new SqlCommand(DBConnection.spUpdateBook, DBConnection.connection);
                            DBConnection.command.CommandType = CommandType.StoredProcedure;

                            //зададим параметры команды
                            DBConnection.command.Parameters.Add(new SqlParameter("@bookid", BookID));
                            DBConnection.command.Parameters.Add(new SqlParameter("@author", author));
                            DBConnection.command.Parameters.Add(new SqlParameter("@listAuthors", listauthors));
                            DBConnection.command.Parameters.Add(new SqlParameter("@bookName", bookname));
                            DBConnection.command.Parameters.Add(new SqlParameter("@ISBN", isbn));
                            DBConnection.command.Parameters.Add(new SqlParameter("@pages", pages));
                            DBConnection.command.Parameters.Add(new SqlParameter("@publisher", publisher));
                            DBConnection.command.Parameters.Add(new SqlParameter("@year", year));
                            DBConnection.command.Parameters.Add(new SqlParameter("@annotation", annotation));


                            DBConnection.command.ExecuteNonQuery();
                            getBook();

                            //Response.Redirect(Request.RawUrl);

                            MessageBox.Show("Сохранено");
                        }
                        else
                            MessageBox.Show("Не все обязательные поля заполнены");

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                try
                {

                    using (DBConnection.connection =
                        new SqlConnection(DBConnection.connectionString))
                    {
                        if (!String.IsNullOrEmpty(tbAuthor.Text.Trim()) && !String.IsNullOrEmpty(tbBookName.Text.Trim()))
                        {
                            DBConnection.connection.Open();
                            DBConnection.command =
                                new SqlCommand(DBConnection.spInsertNewBook, DBConnection.connection);
                            DBConnection.command.CommandType = CommandType.StoredProcedure;

                            //зададим параметры команды
                            DBConnection.command.Parameters.Add(new SqlParameter("@author", tbAuthor.Text));
                            DBConnection.command.Parameters.Add(new SqlParameter("@listAuthors", tbListAuthors.Text));
                            DBConnection.command.Parameters.Add(new SqlParameter("@bookName", tbBookName.Text));
                            DBConnection.command.Parameters.Add(new SqlParameter("@ISBN", tbISBN.Text));
                            DBConnection.command.Parameters.Add(new SqlParameter("@pages", tbPages.Text));
                            DBConnection.command.Parameters.Add(new SqlParameter("@publisher", tbPublisher.Text));
                            DBConnection.command.Parameters.Add(new SqlParameter("@year", tbYear.Text));
                            DBConnection.command.Parameters.Add(new SqlParameter("@annotation", tbAnnotation.Text));

                            DBConnection.command.ExecuteNonQuery();

                            MessageBox.Show("Сохранено");
                        }
                        else
                            MessageBox.Show("Не все обязательные поля заполнены");

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        
    }
}