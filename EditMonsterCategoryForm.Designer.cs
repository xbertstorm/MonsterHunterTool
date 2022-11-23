namespace MonsterHunterTool
{
    partial class EditMonsterCategoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMonsterCategoryForm));
            this.monsterCategory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Update = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Add = new System.Windows.Forms.Button();
            this.monsterNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monsterNickNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monsterIndexVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterIndexVMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // monsterCategory
            // 
            this.monsterCategory.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.monsterCategory.Location = new System.Drawing.Point(171, 31);
            this.monsterCategory.Multiline = true;
            this.monsterCategory.Name = "monsterCategory";
            this.monsterCategory.Size = new System.Drawing.Size(189, 30);
            this.monsterCategory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "編輯魔物種類：";
            // 
            // Update
            // 
            this.Update.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Bold);
            this.Update.Location = new System.Drawing.Point(71, 81);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(134, 42);
            this.Update.TabIndex = 2;
            this.Update.Text = "更新";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Delete
            // 
            this.Delete.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Delete.Location = new System.Drawing.Point(226, 81);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(134, 42);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "刪除";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.monsterNameDataGridViewTextBoxColumn,
            this.monsterNickNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.monsterIndexVMBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(16, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(344, 130);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Add.Location = new System.Drawing.Point(226, 288);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(134, 41);
            this.Add.TabIndex = 5;
            this.Add.Text = "新增";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // monsterNameDataGridViewTextBoxColumn
            // 
            this.monsterNameDataGridViewTextBoxColumn.DataPropertyName = "MonsterName";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.monsterNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.monsterNameDataGridViewTextBoxColumn.HeaderText = "魔物名稱";
            this.monsterNameDataGridViewTextBoxColumn.Name = "monsterNameDataGridViewTextBoxColumn";
            this.monsterNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // monsterNickNameDataGridViewTextBoxColumn
            // 
            this.monsterNickNameDataGridViewTextBoxColumn.DataPropertyName = "MonsterNickName";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.monsterNickNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.monsterNickNameDataGridViewTextBoxColumn.HeaderText = "魔物別名";
            this.monsterNickNameDataGridViewTextBoxColumn.Name = "monsterNickNameDataGridViewTextBoxColumn";
            this.monsterNickNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // monsterIndexVMBindingSource
            // 
            this.monsterIndexVMBindingSource.DataSource = typeof(MonsterHunterTool.Models.ViewModels.MonsterIndexVM);
            // 
            // EditMonsterCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 340);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.monsterCategory);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditMonsterCategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "編輯魔物種類";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterIndexVMBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox monsterCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource monsterIndexVMBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn monsterNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monsterNickNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button Add;
    }
}