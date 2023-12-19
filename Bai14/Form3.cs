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
    public partial class Form3 : Form
    {
        private SqlConnection connection;
        public Form3(SqlConnection connectionString)
        {
            InitializeComponent();
            connection = connectionString;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form3_Load(object sender, EventArgs e)
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
        private void txtCauB_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCauC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCauD_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            string value1 = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string value2 = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string value3 = dataGridView1.Rows[row].Cells[3].Value.ToString();
            string value4 = dataGridView1.Rows[row].Cells[4].Value.ToString();
            string value5 = dataGridView1.Rows[row].Cells[5].Value.ToString();
            // Hiển thị thông tin trên thanh TextChanged
            txtCauB.Text = value1;
            txtCauC.Text = value2;
            txtCauD.Text = value3;
            textBox1.Text = value4;
            textBox2.Text = value5;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
