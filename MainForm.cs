using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MonsterHunterTool
{
    public partial class MainForm : Form
    {
        private string username = string.Empty;
        public string String1
        {
            set
            {
                username = value;
            }
        }
        public void SetValue()
        {
            this.label1.Text = "Welcome " + username;
        }
        public MainForm()
        {
            InitializeComponent();
            MaximizeBox= false;
            MinimizeBox= false;
        }
        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0) this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel= false;
            f.Dock= DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //var frm = new LoadingForm2();
            //frm.Show();
            loadform(new MonsterCategoryForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new LoadingForm2();
            frm.Show();
            loadform(new MonsterForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform(new UserForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("您確定要登出嗎?", "登出", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //var frm = new LoadingForm2();
            //frm.Show();
            loadform(new MonsterDropForm());
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i += 1;
            //if (i > 2.5) loadform(new MonsterCategoryForm());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
