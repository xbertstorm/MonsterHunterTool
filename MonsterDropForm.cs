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
    public partial class MonsterDropForm : Form
    {
        DataTable Categories;
        private MonsterDropIndexVM[] items = null;
        public MonsterDropForm()
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            MaximizeBox = false;
            MinimizeBox = false;
            InitForm();
            DisplayMonsterDrop();
        }
        private void InitForm()
        {
            // 設定 categoryIdComboBox property
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            var sql = "SELECT * FROM Monster";
            var dbHelper = new SqlDbHelper("default");
            List<MonsterVM> monstername = dbHelper.Select(sql, null)
                .AsEnumerable()
                .Select(row => ToMonsterVM(row))
                .Prepend(new MonsterVM { ID = 0, MonsterNickName = String.Empty })
                .ToList();


            var sql2 = "SELECT * FROM LevelGap";
            var cc = new SqlDbHelper("default");
            List<LevelGapVM> level = cc.Select(sql2, null)
                .AsEnumerable()
                .Select(row => ToLevelVM(row))
                .Prepend(new LevelGapVM { ID = 0, TheLevel = String.Empty })
                .ToList();

            this.comboBox1.DataSource = monstername;
            this.comboBox2.DataSource = level;
        }
        private MonsterVM ToMonsterVM(DataRow row)
        {
            return new MonsterVM
            {
                ID = row.Field<int>("ID"),
                MonsterNickName = row.Field<string>("MonsterNickName"),
            };
        }
        private LevelGapVM ToLevelVM(DataRow row)
        {
            return new LevelGapVM
            {
                ID = row.Field<int>("ID"),
                TheLevel = row.Field<string>("TheLevel"),
            };
        }
        private void DisplayMonsterDrop()
        {
            string sql = "select MD.ID, M.MonsterNickName, MD.Item, L.TheLevel from MonsterDrop MD left join Monster M on MD.MonsterID = M.ID left join LevelGap L on MD.MonsterLevel = L.ID";

            #region 加入 where 
            SqlParameter[] parameters = new SqlParameter[] { };

            ////取得篩選值
            int monsterId = ((MonsterVM)comboBox1.SelectedItem).ID;
            int level = ((LevelGapVM)comboBox2.SelectedItem).ID;

            //if (level > 0)
            //{
            //    sql += " WHERE MonsterLevel=@MonsterLevel";
            //    parameters = new SqlParameterBuilder().AddInt("MonsterLevel", level).Build();
            //}
            if (monsterId > 0)
            {
                sql += " WHERE MonsterID=@MonsterID";
                parameters = new SqlParameterBuilder().AddInt("MonsterID", monsterId).Build();
            }
            #endregion

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

        private void Search_Click(object sender, EventArgs e)
        {
            DisplayMonsterDrop();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var frm = new CreateMonsterDropForm();
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                DisplayMonsterDrop();
            }
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
    }
}
