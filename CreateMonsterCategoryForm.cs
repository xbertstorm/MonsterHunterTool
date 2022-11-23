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

namespace MonsterHunterTool
{
    public partial class CreateMonsterCategoryForm : Form
    {
        public CreateMonsterCategoryForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
        }
        private void Add_Click(object sender, EventArgs e)
        {
            string category = monsterCategory.Text;


            string sql = "INSERT INTO MonsterCategory (MonsterCategory) VALUES (@MonsterCategory)";

            var parameters = new SqlParameterBuilder().AddNVarchar("MonsterCategory", 50, category).Build();

            new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

            // MessageBox.Show("記錄已新增");
            this.DialogResult = DialogResult.OK;
        }
    }
}
