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
    public partial class NewReader : System.Web.UI.Page
    {
        int ReaderID = 0;
        string surname;
        string name;
        string patronymic;
        string adress;
        string phone;
        string date;

        DateTime birthdate;

        protected void getReader()
        {
            try
            {
                using (DBConnection.connection =
                    new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();
                    DBConnection.command =
                        new SqlCommand(DBConnection.spGetReaderByID, DBConnection.connection);
                    DBConnection.command.CommandType = CommandType.StoredProcedure;

                    DBConnection.command.Parameters.Add(new SqlParameter("@readerid", ReaderID));

                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@readersurname",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@readername",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@readerpatronymic",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@address",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@phonenumber",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@birthdate",
                        SqlDbType = SqlDbType.Date,
                        Direction = ParameterDirection.Output
                    });

                    DBConnection.command.ExecuteNonQuery();

                    tbSurname.Text = DBConnection.command.Parameters["@readersurname"].Value.ToString().Trim();
                    tbName.Text = DBConnection.command.Parameters["@readername"].Value.ToString().Trim();
                    tbPatronymic.Text = DBConnection.command.Parameters["@readerpatronymic"].Value.ToString().Trim();
                    tbAdress.Text = DBConnection.command.Parameters["@address"].Value.ToString().Trim();
                    tbPhone.Text = DBConnection.command.Parameters["@phonenumber"].Value.ToString().Trim();
                    birthdate = Convert.ToDateTime(DBConnection.command.Parameters["@birthdate"].Value);
                    tbBirthDate.Text = birthdate.ToString("yyyy-MM-dd");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ReaderID"] != null)
            {
                surname = tbSurname.Text;
                name = tbName.Text;
                patronymic = tbPatronymic.Text;
                adress = tbAdress.Text;
                phone = tbPhone.Text;
                date = tbBirthDate.Text;
                
                ReaderID = 0;
                int.TryParse(Request.QueryString["ReaderID"], out ReaderID);

                if (ReaderID > 0)
                {
                    getReader();
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ReaderID > 0)
            {
                try
                {
                    using (DBConnection.connection =
                        new SqlConnection(DBConnection.connectionString))
                    {
                        if (!String.IsNullOrEmpty(tbSurname.Text.Trim()) && !String.IsNullOrEmpty(tbName.Text.Trim()))
                        {
                            DBConnection.connection.Open();
                            DBConnection.command =
                                new SqlCommand(DBConnection.spUpdateReader, DBConnection.connection);
                            DBConnection.command.CommandType = CommandType.StoredProcedure;

                            //зададим параметры команды
                            DBConnection.command.Parameters.Add(new SqlParameter("@readerid", ReaderID));
                            DBConnection.command.Parameters.Add(new SqlParameter("@readersurname", surname));
                            DBConnection.command.Parameters.Add(new SqlParameter("@readername", name));
                            DBConnection.command.Parameters.Add(new SqlParameter("@readerpatronymic", patronymic));
                            DBConnection.command.Parameters.Add(new SqlParameter("@address", adress));
                            DBConnection.command.Parameters.Add(new SqlParameter("@phonenumber", phone));
                            DBConnection.command.Parameters.Add(new SqlParameter("@birthdate", date));


                            DBConnection.command.ExecuteNonQuery();
                            getReader();

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
                        if (!String.IsNullOrEmpty(tbSurname.Text.Trim()) && !String.IsNullOrEmpty(tbName.Text.Trim()))
                        {
                            DBConnection.connection.Open();
                            DBConnection.command =
                                new SqlCommand(DBConnection.spInsertNewReader, DBConnection.connection);
                            DBConnection.command.CommandType = CommandType.StoredProcedure;

                            //зададим параметры команды
                            DBConnection.command.Parameters.Add(new SqlParameter("@readersurname", tbSurname.Text));
                            DBConnection.command.Parameters.Add(new SqlParameter("@readername", tbName.Text));
                            DBConnection.command.Parameters.Add(new SqlParameter("@readerpatronymic", tbPatronymic.Text));
                            DBConnection.command.Parameters.Add(new SqlParameter("@address", tbAdress.Text));
                            DBConnection.command.Parameters.Add(new SqlParameter("@phonenumber", tbPhone.Text));
                            DBConnection.command.Parameters.Add(new SqlParameter("@birthdate", tbBirthDate.Text));

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
               

        protected void tbBirthDate_Load(object sender, EventArgs e)
        {            
                tbBirthDate.Attributes["max"] = DateTime.Now.AddYears(-6).ToString("yyyy-MM-dd");            
        }
    }
}