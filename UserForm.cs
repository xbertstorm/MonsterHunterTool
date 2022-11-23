using MonsterHunterTool.Infra.DAOs;
using MonsterHunterTool.Models.DTOs;
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
    public partial class UserForm : Form
    {
        private UserIndexVM[] users = null;
        public UserForm()
        {
            InitializeComponent();
            MaximizeBox= false;
            MinimizeBox= false;
            DisplayUsers();
        }
        private void DisplayUsers()
        {
            users = new UserDAO().GetAll().Select(dto => dto.ToIndexVM()).ToArray();
            BindData(users);
        }
        private void BindData(UserIndexVM[] data)
        {
            dataGridView1.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new CreateUserForm();
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                DisplayUsers();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndx = e.RowIndex;

            if (rowIndx < 0) return;

            UserIndexVM row = this.users[rowIndx]; // 使用者點到的那一筆記錄

            int id = row.ID; // 使用者點到的那一筆記錄的id值

            // 把 id 傳給編輯表單的建構函數
            var frm = new EditUserForm(id);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DisplayUsers();
            }
        }
    }
}
