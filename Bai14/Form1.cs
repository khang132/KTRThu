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
namespace Bai14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void IDmay_TextChanged(object sender, EventArgs e)
        {

        }

        private void INLOAD_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string serverName = IDmay.Text;
            string databaseName = INLOAD.Text;
            string tk = username.Text;
            string mk = password.Text;

            // Tạo chuỗi kết nối SQL
            string connectionString = "Data Source=" + serverName + ";Initial Catalog=" + databaseName + ";User ID=" + tk + ";Password=" + mk;

            // Tạo đối tượng kết nối SQL
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                // Nếu kết nối thành công, hiển thị thông báo
                this.Hide();
                connection.Close();
                Form2 thi = new Form2(connection);
                thi.ShowDialog();
            }
            catch (Exception ex)
            {
                // Nếu kết nối thất bại, hiển thị thông báo lỗi
                MessageBox.Show("Kết nối that bai!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
