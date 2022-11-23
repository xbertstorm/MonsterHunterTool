using ISpan.Utility;
using MonsterHunterTool.Models.ViewModels;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MonsterHunterTool
{
    public partial class EditMonsterForm : Form
    {
        private int id;
        DataTable Categories;
        private MonsterDropIndexVM[] items = null;
        public EditMonsterForm(int id)
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            MaximizeBox = false;
            MinimizeBox= false;
            InitForm();
            //DisplayMonsterDrop();
            this.id = id;
        }
        private void InitForm()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            var sql = "select * from MonsterCategory";
            var dbHelper = new SqlDbHelper("default");
            List<MonsterCategoryVM> categories = dbHelper.Select(sql, null).AsEnumerable().Select(row => ToCategoryVM(row)).ToList();
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

        private void EditMonsterForm_Load(object sender, EventArgs e)
        {
            BindData(id);
        }
        private void BindData(int id)
        {
            string sql = "SELECT * FROM Monster WHERE ID=@ID";
            var parameters = new SqlParameterBuilder().AddInt("ID", id).Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            if (data.Rows.Count == 0)
            {
                MessageBox.Show("抱歉, 找不到要編輯的記錄");
                this.DialogResult = DialogResult.Abort;

                return;
            }

            // 將找到的一筆記錄由DataTable 轉換到 ProductVM
            MonsterVM model = ToProductVM(data.Rows[0]);

            // 再將 viewModel值繫結到各控制項
            comboBox1.SelectedItem = ((List<MonsterCategoryVM>)comboBox1.DataSource).FirstOrDefault(x => x.ID == model.CategoryID);

            textBox1.Text = model.MonsterName;
            textBox2.Text = model.MonsterNickName;
            DisplayMonsterDrop();
        }
        private MonsterVM ToProductVM(DataRow row)
        {
            return new MonsterVM
            {
                ID = row.Field<int>("ID"),
                CategoryID = row.Field<int>("CategoryID"),
                MonsterName = row.Field<string>("MonsterName"),
                MonsterNickName = row.Field<string>("MonsterNickName")
            };
        }

        private void Update_Click(object sender, EventArgs e)
        {
            // 取得表單的各欄位值
            int categoryId = ((MonsterCategoryVM)this.comboBox1.SelectedItem).ID;
            string monsterName = textBox1.Text;
            string monsterNickName = textBox2.Text;

            // 將它們繫結到ViewModel
            MonsterVM model = new MonsterVM
            {
                CategoryID = categoryId,
                MonsterName = monsterName,
                MonsterNickName = monsterNickName
            };

            // 針對ViewModel進行欄位驗證
            string errorMsg = string.Empty;
            if (string.IsNullOrEmpty(model.MonsterName)) errorMsg += "魔物名稱必填\r\n";
            if (string.IsNullOrEmpty(model.MonsterNickName)) errorMsg += "魔物別名必填\r\n";
            if (string.IsNullOrEmpty(errorMsg) == false)
            {
                //表示至少一欄有錯誤
                MessageBox.Show(errorMsg);
                return; // 不再向下執行
            }
            // update record
            string sql = "update Monster set CategoryID=@CategoryID, MonsterName=@MonsterName, MonsterNickName=@MonsterNickName where ID=@ID";

            var parameters = new SqlParameterBuilder().AddInt("CategoryID", model.CategoryID).AddNVarchar("MonsterName", 50, model.MonsterName).AddNVarchar("MonsterNickName", 50, model.MonsterNickName).AddInt("ID", this.id).Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            this.DialogResult = DialogResult.OK;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確認刪除？?", "刪除魔物", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            string sql = @"DELETE FROM Monster WHERE ID=@ID";

            var parameters = new SqlParameterBuilder()
                .AddInt("ID", this.id)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            this.DialogResult = DialogResult.OK;
        }
        private void DisplayMonsterDrop()
        {
            string sql = "select MD.ID, M.MonsterNickName, MD.Item, L.TheLevel from MonsterDrop MD left join Monster M on MD.MonsterID = M.ID left join LevelGap L on MD.MonsterLevel = L.ID WHERE M.MonsterNickName=@MonsterNickName";

            SqlParameter[] parameters = new SqlParameter[] { };

            parameters = new SqlParameterBuilder().AddNVarchar("MonsterNickName", 50, textBox2.Text).Build();

            var dbHelper = new SqlDbHelper("default");
            // 存放在field裡, 稍後在 grid CellClick事件會需要再度用到它
            items = dbHelper.Select(sql, parameters).AsEnumerable().Select(row => ParseToIndexVM(row)).ToArray();
            BindData(items);
        }
        private MonsterDropIndexVM ParseToIndexVM(DataRow row)
        {
            return new MonsterDropIndexVM
            {
                ID = row.Field<int>("ID"),
                MonsterNickName = row.Field<string>("MonsterNickName"),
                Item = row.Field<string>("Item"),
                TheLevel = row.Field<string>("TheLevel")
            };
        }
        private void BindData(MonsterDropIndexVM[] data)
        {
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndx = e.RowIndex;

            if (rowIndx < 0) return;

            MonsterDropIndexVM row = this.items[rowIndx]; // 使用者點到的那一筆記錄

            int id = row.ID; // 使用者點到的那一筆記錄的id值

            // 把 id 傳給編輯表單的建構函數
            var frm = new EditMonsterDropForm(id);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DisplayMonsterDrop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new CreateMonsterDropForm();
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                DisplayMonsterDrop();
            }
        }
    }
}
