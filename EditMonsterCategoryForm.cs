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
using ISpan.Utility;
using MonsterHunterTool.Models.ViewModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MonsterHunterTool
{
    public partial class EditMonsterCategoryForm : Form
    {
        private int id;
        DataTable Categories;
        private MonsterIndexVM[] monsters = null;
        public EditMonsterCategoryForm(int id)
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            MaximizeBox = false;
            MinimizeBox = false;
            this.id = id;
            BindData(id);
        }
		private void BindData(int id)
		{
			string sql = "SELECT * FROM MonsterCategory WHERE ID=@ID";
			var parameters = new SqlParameterBuilder().AddInt("ID", id).Build();
			DataTable data = new SqlDbHelper("default").Select(sql, parameters);
			if (data.Rows.Count == 0)
			{
				MessageBox.Show("抱歉, 找不到要編輯的記錄");
				this.DialogResult = DialogResult.Abort;

				this.Close();
				return;
			}
			DataRow row = data.Rows[0];
			monsterCategory.Text = row.Field<string>("MonsterCategory");
            DisplayMonster();

        }
        private void Update_Click(object sender, EventArgs e)
        {
			string monstercategory = monsterCategory.Text;
			string sql = @"update MonsterCategory SET MonsterCategory=@MonsterCategory WHERE ID=@ID";
			var parameters = new SqlParameterBuilder().AddNVarchar("MonsterCategory", 50, monstercategory).AddInt("ID", this.id).Build();
			new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);
			this.DialogResult = DialogResult.OK;
		}
        private void Delete_Click(object sender, EventArgs e)
        {
			if (MessageBox.Show("確認是否要刪除?", "刪除記錄", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			string sql = "delete FROM MonsterCategory WHERE ID=@ID";
			var parameters = new SqlParameterBuilder().AddInt("ID", this.id).Build();
			new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);
			this.DialogResult = DialogResult.OK;
		}
        private void DisplayMonster()
        {
            string sql = "select M.ID, M.MonsterName, M.MonsterNickName, MC.MonsterCategory from Monster M left join MonsterCategory MC on M.CategoryID = MC.ID where MC.MonsterCategory=@MonsterCategory";

            SqlParameter[] parameters = new SqlParameter[] { };

            parameters = new SqlParameterBuilder().AddNVarchar("MonsterCategory", 50, monsterCategory.Text).Build();

            var dbHelper = new SqlDbHelper("default");
            monsters = dbHelper.Select(sql, parameters).AsEnumerable().Select(row => ParseToIndexVM(row)).ToArray();
            BindData(monsters);
        }
        private MonsterIndexVM ParseToIndexVM(DataRow row)
        {
            return new MonsterIndexVM
            {
                ID = row.Field<int>("ID"),
                MonsterCategory = row.Field<string>("MonsterCategory"),
                MonsterName = row.Field<string>("MonsterName"),
                MonsterNickName = row.Field<string>("MonsterNickName")
            };
        }
        private void BindData(MonsterIndexVM[] data)
        {
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndx = e.RowIndex;

            if (rowIndx < 0) return;

            MonsterIndexVM row = this.monsters[rowIndx]; // 使用者點到的那一筆記錄

            int id = row.ID; // 使用者點到的那一筆記錄的id值

            // 把 id 傳給編輯表單的建構函數
            var frm = new EditMonsterForm(id);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DisplayMonster();
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var frm = new CreateMonsterForm();
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                DisplayMonster();
            }
        }
    }
}
