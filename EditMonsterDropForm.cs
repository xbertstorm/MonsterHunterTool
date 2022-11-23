using ISpan.Utility;
using MonsterHunterTool.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MonsterHunterTool
{
    public partial class EditMonsterDropForm : Form
    {
        private int id;
        public EditMonsterDropForm(int id)
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            InitForm();
            this.id = id;
        }
        private void InitForm()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            var sql = "SELECT * FROM Monster";
            var dbHelper = new SqlDbHelper("default");
            List<MonsterVM> monsters = dbHelper.Select(sql, null).AsEnumerable().Select(row => ToMonsterVM(row)).ToList();

            var sql2 = "select * from LevelGap";
            List<LevelGapVM> level = dbHelper.Select(sql2, null).AsEnumerable().Select(row => ToLevelVM(row)).ToList();

            this.comboBox1.DataSource = monsters;
            this.comboBox2.DataSource = level;
        }
        private MonsterVM ToMonsterVM(DataRow row)
        {
            return new MonsterVM
            {
                ID = row.Field<int>("ID"),
                MonsterNickName = row.Field<string>("MonsterNickName")
            };
        }
        private LevelGapVM ToLevelVM(DataRow row)
        {
            return new LevelGapVM
            {
                ID = row.Field<int>("ID"),
                TheLevel = row.Field<string>("TheLevel")
            };
        }

        private void EditMonsterDropForm_Load(object sender, EventArgs e)
        {
            BindData(id);
        }
        private void BindData(int id)
        {
            string sql = "SELECT * FROM MonsterDrop WHERE ID=@ID";
            var parameters = new SqlParameterBuilder().AddInt("ID", id).Build();

            DataTable data = new SqlDbHelper("default").Select(sql, parameters);

            if (data.Rows.Count == 0)
            {
                MessageBox.Show("抱歉, 找不到要編輯的記錄");
                this.DialogResult = DialogResult.Abort;

                return;
            }

            // 將找到的一筆記錄由DataTable 轉換到 ProductVM
            MonsterDropVM model = ToProductVM(data.Rows[0]);

            // 再將 viewModel值繫結到各控制項
            comboBox1.SelectedItem = ((List<MonsterVM>)comboBox1.DataSource).FirstOrDefault(x => x.ID == model.MonsterID);
            comboBox2.SelectedItem = ((List<LevelGapVM>)comboBox2.DataSource).FirstOrDefault(x => x.ID == model.MonsterLevel);
            textBox1.Text = model.Item;
        }
        private MonsterDropVM ToProductVM(DataRow row)
        {
            return new MonsterDropVM
            {
                ID = row.Field<int>("ID"),
                MonsterID = row.Field<int>("MonsterID"),
                Item = row.Field<string>("Item"),
                MonsterLevel = row.Field<int>("MonsterLevel")
            };
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確認刪除？?", "刪除魔物素材", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            string sql = @"DELETE FROM MonsterDrop WHERE ID=@ID";

            var parameters = new SqlParameterBuilder()
                .AddInt("ID", this.id)
                .Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            this.DialogResult = DialogResult.OK;
        }
        private void Update_Click(object sender, EventArgs e)
        {
            // 取得表單的各欄位值
            int monsterId = ((MonsterVM)this.comboBox1.SelectedItem).ID;
            string monsterDrop = textBox1.Text;
            int levelId = ((LevelGapVM)this.comboBox2.SelectedItem).ID;

            // 將它們繫結到ViewModel
            MonsterDropVM model = new MonsterDropVM
            {
               MonsterID = monsterId,
               Item = monsterDrop,
               MonsterLevel = levelId
            };

            // 針對ViewModel進行欄位驗證
            string errorMsg = string.Empty;
            if (string.IsNullOrEmpty(model.Item)) errorMsg += "魔物素材必填\r\n";
            if (string.IsNullOrEmpty(errorMsg) == false)
            {
                //表示至少一欄有錯誤
                MessageBox.Show(errorMsg);
                return; // 不再向下執行
            }
            // update record
            string sql = "update MonsterDrop set MonsterID=@MonsterID, Item=@Item, MonsterLevel=@MonsterLevel where ID=@ID";

            var parameters = new SqlParameterBuilder().AddInt("MonsterID", model.MonsterID).AddNVarchar("Item", 50, model.Item).AddInt("MonsterLevel", model.MonsterLevel).AddInt("ID", this.id).Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            this.DialogResult = DialogResult.OK;
        }
    }
}
