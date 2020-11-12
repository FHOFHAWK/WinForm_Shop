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
    public partial class History : Form
    {
        private SqlConnection sqlConnection = null;
        long money;
        List<string> list = new List<string>();
        public History()
        {
            InitializeComponent();
        }
        private async void History_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            listView_History.GridLines = true;
            listView_History.FullRowSelect = true;
            listView_History.View = View.Details;
            await LoadTableAsync();
            await Color();
            list.Clear();
        }
        private async Task LoadTableAsync()
        {
            SqlDataReader sqlReader = null;
            SqlCommand getCommand = new SqlCommand("SELECT * FROM [History]", sqlConnection);
            try
            {
                sqlReader = await getCommand.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                        ListViewItem item = new ListViewItem(new string[] {
                        Convert.ToString(sqlReader["Id"]),
                        Convert.ToString(sqlReader["Numb"]),
                        Convert.ToString(sqlReader["Name"]),
                        Convert.ToString(sqlReader["Roznica"]),
                        Convert.ToString(sqlReader["CountWas"]),
                        Convert.ToString(sqlReader["CountBecome"]),
                        Convert.ToString(sqlReader["Data"]),
                        Convert.ToString(sqlReader["Result"]),
                    });
                    listView_History.Items.Add(item);
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
        }
        private async Task Color()
        {
            for (int i = 0; i < listView_History.Items.Count; i++)
            {
                SqlDataReader sqlReader = null;
                SqlCommand getCommand = new SqlCommand("SELECT Result FROM [History] WHERE [Id] = @Id", sqlConnection);
                getCommand.Parameters.AddWithValue("Id", Convert.ToString(listView_History.Items[i].SubItems[0].Text));
                try
                {
                    sqlReader = await getCommand.ExecuteReaderAsync();

                    while (await sqlReader.ReadAsync())
                    {
                        list.Add(Convert.ToString(sqlReader["Result"]));
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

                    if (String.Compare(list[i], "+") == 1)
                    {
                        listView_History.Items[i].BackColor = System.Drawing.Color.LightGreen;
                        money += Convert.ToInt32(listView_History.Items[i].SubItems[3].Text);
                    }
                    else listView_History.Items[i].BackColor = System.Drawing.Color.LightPink;
                }
            }
            label_money.Text = Convert.ToString(money);
            money = 0;
        }

        private void History_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }
    }
}
