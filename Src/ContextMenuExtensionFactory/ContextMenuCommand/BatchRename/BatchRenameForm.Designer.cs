namespace ContextMenuExtensionFactory.ContextMenuCommand
{
    partial class BatchRenameForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchRenameForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RenameSettingGroupBox = new System.Windows.Forms.GroupBox();
            this.PreviewButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CancelRenameButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.StartNumTextBox = new System.Windows.Forms.TextBox();
            this.ReNameStyleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PreviewGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SeleteAllCheckBox = new System.Windows.Forms.CheckBox();
            this.OnlyJPGCheckBox = new System.Windows.Forms.CheckBox();
            this.OnlyBMPCheckBox = new System.Windows.Forms.CheckBox();
            this.OnlyPNGCheckBox = new System.Windows.Forms.CheckBox();
            this.PreviewDataGridView = new CustomControls.RowDragDataGridView();
            this.IsSelectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OldNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.RenameSettingGroupBox.SuspendLayout();
            this.PreviewGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // RenameSettingGroupBox
            // 
            this.RenameSettingGroupBox.Controls.Add(this.PreviewButton);
            this.RenameSettingGroupBox.Controls.Add(this.textBox3);
            this.RenameSettingGroupBox.Controls.Add(this.label3);
            this.RenameSettingGroupBox.Controls.Add(this.CancelRenameButton);
            this.RenameSettingGroupBox.Controls.Add(this.ApplyButton);
            this.RenameSettingGroupBox.Controls.Add(this.label2);
            this.RenameSettingGroupBox.Controls.Add(this.StartNumTextBox);
            this.RenameSettingGroupBox.Controls.Add(this.ReNameStyleTextBox);
            this.RenameSettingGroupBox.Controls.Add(this.label1);
            this.RenameSettingGroupBox.Location = new System.Drawing.Point(12, 5);
            this.RenameSettingGroupBox.Name = "RenameSettingGroupBox";
            this.RenameSettingGroupBox.Size = new System.Drawing.Size(693, 90);
            this.RenameSettingGroupBox.TabIndex = 0;
            this.RenameSettingGroupBox.TabStop = false;
            this.RenameSettingGroupBox.Text = "命名设置";
            // 
            // PreviewButton
            // 
            this.PreviewButton.Location = new System.Drawing.Point(185, 62);
            this.PreviewButton.Name = "PreviewButton";
            this.PreviewButton.Size = new System.Drawing.Size(75, 23);
            this.PreviewButton.TabIndex = 7;
            this.PreviewButton.Text = "预览";
            this.PreviewButton.UseVisualStyleBackColor = true;
            this.PreviewButton.Click += new System.EventHandler(this.PreviewButton_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox3.ForeColor = System.Drawing.Color.Purple;
            this.textBox3.Location = new System.Drawing.Point(449, 14);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(238, 69);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = resources.GetString("textBox3.Text");
            this.MainToolTip.SetToolTip(this.textBox3, resources.GetString("textBox3.ToolTip"));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "例:1或者0005.";
            // 
            // CancelRenameButton
            // 
            this.CancelRenameButton.Location = new System.Drawing.Point(368, 62);
            this.CancelRenameButton.Name = "CancelRenameButton";
            this.CancelRenameButton.Size = new System.Drawing.Size(75, 23);
            this.CancelRenameButton.TabIndex = 4;
            this.CancelRenameButton.Text = "退出";
            this.CancelRenameButton.UseVisualStyleBackColor = true;
            this.CancelRenameButton.Click += new System.EventHandler(this.CancelRenameButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(278, 62);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 4;
            this.ApplyButton.Text = "应用";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "起始数字:";
            // 
            // StartNumTextBox
            // 
            this.StartNumTextBox.Location = new System.Drawing.Point(77, 38);
            this.StartNumTextBox.Name = "StartNumTextBox";
            this.StartNumTextBox.Size = new System.Drawing.Size(135, 21);
            this.StartNumTextBox.TabIndex = 2;
            this.StartNumTextBox.Text = "001";
            this.MainToolTip.SetToolTip(this.StartNumTextBox, "必须是数字");
            // 
            // ReNameStyleTextBox
            // 
            this.ReNameStyleTextBox.Location = new System.Drawing.Point(77, 14);
            this.ReNameStyleTextBox.Name = "ReNameStyleTextBox";
            this.ReNameStyleTextBox.Size = new System.Drawing.Size(366, 21);
            this.ReNameStyleTextBox.TabIndex = 1;
            this.ReNameStyleTextBox.Text = "<O><*>";
            this.MainToolTip.SetToolTip(this.ReNameStyleTextBox, "例如:<*>新名称<O>");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "命名样式:";
            // 
            // PreviewGroupBox
            // 
            this.PreviewGroupBox.Controls.Add(this.label5);
            this.PreviewGroupBox.Controls.Add(this.SeleteAllCheckBox);
            this.PreviewGroupBox.Controls.Add(this.OnlyJPGCheckBox);
            this.PreviewGroupBox.Controls.Add(this.OnlyBMPCheckBox);
            this.PreviewGroupBox.Controls.Add(this.OnlyPNGCheckBox);
            this.PreviewGroupBox.Controls.Add(this.PreviewDataGridView);
            this.PreviewGroupBox.Location = new System.Drawing.Point(12, 101);
            this.PreviewGroupBox.Name = "PreviewGroupBox";
            this.PreviewGroupBox.Size = new System.Drawing.Size(695, 311);
            this.PreviewGroupBox.TabIndex = 1;
            this.PreviewGroupBox.TabStop = false;
            this.PreviewGroupBox.Text = "文件选择及命名预览(支持拖放调整顺序)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "|";
            // 
            // SeleteAllCheckBox
            // 
            this.SeleteAllCheckBox.AutoSize = true;
            this.SeleteAllCheckBox.Location = new System.Drawing.Point(184, 289);
            this.SeleteAllCheckBox.Name = "SeleteAllCheckBox";
            this.SeleteAllCheckBox.Size = new System.Drawing.Size(48, 16);
            this.SeleteAllCheckBox.TabIndex = 4;
            this.SeleteAllCheckBox.Text = "全选";
            this.SeleteAllCheckBox.UseVisualStyleBackColor = true;
            this.SeleteAllCheckBox.CheckedChanged += new System.EventHandler(this.SeleteAllCheckBox_CheckedChanged);
            // 
            // OnlyJPGCheckBox
            // 
            this.OnlyJPGCheckBox.AutoSize = true;
            this.OnlyJPGCheckBox.Location = new System.Drawing.Point(114, 290);
            this.OnlyJPGCheckBox.Name = "OnlyJPGCheckBox";
            this.OnlyJPGCheckBox.Size = new System.Drawing.Size(42, 16);
            this.OnlyJPGCheckBox.TabIndex = 2;
            this.OnlyJPGCheckBox.Text = "JPG";
            this.OnlyJPGCheckBox.UseVisualStyleBackColor = true;
            this.OnlyJPGCheckBox.CheckedChanged += new System.EventHandler(this.OnlyJPGCheckBox_CheckedChanged);
            // 
            // OnlyBMPCheckBox
            // 
            this.OnlyBMPCheckBox.AutoSize = true;
            this.OnlyBMPCheckBox.Checked = true;
            this.OnlyBMPCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OnlyBMPCheckBox.Location = new System.Drawing.Point(59, 290);
            this.OnlyBMPCheckBox.Name = "OnlyBMPCheckBox";
            this.OnlyBMPCheckBox.Size = new System.Drawing.Size(42, 16);
            this.OnlyBMPCheckBox.TabIndex = 2;
            this.OnlyBMPCheckBox.Text = "BMP";
            this.OnlyBMPCheckBox.UseVisualStyleBackColor = true;
            this.OnlyBMPCheckBox.CheckedChanged += new System.EventHandler(this.OnlyBMPCheckBox_CheckedChanged);
            // 
            // OnlyPNGCheckBox
            // 
            this.OnlyPNGCheckBox.AutoSize = true;
            this.OnlyPNGCheckBox.Checked = true;
            this.OnlyPNGCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OnlyPNGCheckBox.Location = new System.Drawing.Point(4, 290);
            this.OnlyPNGCheckBox.Name = "OnlyPNGCheckBox";
            this.OnlyPNGCheckBox.Size = new System.Drawing.Size(42, 16);
            this.OnlyPNGCheckBox.TabIndex = 1;
            this.OnlyPNGCheckBox.Text = "PNG";
            this.OnlyPNGCheckBox.UseVisualStyleBackColor = true;
            this.OnlyPNGCheckBox.CheckedChanged += new System.EventHandler(this.OnlyPNGCheckBox_CheckedChanged);
            // 
            // PreviewDataGridView
            // 
            this.PreviewDataGridView.AllowUserToAddRows = false;
            this.PreviewDataGridView.AllowUserToDeleteRows = false;
            this.PreviewDataGridView.AllowUserToResizeRows = false;
            this.PreviewDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.PreviewDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PreviewDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsSelectColumn,
            this.OldNameColumn,
            this.NewNameColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PreviewDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.PreviewDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.PreviewDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.PreviewDataGridView.Location = new System.Drawing.Point(3, 17);
            this.PreviewDataGridView.MultiSelect = false;
            this.PreviewDataGridView.Name = "PreviewDataGridView";
            this.PreviewDataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PreviewDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.PreviewDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.PreviewDataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            this.PreviewDataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.PreviewDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Window;
            this.PreviewDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.PreviewDataGridView.RowTemplate.Height = 23;
            this.PreviewDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PreviewDataGridView.ShowColumnHeaderWhileDragging = true;
            this.PreviewDataGridView.Size = new System.Drawing.Size(689, 267);
            this.PreviewDataGridView.TabIndex = 0;
            // 
            // IsSelectColumn
            // 
            this.IsSelectColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsSelectColumn.HeaderText = "是否更名";
            this.IsSelectColumn.Name = "IsSelectColumn";
            this.IsSelectColumn.ReadOnly = true;
            this.IsSelectColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsSelectColumn.Width = 78;
            // 
            // OldNameColumn
            // 
            this.OldNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OldNameColumn.HeaderText = "原名";
            this.OldNameColumn.Name = "OldNameColumn";
            this.OldNameColumn.ReadOnly = true;
            // 
            // NewNameColumn
            // 
            this.NewNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NewNameColumn.HeaderText = "新名称";
            this.NewNameColumn.Name = "NewNameColumn";
            this.NewNameColumn.ReadOnly = true;
            this.NewNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BatchRenameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 421);
            this.Controls.Add(this.PreviewGroupBox);
            this.Controls.Add(this.RenameSettingGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchRenameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量重命名";
            this.RenameSettingGroupBox.ResumeLayout(false);
            this.RenameSettingGroupBox.PerformLayout();
            this.PreviewGroupBox.ResumeLayout(false);
            this.PreviewGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox RenameSettingGroupBox;
        private System.Windows.Forms.GroupBox PreviewGroupBox;
        private CustomControls.RowDragDataGridView PreviewDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ReNameStyleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox StartNumTextBox;
        private System.Windows.Forms.Button CancelRenameButton;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ToolTip MainToolTip;
        private System.Windows.Forms.Button PreviewButton;
        private System.Windows.Forms.CheckBox OnlyBMPCheckBox;
        private System.Windows.Forms.CheckBox OnlyPNGCheckBox;
        private System.Windows.Forms.CheckBox SeleteAllCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox OnlyJPGCheckBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewNameColumn;
    }
}