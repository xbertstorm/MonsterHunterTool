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

namespace MonsterHunterTool
{
    public partial class CreateMonsterForm : Form
    {
        public CreateMonsterForm()
        {
            InitializeComponent();
            MaximizeBox= false;
            MinimizeBox= false;
            InitForm();
        }
        private void InitForm()
        {
            // 設定 categoryIdComboBox property
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            var sql = "SELECT * FROM MonsterCategory";
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
        private void Add_Click(object sender, EventArgs e)
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

            // 如果通過驗證,就新增記錄
            string sql = "insert into Monster (CategoryID, MonsterName, MonsterNickName) values (@CategoryID, @MonsterName, @MonsterNickName)";

            var parameters = new SqlParameterBuilder().AddInt("CategoryID", model.CategoryID).AddNVarchar("MonsterName", 50, model.MonsterName).AddNVarchar("MonsterNickName", 50, model.MonsterNickName).Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            this.DialogResult = DialogResult.OK;
        }
    }
}
