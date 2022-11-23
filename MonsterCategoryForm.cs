using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISpan.Utility;

namespace MonsterHunterTool
{
    public partial class MonsterCategoryForm : Form
    {
        DataTable Categories;
        public MonsterCategoryForm()
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            MaximizeBox = false;
            MinimizeBox = false;
            DisplayMonsterCategory();
        }
        private void DisplayMonsterCategory()
        {
            string sql = "select ID, MonsterCategory from MonsterCategory";
            Categories = new SqlDbHelper("default").Select(sql, null);

            BindData(Categories);
        }
        private void BindData(DataTable model)
        {
            dataGridView1.DataSource = model;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var frm = new CreateMonsterCategoryForm();
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                DisplayMonsterCategory();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndx = e.RowIndex;

            if (rowIndx < 0) return;

            DataRow row = this.Categories.Rows[rowIndx]; // 使用者點到的那一筆記錄
            int id = row.Field<int>("ID"); // 使用者點到的那一筆記錄的id值

            // 把 id 傳給編輯表單的建構函數
            var frm = new EditMonsterCategoryForm(id);
            // frm.Show();
            // DialogResult result = frm.ShowDialog();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DisplayMonsterCategory();
            }
        }
    }
}
