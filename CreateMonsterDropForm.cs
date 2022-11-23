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
    public partial class CreateMonsterDropForm : Form
    {
        public CreateMonsterDropForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            InitForm();
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

        private void Add_Click(object sender, EventArgs e)
        {
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
            if (string.IsNullOrEmpty(model.Item)) errorMsg += "素材名稱必填\r\n";
            if (string.IsNullOrEmpty(errorMsg) == false)
            {
                //表示至少一欄有錯誤
                MessageBox.Show(errorMsg);
                return; // 不再向下執行
            }

            // 如果通過驗證,就新增記錄
            string sql = "insert into MonsterDrop (MonsterID, Item, MonsterLevel) values (@MonsterID, @Item, @MonsterLevel)";

            var parameters = new SqlParameterBuilder().AddInt("MonsterID", model.MonsterID).AddNVarchar("Item", 50, model.Item).AddInt("MonsterLevel", model.MonsterLevel).Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            this.DialogResult = DialogResult.OK;
        }
    }
}
