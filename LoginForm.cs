using MonsterHunterTool.Infra;
using MonsterHunterTool.Models.Services;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MonsterHunterTool
{
    public partial class LoginForm : Form
    {
        private string username = string.Empty;
        public LoginForm()
        {
            InitializeComponent();
            MaximizeBox= false;
            MinimizeBox= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 將表單欄位值繫結到view model
            LoginVM model = new LoginVM
            {
                Account = textBox1.Text,
                Password = textBox2.Text
            };
            // 驗證欄位輸入是否正確
            Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"Account", textBox1},
                {"Password", textBox2},
            };
            bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            if (!isValid) return;
            // 判斷帳密是否正確
            bool result = new UserService().Authenticate(model);
            if (result == false)
            {
                MessageBox.Show("帳號或密碼錯誤");
                return;
            }
            // 若正確, 就開啟MainForm
            username = textBox1.Text;
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;

            var frm = new MainForm();
            frm.Owner = this;

            frm.Show();
            frm.String1 = username;
            frm.SetValue();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new CreateUserForm();
            DialogResult result = frm.ShowDialog();
        }
    }
}
