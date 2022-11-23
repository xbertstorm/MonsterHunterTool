namespace MonsterHunterTool
{
    partial class MonsterDropForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.monsterNickNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TheLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monsterDropIndexVMBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.monsterDropIndexVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.monsterVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Search = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.levelGapVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.monsterDropVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterDropIndexVMBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterDropIndexVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelGapVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterDropVMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.monsterNickNameDataGridViewTextBoxColumn,
            this.itemDataGridViewTextBoxColumn,
            this.TheLevel});
            this.dataGridView1.DataSource = this.monsterDropIndexVMBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(30, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(451, 332);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // monsterNickNameDataGridViewTextBoxColumn
            // 
            this.monsterNickNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.monsterNickNameDataGridViewTextBoxColumn.DataPropertyName = "MonsterNickName";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monsterNickNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.monsterNickNameDataGridViewTextBoxColumn.HeaderText = "魔物名稱";
            this.monsterNickNameDataGridViewTextBoxColumn.Name = "monsterNickNameDataGridViewTextBoxColumn";
            this.monsterNickNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.monsterNickNameDataGridViewTextBoxColumn.Width = 78;
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.itemDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemDataGridViewTextBoxColumn.HeaderText = "掉落物";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TheLevel
            // 
            this.TheLevel.DataPropertyName = "TheLevel";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TheLevel.DefaultCellStyle = dataGridViewCellStyle3;
            this.TheLevel.HeaderText = "難度";
            this.TheLevel.Name = "TheLevel";
            this.TheLevel.ReadOnly = true;
            // 
            // monsterDropIndexVMBindingSource1
            // 
            this.monsterDropIndexVMBindingSource1.DataSource = typeof(MonsterHunterTool.Models.ViewModels.MonsterDropIndexVM);
            // 
            // monsterDropIndexVMBindingSource
            // 
            this.monsterDropIndexVMBindingSource.DataSource = typeof(MonsterHunterTool.Models.ViewModels.MonsterDropIndexVM);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.monsterVMBindingSource;
            this.comboBox1.DisplayMember = "MonsterNickName";
            this.comboBox1.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(30, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "ID";
            // 
            // monsterVMBindingSource
            // 
            this.monsterVMBindingSource.DataSource = typeof(MonsterHunterTool.Models.ViewModels.MonsterVM);
            // 
            // Search
            // 
            this.Search.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Search.Location = new System.Drawing.Point(176, 25);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(95, 28);
            this.Search.TabIndex = 2;
            this.Search.Text = "搜尋";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.levelGapVMBindingSource;
            this.comboBox2.DisplayMember = "TheLevel";
            this.comboBox2.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(185, 406);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 28);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.ValueMember = "ID";
            this.comboBox2.Visible = false;
            // 
            // levelGapVMBindingSource
            // 
            this.levelGapVMBindingSource.DataSource = typeof(MonsterHunterTool.Models.ViewModels.LevelGapVM);
            // 
            // monsterDropVMBindingSource
            // 
            this.monsterDropVMBindingSource.DataSource = typeof(MonsterHunterTool.Models.ViewModels.MonsterDropVM);
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Add.Location = new System.Drawing.Point(391, 24);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(90, 28);
            this.Add.TabIndex = 3;
            this.Add.Text = "新增";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // MonsterDropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(795, 446);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MonsterDropForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "魔物掉落物";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterDropIndexVMBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterDropIndexVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelGapVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterDropVMBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource monsterDropIndexVMBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn monsterLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.BindingSource monsterVMBindingSource;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource monsterDropVMBindingSource;
        private System.Windows.Forms.BindingSource monsterDropIndexVMBindingSource1;
        private System.Windows.Forms.BindingSource levelGapVMBindingSource;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn monsterNickNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TheLevel;
    }
}