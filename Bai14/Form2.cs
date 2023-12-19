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
    public partial class Form2 : Form
    {
        private SqlConnection connection;
        public Form2(SqlConnection connectionString)
        {
            InitializeComponent();
            connection = connectionString;
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            // Connect to the database
            connection.Open();
            string sql = "SELECT * FROM QuanLy";
            SqlCommand cmd = new SqlCommand(sql, connection);

            // Execute the SELECT statement
            SqlDataReader reader = cmd.ExecuteReader();

            // Add data to the DataGridView
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["magv"].ToString(), reader["HoTen"].ToString(), reader["sdt"].ToString(), reader["ghichu"].ToString(), reader["madonvi"].ToString(), reader["coso"].ToString());
            }

            // Close the database connection and data reader
            connection.Close();
            reader.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string stt = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                string sql = "DELETE FROM QuanLy WHERE magv = @stt";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@stt", stt);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);

                MessageBox.Show("Xóa câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn câu hỏi cần xóa!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            string value1 = dataGridView1.Rows[row].Cells[4].Value.ToString();
            string value2 = dataGridView1.Rows[row].Cells[5].Value.ToString();
            // Hiển thị thông tin trên thanh TextChanged
            txtCauC.Text = value1;
            txtCauD.Text = value2;
        }

        private void txtCauC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCauD_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            connection.Open();
                // Nếu kết nối thành công, hiển thị thông báo
            this.Hide();
            connection.Close();
            Form3 thi = new Form3(connection);
            thi.ShowDialog();
        }
    }
}
