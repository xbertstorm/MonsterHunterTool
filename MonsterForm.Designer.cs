namespace MonsterHunterTool
{
    partial class MonsterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.monsterCategoryVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Search = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.monsterIndexVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Add = new System.Windows.Forms.Button();
            this.monsterNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monsterNickNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monsterCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.monsterCategoryVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterIndexVMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.monsterCategoryVMBindingSource;
            this.comboBox1.DisplayMember = "Monstercategory";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(14, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "ID";
            // 
            // monsterCategoryVMBindingSource
            // 
            this.monsterCategoryVMBindingSource.DataSource = typeof(MonsterHunterTool.Models.ViewModels.MonsterCategoryVM);
            // 
            // Search
            // 
            this.Search.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Search.Location = new System.Drawing.Point(154, 20);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(90, 32);
            this.Search.TabIndex = 1;
            this.Search.Text = "搜尋";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.monsterNameDataGridViewTextBoxColumn,
            this.monsterNickNameDataGridViewTextBoxColumn,
            this.monsterCategoryDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.monsterIndexVMBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(14, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(437, 303);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // monsterIndexVMBindingSource
            // 
            this.monsterIndexVMBindingSource.DataSource = typeof(MonsterHunterTool.Models.ViewModels.MonsterIndexVM);
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Add.Location = new System.Drawing.Point(361, 21);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(90, 32);
            this.Add.TabIndex = 1;
            this.Add.Text = "新增";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // monsterNameDataGridViewTextBoxColumn
            // 
            this.monsterNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.monsterNameDataGridViewTextBoxColumn.DataPropertyName = "MonsterName";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.monsterNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.monsterNameDataGridViewTextBoxColumn.FillWeight = 99.49239F;
            this.monsterNameDataGridViewTextBoxColumn.HeaderText = "魔物名稱";
            this.monsterNameDataGridViewTextBoxColumn.Name = "monsterNameDataGridViewTextBoxColumn";
            this.monsterNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.monsterNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // monsterNickNameDataGridViewTextBoxColumn
            // 
            this.monsterNickNameDataGridViewTextBoxColumn.DataPropertyName = "MonsterNickName";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.monsterNickNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.monsterNickNameDataGridViewTextBoxColumn.FillWeight = 99.49239F;
            this.monsterNickNameDataGridViewTextBoxColumn.HeaderText = "魔物別名";
            this.monsterNickNameDataGridViewTextBoxColumn.Name = "monsterNickNameDataGridViewTextBoxColumn";
            this.monsterNickNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // monsterCategoryDataGridViewTextBoxColumn
            // 
            this.monsterCategoryDataGridViewTextBoxColumn.DataPropertyName = "MonsterCategory";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.monsterCategoryDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.monsterCategoryDataGridViewTextBoxColumn.FillWeight = 99.49239F;
            this.monsterCategoryDataGridViewTextBoxColumn.HeaderText = "魔物種類";
            this.monsterCategoryDataGridViewTextBoxColumn.Name = "monsterCategoryDataGridViewTextBoxColumn";
            this.monsterCategoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // MonsterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(468, 411);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MonsterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "魔物列表";
            ((System.ComponentModel.ISupportInitialize)(this.monsterCategoryVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterIndexVMBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource monsterIndexVMBindingSource;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.BindingSource monsterCategoryVMBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn monsterNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monsterNickNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monsterCategoryDataGridViewTextBoxColumn;
    }
}