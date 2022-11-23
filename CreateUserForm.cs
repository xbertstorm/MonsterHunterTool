using MonsterHunterTool.Infra;
using MonsterHunterTool.Models.DTOs;
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

namespace MonsterHunterTool
{
    public partial class CreateUserForm : Form
    {
        public CreateUserForm()
        {
            InitializeComponent();
            MaximizeBox= false;
            MinimizeBox= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string account = textBox1.Text;
            string password = textBox2.Text;
            string username = textBox3.Text;

            // 將它們繫結到ViewModel
            UserVM model = new UserVM
            {
                Account = account,
                Password = password,
                UserName = username,
            };

            // 針對ViewModel進行欄位驗證
            Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"Account", textBox1},
                {"Password", textBox2},
                {"UserName", textBox3},
            };

            bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
            if (!isValid) return;


            // 如果通過驗證,就新增記錄
            // 將ViewModel轉成DTO
            UserDTO dto = model.ToDTO();


            try
            {
                new UserService().Create(dto);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗, 原因: " + ex.Message);
            }
        }
    }
}
