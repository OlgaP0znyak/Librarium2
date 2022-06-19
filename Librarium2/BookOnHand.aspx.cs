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
    public partial class BookOnHand : System.Web.UI.Page
    {
        DataSet ds;
        string inputedBook;
        string selectedBook;
        string selectedReader;
        string inputedReader;
        int bookID;
        int readerID;
        protected void Page_Load(object sender, EventArgs e)
        {
            inputedBook = tbBook.Text;
            inputedReader = tbReader.Text;
            try
            {
                using (DBConnection.connection = new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();
                    DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetBooksOnHand, DBConnection.connection);
                    ds = new DataSet();
                    DBConnection.adapter.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        protected void lbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBook = (string)lbBooks.SelectedValue;
            tbBook.Text = selectedBook;
            lbBooks.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            bool f = false;
            string str = "";
            string st = "";

            /**/
            
            if (!cbBook.Checked && !cbReader.Checked)
            {
                Label4.Text = "Не отмечен критерий поиска";
            }
            else if (cbReader.Checked && !cbBook.Checked)
            {
                if (String.IsNullOrEmpty(tbReader.Text.Trim()))
                {
                    Label4.Text = "Не выбран читатель";
                }
                else
                {
                    Label4.Text = "";

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
                    try
                    {
                        using (DBConnection.connection =
                        new SqlConnection(DBConnection.connectionString))
                        {
                            DBConnection.connection.Open();
                            DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetBooksonhandByReaderid, DBConnection.connection);
                            DBConnection.adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                            DBConnection.adapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int, 0).Value = readerID;

                            ds = new DataSet();
                            DBConnection.adapter.Fill(ds);
                            GridView1.DataSource = ds.Tables[0];
                            GridView1.DataBind();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (!cbReader.Checked && cbBook.Checked)
            {
                if (String.IsNullOrEmpty(tbBook.Text.Trim()))
                {
                    Label4.Text = "Не выбрана книга";
                }
                else
                {
                    Label4.Text = "";

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
                    try
                    {
                        using (DBConnection.connection =
                            new SqlConnection(DBConnection.connectionString))
                        {
                            DBConnection.connection.Open();
                            DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetBooksonhandByBookid, DBConnection.connection);
                            DBConnection.adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                            DBConnection.adapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int, 0).Value = bookID;

                            ds = new DataSet();
                            DBConnection.adapter.Fill(ds);
                            GridView1.DataSource = ds.Tables[0];
                            GridView1.DataBind();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                if (String.IsNullOrEmpty(tbReader.Text.Trim()) || String.IsNullOrEmpty(tbBook.Text.Trim()))
                {
                    Label4.Text = "Не выбраны читатель и/или книга";
                }
                else
                {
                    Label4.Text = "";

                    try
                    {
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
                        using (DBConnection.connection =
                            new SqlConnection(DBConnection.connectionString))
                        {
                            DBConnection.connection.Open();
                            DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetBooksonhandByBookidAndReaderid, DBConnection.connection);
                            DBConnection.adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                            DBConnection.adapter.SelectCommand.Parameters.Add("@readerid", SqlDbType.Int, 0).Value = readerID;
                            DBConnection.adapter.SelectCommand.Parameters.Add("@bookid", SqlDbType.Int, 0).Value = bookID;

                            ds = new DataSet();
                            DBConnection.adapter.Fill(ds);
                            GridView1.DataSource = ds.Tables[0];
                            GridView1.DataBind();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label4.Text = "";
            try
            {
                using (DBConnection.connection = new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();
                    DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetBooksOnHand, DBConnection.connection);
                    ds = new DataSet();
                    DBConnection.adapter.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}