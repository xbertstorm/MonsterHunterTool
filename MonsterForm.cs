using ISpan.Utility;
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
using MonsterHunterTool.Models.ViewModels;

namespace MonsterHunterTool
{
    public partial class MonsterForm : Form
    {
		DataTable Categories;
		private MonsterIndexVM[] monsters = null;
		public MonsterForm()
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            InitForm();
			DisplayMonster();
        }
        private void InitForm()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            var sql = "SELECT * FROM MonsterCategory";
            var dbHelper = new SqlDbHelper("default");

            List<MonsterCategoryVM> categories = dbHelper.Select(sql, null)
                .AsEnumerable()
                .Select(row => ToCategoryVM(row))
                .Prepend(new MonsterCategoryVM { ID = 0, Monstercategory = String.Empty })
                .ToList();

            this.comboBox1.DataSource = categories;
        }
        private MonsterCategoryVM ToCategoryVM(DataRow row)
        {
            return new MonsterCategoryVM
            {
                ID = row.Field<int>("ID"),
                Monstercategory = row.Field<string>("Monstercategory"),
            };
        }
        private void DisplayMonster()
		{
            string sql = "select M.ID, M.MonsterName, M.MonsterNickName, MC.MonsterCategory from Monster M left join MonsterCategory MC on M.CategoryID = MC.ID";

            #region 加入 where 
            SqlParameter[] parameters = new SqlParameter[] { };

            ////取得篩選值
            int categoryId = ((MonsterCategoryVM)comboBox1.SelectedItem).ID;

            if (categoryId > 0)
            {
                sql += " WHERE M.CategoryID=@CategoryID";
                parameters = new SqlParameterBuilder().AddInt("CategoryID", categoryId).Build();
            }
            #endregion

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
		private void Search_Click(object sender, EventArgs e)
        {
            DisplayMonster();
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
    }
}
