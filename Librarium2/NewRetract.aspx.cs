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
    public partial class NewRetract : System.Web.UI.Page
    {
        string inputedReader;
        string inputedBook;
        string selectedBook;
        string selectedReader;
        string retractDate;
        DateTime date;
        DataSet ds;
        int RetractID = 0;
        int bookID;
        int readerID;
        int coutBookOnHand;
        protected void Page_Load(object sender, EventArgs e)
        {
            inputedReader = tbReader.Text;
            inputedBook = tbBook.Text;
            retractDate = tbRetractDate.Text;

            if (Request.QueryString["RetractID"] != null)
            {
                RetractID = 0;
                int.TryParse(Request.QueryString["RetractID"], out RetractID);

                if (RetractID > 0)
                {
                    getRetract();
                    getRetractedBooks();
                    if (ViewState["Reader"] != null)
                    {
                        tbReader.Text = ViewState["Reader"].ToString();
                    }
                    else
                        tbReader.Text = "";
                }


            }
        }

        private void getRetract()
        {
            try
            {
                using (DBConnection.connection =
                    new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();
                    DBConnection.command =
                        new SqlCommand(DBConnection.spGetRetractByID, DBConnection.connection);
                    DBConnection.command.CommandType = CommandType.StoredProcedure;

                    DBConnection.command.Parameters.Add(new SqlParameter("@id", RetractID));

                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@retractid",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@retractdate",
                        SqlDbType = SqlDbType.Date,
                        Direction = ParameterDirection.Output
                    });

                    DBConnection.command.ExecuteNonQuery();

                    tbRetractID.Text = DBConnection.command.Parameters["@retractid"].Value.ToString().Trim();
                    date = Convert.ToDateTime(DBConnection.command.Parameters["@retractdate"].Value);
                    tbRetractDate.Text = date.ToString("yyyy-MM-dd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getRetractedBooks()
        {
            try
            {
                using (DBConnection.connection = new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();

                    DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetRetractedBooks, DBConnection.connection);
                    DBConnection.adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DBConnection.adapter.SelectCommand.Parameters.Add("@retractid", SqlDbType.Int, 0).Value = RetractID;
                    DBConnection.adapter.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@readerid",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.adapter.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@surname",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.adapter.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.adapter.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@patronymic",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    ds = new DataSet();
                    DBConnection.adapter.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();

                    tbReader.Text = "(" + DBConnection.adapter.SelectCommand.Parameters["@readerid"].Value.ToString().Trim() + ")" +
                        " " + DBConnection.adapter.SelectCommand.Parameters["@surname"].Value.ToString().Trim() +
                        " " + DBConnection.adapter.SelectCommand.Parameters["@name"].Value.ToString().Trim() +
                        " " + DBConnection.adapter.SelectCommand.Parameters["@patronymic"].Value.ToString().Trim();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            bool f = false;
            string str = "";
            string st = "";
           
            inputedReader = ViewState["Reader"].ToString();

            for (int i = 0; inputedBook[i] != ')'; i++)
            {

                if (flag == true)
                {
                    str = str + inputedBook[i];

                }
                if (inputedBook[i] == '(')
                    flag = true;

            }
            bookID = Convert.ToInt32(str);

            for (int i = 0; inputedReader[i] != ')'; i++)
            {

                if (f == true)
                {
                    st = st + inputedReader[i];

                }
                if (inputedReader[i] == '(')
                    f = true;

            }
            readerID = Convert.ToInt32(st);


            if (String.IsNullOrEmpty(tbBook.Text.Trim()) || String.IsNullOrEmpty(tbCount.Text.Trim()))
            {
                Label4.Text = "Не выбрана книга и/или не введено количество!";
            }
            else
            {
                try
                {
                    using (DBConnection.connection =
                        new SqlConnection(DBConnection.connectionString))
                    {
                        DBConnection.connection.Open();
                        DBConnection.command =
                            new SqlCommand(DBConnection.spGetBooksonhandByReader, DBConnection.connection);
                        DBConnection.command.CommandType = CommandType.StoredProcedure;

                        DBConnection.command.Parameters.Add(new SqlParameter("@readerid", readerID));
                        DBConnection.command.Parameters.Add(new SqlParameter("@bookid", bookID));

                        DBConnection.command.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@quantity",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        });

                        DBConnection.command.ExecuteNonQuery();
                        coutBookOnHand = Convert.ToInt32(DBConnection.command.Parameters["@quantity"].Value);

                        if (Convert.ToInt32(tbCount.Text) > coutBookOnHand)
                            MessageBox.Show("Введенное количество превышает выданное читателю количество.\n Выдано: " + coutBookOnHand.ToString() + " шт.");
                        else
                        {
                            try
                            {

                                using (DBConnection.connection =
                                new SqlConnection(DBConnection.connectionString))
                                {
                                    DBConnection.connection.Open();
                                    DBConnection.command =
                                            new SqlCommand(DBConnection.spInsertRetractedBooks, DBConnection.connection);
                                    DBConnection.command.CommandType = CommandType.StoredProcedure;

                                    //зададим параметры команды
                                    DBConnection.command.Parameters.Add(new SqlParameter("@bookid", bookID));
                                    DBConnection.command.Parameters.Add(new SqlParameter("@quantity", tbCount.Text));
                                    DBConnection.command.Parameters.Add(new SqlParameter("@retractid", RetractID));
                                    DBConnection.command.Parameters.Add(new SqlParameter("@readerid", readerID));

                                    DBConnection.command.ExecuteNonQuery();
                                    tbBook.Text = "";
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            tbCount.Text = "";
            getRetractedBooks();
            tbReader.Text = ViewState["Reader"].ToString();
        }

        protected void lbReaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedReader = (string)lbReaders.SelectedValue;
            tbReader.Text = selectedReader;
            lbReaders.Visible = false;
            ViewState["Reader"] = selectedReader;
        }

        protected void tbBook_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(inputedBook))
                lbBooks.Visible = false;
            else
            {
                try
                {
                    using (DBConnection.connection = new SqlConnection(DBConnection.connectionString))
                    {
                        DBConnection.connection.Open();
                        DBConnection.command =
                                new SqlCommand(DBConnection.spGetBooks, DBConnection.connection);
                        DBConnection.command.CommandType = CommandType.StoredProcedure;

                        DBConnection.command.Parameters.Add("@book", SqlDbType.VarChar, 100).Value = inputedBook;

                        SqlDataReader reader = DBConnection.command.ExecuteReader();

                        string result;

                        lbBooks.Items.Clear();
                        lbBooks.Visible = true;

                        //вывод на экран
                        while (reader.Read()) //пока есть, что читать
                        {
                            result = $"({reader.GetValue(0)}) " +
                                $"{reader.GetValue(1)} " +
                                $"\"{reader.GetValue(2)}\" ";
                            //добавим строку в listBox1
                            lbBooks.Items.Add(result);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (lbBooks.Items.Count == 0)
                    lbBooks.Visible = false;
            }
        }

        protected void tbReader_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(inputedReader))
                lbReaders.Visible = false;
            else
            {
                try
                {
                    using (DBConnection.connection = new SqlConnection(DBConnection.connectionString))
                    {
                        DBConnection.connection.Open();
                        DBConnection.command =
                                new SqlCommand(DBConnection.spGetReaders, DBConnection.connection);
                        DBConnection.command.CommandType = CommandType.StoredProcedure;

                        DBConnection.command.Parameters.Add("@reader", SqlDbType.VarChar, 100).Value = inputedReader;

                        SqlDataReader reader = DBConnection.command.ExecuteReader();

                        string result;

                        lbReaders.Items.Clear();
                        lbReaders.Visible = true;

                        //вывод на экран
                        while (reader.Read()) //пока есть, что читать
                        {
                            result = $"({reader.GetValue(0)}) " +
                                $"{reader.GetValue(1)} " +
                                $"{reader.GetValue(2)} " +
                                $"{reader.GetValue(3)}";
                            //добавим строку в listBox1
                            lbReaders.Items.Add(result);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (lbReaders.Items.Count == 0)
                    lbReaders.Visible = false;


            }
        }

        protected void lbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBook = (string)lbBooks.SelectedValue;
            tbBook.Text = selectedBook;
            lbBooks.Visible = false;
        }
    }
}