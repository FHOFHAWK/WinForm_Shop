using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class AddItem : Form
    {
        public decimal usd = 0;
        private SqlConnection sqlConnection = null;
        public AddItem(SqlConnection connection)
        {
            InitializeComponent();
            sqlConnection = connection;
        }
        public void Dollar()
        {
            string line = "";
            using (WebClient wc = new WebClient())
            line = wc.DownloadString("http://www.cbr.ru/scripts/XML_daily.asp");
            Match match = Regex.Match(line, "<Name>Доллар США</Name><Value>(.*?)</Value>");
            usd = Math.Ceiling(Convert.ToDecimal(match.Groups[1].Value));
        }
        //При нажатии на кнопку добавить
        private async void button_acceptAdd_Click(object sender, EventArgs e)
        {
            int price = 0;
            Dollar();
            if (String.IsNullOrWhiteSpace(textBox_nadbavka.Text) && String.IsNullOrWhiteSpace(textBox_nacenka.Text))
            {
                MessageBox.Show("Поле надбавки или наценки не заполнено");
            }
            //Если есть хотя бы одно пустое поле, выдаст MessageBox.Show
            if (String.IsNullOrWhiteSpace(textBox_numb.Text) || String.IsNullOrWhiteSpace(textBox_name.Text) ||
                String.IsNullOrWhiteSpace(textBox_maker.Text) || String.IsNullOrWhiteSpace(textBox_change.Text) ||
                String.IsNullOrWhiteSpace(textBox_optom.Text) || String.IsNullOrWhiteSpace(textBox_count.Text) ||
                String.IsNullOrWhiteSpace(textBox_category.Text))
            {
                MessageBox.Show("Есть незаполненные поля");
            }//Если всё заполнено, то MessageBox.Show, добавление в БД с обновлением и очистка полей
            else if (usd != 0 && !String.IsNullOrWhiteSpace(textBox_numb.Text) && !String.IsNullOrWhiteSpace(textBox_name.Text) &&
                !String.IsNullOrWhiteSpace(textBox_maker.Text) && !String.IsNullOrWhiteSpace(textBox_change.Text) &&
                !String.IsNullOrWhiteSpace(textBox_optom.Text) && !String.IsNullOrWhiteSpace(textBox_count.Text) && 
                !String.IsNullOrWhiteSpace(textBox_category.Text) && usd != 0)
            {
                if (!String.IsNullOrWhiteSpace(textBox_nacenka.Text))
                {
                    price = Convert.ToInt32(float.Parse(textBox_optom.Text) * float.Parse((textBox_nacenka.Text.Replace(".",","))));
                }
                else if (!String.IsNullOrWhiteSpace(textBox_nadbavka.Text))
                {
                    price = int.Parse(textBox_optom.Text) + int.Parse(textBox_nadbavka.Text);
                }
                if(price != 0)
                {
                    //Логика добавления
                    SqlCommand insert = new SqlCommand("INSERT INTO [TYMarket] (Numb, Name, Maker, Change, Category, Optom, Roznica, Count, Dollar) VALUES (@Numb, @Name, @Maker, @Change, @Category, @Optom, @Roznica, @Count, @Dollar)", sqlConnection);


                    insert.Parameters.AddWithValue("Numb", textBox_numb.Text);
                    insert.Parameters.AddWithValue("Name", textBox_name.Text);
                    insert.Parameters.AddWithValue("Maker", textBox_maker.Text);
                    insert.Parameters.AddWithValue("Change", textBox_change.Text);
                    insert.Parameters.AddWithValue("Category", textBox_category.Text);
                    insert.Parameters.AddWithValue("Optom", Convert.ToInt32(textBox_optom.Text));
                    insert.Parameters.AddWithValue("Roznica", price);
                    insert.Parameters.AddWithValue("Count", Convert.ToInt32(textBox_count.Text));
                    insert.Parameters.AddWithValue("Dollar", Math.Round(Convert.ToDecimal(price) / usd));
                    try
                    {
                        await insert.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Товар успешно добавлен");
                    //Очистка полей после успешного добавления
                    textBox_numb.Clear();
                    textBox_name.Clear();
                    textBox_maker.Clear();
                    textBox_change.Clear();
                    textBox_optom.Clear();
                    textBox_nadbavka.Clear();
                    textBox_category.Clear();
                    textBox_count.Clear();
                    textBox_nacenka.Clear();
                }
            }
        }
    }
}
