using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Shop
{
    public partial class Action : Form
    {
        public int id;//айди выбранного
        int was; //сколько было товара
        int become;//сколько стало товара
        int count;//изменение
        private SqlConnection sqlConnection = null;
        public string[] item;
        public Action(SqlConnection connection)
        {
            InitializeComponent();
            sqlConnection = connection;
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        private async void btn_prihod_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox_count.Text))
                MessageBox.Show("Поле \"КОЛИЧЕСТВО\" не может быть пустым");
            else
            {
                try
                {
                    count = Convert.ToInt32(textBox_count.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (count > 0)
                    {
                        SqlDataReader sqlReader = null;
                        SqlCommand getCommand = new SqlCommand("SELECT * FROM [TYMarket] WHERE [Id] = @Id", sqlConnection);
                        getCommand.Parameters.AddWithValue("Id", id);
                        try
                        {
                            sqlReader = await getCommand.ExecuteReaderAsync();

                            while (await sqlReader.ReadAsync())
                            {
                                item = new string[]
                                {
                                    Convert.ToString(sqlReader["Numb"]),
                                    Convert.ToString(sqlReader["Name"]),
                                    Convert.ToString(sqlReader["Roznica"]),
                                    Convert.ToString(sqlReader["Count"]),
                                };
                            }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        finally
                        {
                            if (sqlReader != null && !sqlReader.IsClosed)
                            {
                                sqlReader.Close();
                            }
                        }
                        was = Convert.ToInt32(item[3]);
                        become = was + count;

                        //Заменяем в первой таблице количество
                        getCommand = new SqlCommand("UPDATE [TYMarket] SET Count = @Count WHERE Id = @Id", sqlConnection);
                        getCommand.Parameters.AddWithValue("Count", become);
                        getCommand.Parameters.AddWithValue("Id", id);
                        await getCommand.ExecuteNonQueryAsync();

                        //Помещаем изменения во вторую таблицу
                        SqlCommand insert = new SqlCommand("INSERT INTO [History] (Numb, Name, Roznica, CountWas, CountBecome, Data, Result) VALUES (@Numb, @Name, @Roznica, @CountWas, @CountBecome, @Data, @Result)", sqlConnection);
                        insert.Parameters.AddWithValue("Numb", item[0]);
                        insert.Parameters.AddWithValue("Name", item[1]);
                        insert.Parameters.AddWithValue("Roznica", item[2]);
                        insert.Parameters.AddWithValue("CountWas", Convert.ToString(was));
                        insert.Parameters.AddWithValue("CountBecome", Convert.ToString(become));
                        insert.Parameters.AddWithValue("Data", DateTime.Now);
                        insert.Parameters.AddWithValue("Result", "+");
                        await insert.ExecuteNonQueryAsync();

                        textBox_count.Clear();
                        MessageBox.Show("Действие выполнено успешно. Количество товара обновлено");

                    }
                    else
                    {
                        MessageBox.Show("Количество товара не может равняться нулю");
                    }
                }
            }
        }

        private async void btn_sell_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox_count.Text))
                MessageBox.Show("Поле \"КОЛИЧЕСТВО\" не может быть пустым");
            else
            {
                try
                {
                    count = Convert.ToInt32(textBox_count.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (count > 0)
                    {
                        SqlDataReader sqlReader = null;
                        SqlCommand getCommand = new SqlCommand("SELECT * FROM [TYMarket] WHERE [Id] = @Id", sqlConnection);
                        getCommand.Parameters.AddWithValue("Id", id);
                        try
                        {
                            sqlReader = await getCommand.ExecuteReaderAsync();

                            while (await sqlReader.ReadAsync())
                            {
                                item = new string[]
                                {
                                    Convert.ToString(sqlReader["Numb"]),
                                    Convert.ToString(sqlReader["Name"]),
                                    Convert.ToString(sqlReader["Roznica"]),
                                    Convert.ToString(sqlReader["Count"]),
                                };
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (sqlReader != null && !sqlReader.IsClosed)
                            {
                                sqlReader.Close();
                            }
                        }
                        was = Convert.ToInt32(item[3]);
                        become = was - count;

                        //Заменяем в первой таблице количество
                        getCommand = new SqlCommand("UPDATE [TYMarket] SET Count = @Count WHERE Id = @Id", sqlConnection);
                        getCommand.Parameters.AddWithValue("Count", become);
                        getCommand.Parameters.AddWithValue("Id", id);
                        await getCommand.ExecuteNonQueryAsync();

                        //Помещаем изменения во вторую таблицу
                        SqlCommand insert = new SqlCommand("INSERT INTO [History] (Numb, Name, Roznica, CountWas, CountBecome, Data, Result) VALUES (@Numb, @Name, @Roznica, @CountWas, @CountBecome, @Data, @Result)", sqlConnection);
                        insert.Parameters.AddWithValue("Numb", item[0]);
                        insert.Parameters.AddWithValue("Name", item[1]);
                        insert.Parameters.AddWithValue("Roznica", item[2]);
                        insert.Parameters.AddWithValue("CountWas", Convert.ToString(was));
                        insert.Parameters.AddWithValue("CountBecome", Convert.ToString(become));
                        insert.Parameters.AddWithValue("Data", DateTime.Now);
                        insert.Parameters.AddWithValue("Result", "-");
                        await insert.ExecuteNonQueryAsync();

                        textBox_count.Clear();
                        MessageBox.Show("Действие выполнено успешно. Количество товара обновлено");

                    }
                    else
                    {
                        MessageBox.Show("Количество товара не может равняться нулю");
                    }
                }
            }
        }
    }
}