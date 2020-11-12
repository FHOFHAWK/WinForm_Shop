using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using ExcelDataReader;

namespace Shop
{
    public partial class MainForm : Form
    {
        private DataSet result;
        private SqlConnection sqlConnection = null;
        public decimal usdValue = 0;
        public MainForm()
        {
            InitializeComponent();
        }
        #region Добавление новой позиции
        private async void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItem formAdd = new AddItem(sqlConnection);
            formAdd.Show();

            listView.Items.Clear();
            await LoadTableAsync();
        }
        #endregion
        private async void MainForm_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            listView.GridLines = true;
            listView.FullRowSelect = true;
            listView.View = View.Details;
            await LoadTableAsync();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private async Task LoadTableAsync()
        {
            SqlDataReader sqlReader = null;
            SqlCommand getCommand = new SqlCommand("SELECT * FROM [TYMarket]", sqlConnection);

            try
            {
                sqlReader = await getCommand.ExecuteReaderAsync();

                while(await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                        Convert.ToString(sqlReader["Id"]),
                        Convert.ToString(sqlReader["Numb"]),
                        Convert.ToString(sqlReader["Name"]),
                        Convert.ToString(sqlReader["Maker"]),
                        Convert.ToString(sqlReader["Change"]),
                        Convert.ToString(sqlReader["Category"]),
                        Convert.ToString(sqlReader["Optom"]),
                        Convert.ToString(sqlReader["Roznica"]),
                        Convert.ToString(sqlReader["Count"]),
                        Convert.ToString(sqlReader["Dollar"]),
                    });
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if(listView.SelectedItems.Count > 0)
            { 
                DialogResult res = MessageBox.Show("Вы действительно хотите удалить выбранный товар?", "Удаление товара", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                switch (res)
                {
                    case DialogResult.OK:
                        SqlCommand delete = new SqlCommand("DELETE FROM [TYMarket] WHERE [Id] = @Id", sqlConnection);
                        delete.Parameters.AddWithValue("Id", Convert.ToString(listView.SelectedItems[0].SubItems[0].Text));

                        try
                        {
                            await delete.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        listView.Items.Clear();

                        await LoadTableAsync();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Строка не была выделена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #region Вывод курса $
        private void label1_Click(object sender, EventArgs e)
        {
            string line = "";
            using (WebClient wc = new WebClient())
            line = wc.DownloadString("http://www.cbr.ru/scripts/XML_daily.asp");
            Match match = Regex.Match(line, "<Name>Доллар США</Name><Value>(.*?)</Value>");
            label1.Text = "$=" + match.Groups[1].Value;
            usdValue = Convert.ToDecimal(match.Groups[1].Value);
        }
        #endregion

        private async void calculate_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы действительно хотите пересчитать цену товар?", "Пересчёт цены", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            switch (res)
            {
                case DialogResult.OK:
                    if (usdValue > 0)
                    {
                        for (int i = 0; i < listView.Items.Count; i++)
                        {
                            SqlCommand calculate = new SqlCommand("UPDATE [TYMarket] SET Roznica = @Roznica WHERE Id = @Id", sqlConnection);
                            calculate.Parameters.AddWithValue("Roznica", usdValue * Convert.ToInt32(listView.Items[i].SubItems[9].Text));
                            calculate.Parameters.AddWithValue("Id", listView.Items[i].SubItems[0].Text);

                            await calculate.ExecuteNonQueryAsync();
                        }
                        MessageBox.Show("Пересчёт прошёл удачно", "Удачная операция", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listView.Items.Clear();
                        await LoadTableAsync();
                    }
                    else
                    {
                        MessageBox.Show("Курс доллара неизвестен. Нажмите кнопку КУРС", "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }

        private async void btnReadExcel_Click(object sender, EventArgs e)
        {
            int j = 0;
            DialogResult res = MessageBox.Show("Вы действительно хотите добавить Excel-файл?", "Считывание из Excel", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if(usdValue == 0)
            {
                MessageBox.Show("Курса доллара не посчитан. Добавление не было выполнено.");
            }
            else
            {
                switch (res)
                {
                    case DialogResult.OK:
                        using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
                        {
                            if (ofd.ShowDialog() == DialogResult.OK)
                            {
                                FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                                IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs);
                                result = reader.AsDataSet();
                                if (String.IsNullOrWhiteSpace(ofd.FileName))
                                    goto E;
                                else goto M;
                            }
                        }
                        E: break;
                        M:  for (int i = 0; i < result.Tables[0].Rows.Count; i++)
                        {
                            SqlCommand insert = new SqlCommand("INSERT INTO [TYMarket] (Numb, Name, Maker, Change, Category, Optom, Roznica, Count, Dollar) VALUES (@Numb, @Name, @Maker, @Change, @Category, @Optom, @Roznica, @Count, @Dollar)", sqlConnection);
                            insert.Parameters.AddWithValue("Numb", Convert.ToString(result.Tables[0].Rows[i].ItemArray[j]));
                            insert.Parameters.AddWithValue("Name", Convert.ToString(result.Tables[0].Rows[i].ItemArray[j + 1]));
                            insert.Parameters.AddWithValue("Maker", Convert.ToString(result.Tables[0].Rows[i].ItemArray[j + 2]));
                            insert.Parameters.AddWithValue("Change", Convert.ToString(result.Tables[0].Rows[i].ItemArray[j + 3]));
                            insert.Parameters.AddWithValue("Category", Convert.ToString(result.Tables[0].Rows[i].ItemArray[j + 4]));
                            insert.Parameters.AddWithValue("Optom", Convert.ToInt32(result.Tables[0].Rows[i].ItemArray[j + 5]));
                            insert.Parameters.AddWithValue("Roznica", Convert.ToInt32(result.Tables[0].Rows[i].ItemArray[j + 6]));
                            insert.Parameters.AddWithValue("Count", Convert.ToInt32(result.Tables[0].Rows[i].ItemArray[j + 7]));
                            insert.Parameters.AddWithValue("Dollar", Math.Ceiling(Convert.ToDecimal(Convert.ToDecimal(result.Tables[0].Rows[i].ItemArray[j + 6])) / usdValue));
                            await insert.ExecuteNonQueryAsync();
                        }
                        MessageBox.Show("Excel-файл считан удачно", "Удачная операция", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listView.Items.Clear();
                        await LoadTableAsync();
                        break;
                    case DialogResult.Cancel:
                        break;

                }
            }
        }

        private async void listView_DoubleClick(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Action f = new Action(sqlConnection);
                f.Show();
                f.Id = Convert.ToInt32(listView.SelectedItems[0].SubItems[0].Text);

            }
            listView.Items.Clear();
            await LoadTableAsync();
        }

        private void label_history_Click(object sender, EventArgs e)
        {
            History f = new History();
            f.Show();
        }
    }
}
