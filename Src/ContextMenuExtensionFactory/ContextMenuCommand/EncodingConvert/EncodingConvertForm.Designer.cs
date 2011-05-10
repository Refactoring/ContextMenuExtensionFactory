namespace ContextMenuExtensionFactory.ContextMenuCommand
{
    partial class EncodingConvertForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SeleteAllCheckBox = new System.Windows.Forms.CheckBox();
            this.OnlyCSCheckBox = new System.Windows.Forms.CheckBox();
            this.OnlyHCheckBox = new System.Windows.Forms.CheckBox();
            this.OnlyCCheckBox = new System.Windows.Forms.CheckBox();
            this.PreviewGroupBox = new System.Windows.Forms.GroupBox();
            this.SubDirectoryTraversalCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OnlyCPPCheckBox = new System.Windows.Forms.CheckBox();
            this.OnlyTXTCheckBox = new System.Windows.Forms.CheckBox();
            this.PreviewDataGridView = new System.Windows.Forms.DataGridView();
            this.IsSelectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EncodingColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CancelChangeButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.EncodingSettingGroupBox = new System.Windows.Forms.GroupBox();
            this.SearchPatternTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EncodingListComboBox = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PreviewGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewDataGridView)).BeginInit();
            this.EncodingSettingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SeleteAllCheckBox
            // 
            this.SeleteAllCheckBox.AutoSize = true;
            this.SeleteAllCheckBox.Location = new System.Drawing.Point(254, 231);
            this.SeleteAllCheckBox.Name = "SeleteAllCheckBox";
            this.SeleteAllCheckBox.Size = new System.Drawing.Size(48, 16);
            this.SeleteAllCheckBox.TabIndex = 4;
            this.SeleteAllCheckBox.Text = "全选";
            this.SeleteAllCheckBox.UseVisualStyleBackColor = true;
            this.SeleteAllCheckBox.CheckedChanged += new System.EventHandler(this.SeleteAllCheckBox_CheckedChanged);
            // 
            // OnlyCSCheckBox
            // 
            this.OnlyCSCheckBox.AutoSize = true;
            this.OnlyCSCheckBox.Location = new System.Drawing.Point(153, 231);
            this.OnlyCSCheckBox.Name = "OnlyCSCheckBox";
            this.OnlyCSCheckBox.Size = new System.Drawing.Size(42, 16);
            this.OnlyCSCheckBox.TabIndex = 2;
            this.OnlyCSCheckBox.Text = ".cs";
            this.OnlyCSCheckBox.UseVisualStyleBackColor = true;
            this.OnlyCSCheckBox.CheckedChanged += new System.EventHandler(this.OnlyCSCheckBox_CheckedChanged);
            // 
            // OnlyHCheckBox
            // 
            this.OnlyHCheckBox.AutoSize = true;
            this.OnlyHCheckBox.Location = new System.Drawing.Point(109, 231);
            this.OnlyHCheckBox.Name = "OnlyHCheckBox";
            this.OnlyHCheckBox.Size = new System.Drawing.Size(36, 16);
            this.OnlyHCheckBox.TabIndex = 2;
            this.OnlyHCheckBox.Text = ".h";
            this.OnlyHCheckBox.UseVisualStyleBackColor = true;
            this.OnlyHCheckBox.CheckedChanged += new System.EventHandler(this.OnlyHCheckBox_CheckedChanged);
            // 
            // OnlyCCheckBox
            // 
            this.OnlyCCheckBox.AutoSize = true;
            this.OnlyCCheckBox.Location = new System.Drawing.Point(9, 231);
            this.OnlyCCheckBox.Name = "OnlyCCheckBox";
            this.OnlyCCheckBox.Size = new System.Drawing.Size(36, 16);
            this.OnlyCCheckBox.TabIndex = 1;
            this.OnlyCCheckBox.Text = ".c";
            this.OnlyCCheckBox.UseVisualStyleBackColor = true;
            this.OnlyCCheckBox.CheckedChanged += new System.EventHandler(this.OnlyCCheckBox_CheckedChanged);
            // 
            // PreviewGroupBox
            // 
            this.PreviewGroupBox.Controls.Add(this.SubDirectoryTraversalCheckBox);
            this.PreviewGroupBox.Controls.Add(this.label2);
            this.PreviewGroupBox.Controls.Add(this.OnlyCPPCheckBox);
            this.PreviewGroupBox.Controls.Add(this.SeleteAllCheckBox);
            this.PreviewGroupBox.Controls.Add(this.OnlyTXTCheckBox);
            this.PreviewGroupBox.Controls.Add(this.OnlyCSCheckBox);
            this.PreviewGroupBox.Controls.Add(this.OnlyHCheckBox);
            this.PreviewGroupBox.Controls.Add(this.OnlyCCheckBox);
            this.PreviewGroupBox.Controls.Add(this.PreviewDataGridView);
            this.PreviewGroupBox.Location = new System.Drawing.Point(12, 97);
            this.PreviewGroupBox.Name = "PreviewGroupBox";
            this.PreviewGroupBox.Size = new System.Drawing.Size(577, 253);
            this.PreviewGroupBox.TabIndex = 3;
            this.PreviewGroupBox.TabStop = false;
            this.PreviewGroupBox.Text = "文件选择";
            // 
            // SubDirectoryTraversalCheckBox
            // 
            this.SubDirectoryTraversalCheckBox.AutoSize = true;
            this.SubDirectoryTraversalCheckBox.Location = new System.Drawing.Point(328, 231);
            this.SubDirectoryTraversalCheckBox.Name = "SubDirectoryTraversalCheckBox";
            this.SubDirectoryTraversalCheckBox.Size = new System.Drawing.Size(84, 16);
            this.SubDirectoryTraversalCheckBox.TabIndex = 8;
            this.SubDirectoryTraversalCheckBox.Text = "遍历子目录";
            this.SubDirectoryTraversalCheckBox.UseVisualStyleBackColor = true;
            this.SubDirectoryTraversalCheckBox.CheckedChanged += new System.EventHandler(this.SubDirectoryTraversalCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "|";
            // 
            // OnlyCPPCheckBox
            // 
            this.OnlyCPPCheckBox.AutoSize = true;
            this.OnlyCPPCheckBox.Location = new System.Drawing.Point(53, 231);
            this.OnlyCPPCheckBox.Name = "OnlyCPPCheckBox";
            this.OnlyCPPCheckBox.Size = new System.Drawing.Size(48, 16);
            this.OnlyCPPCheckBox.TabIndex = 6;
            this.OnlyCPPCheckBox.Text = ".cpp";
            this.OnlyCPPCheckBox.UseVisualStyleBackColor = true;
            this.OnlyCPPCheckBox.CheckedChanged += new System.EventHandler(this.OnlyCPPCheckBox_CheckedChanged);
            // 
            // OnlyTXTCheckBox
            // 
            this.OnlyTXTCheckBox.AutoSize = true;
            this.OnlyTXTCheckBox.Location = new System.Drawing.Point(203, 231);
            this.OnlyTXTCheckBox.Name = "OnlyTXTCheckBox";
            this.OnlyTXTCheckBox.Size = new System.Drawing.Size(48, 16);
            this.OnlyTXTCheckBox.TabIndex = 2;
            this.OnlyTXTCheckBox.Text = ".txt";
            this.OnlyTXTCheckBox.UseVisualStyleBackColor = true;
            this.OnlyTXTCheckBox.CheckedChanged += new System.EventHandler(this.OnlyTXTCheckBox_CheckedChanged);
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
            this.EncodingColumn,
            this.FileNameColumn});
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
            this.PreviewDataGridView.Size = new System.Drawing.Size(571, 210);
            this.PreviewDataGridView.TabIndex = 0;
            this.PreviewDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.PreviewDataGridView_CellFormatting);
            // 
            // IsSelectColumn
            // 
            this.IsSelectColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsSelectColumn.HeaderText = "是否更改";
            this.IsSelectColumn.Name = "IsSelectColumn";
            this.IsSelectColumn.ReadOnly = true;
            this.IsSelectColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsSelectColumn.Width = 78;
            // 
            // EncodingColumn
            // 
            this.EncodingColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.EncodingColumn.HeaderText = "编码格式";
            this.EncodingColumn.Name = "EncodingColumn";
            this.EncodingColumn.ReadOnly = true;
            this.EncodingColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EncodingColumn.Width = 59;
            // 
            // FileNameColumn
            // 
            this.FileNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileNameColumn.HeaderText = "文件名";
            this.FileNameColumn.Name = "FileNameColumn";
            this.FileNameColumn.ReadOnly = true;
            // 
            // CancelChangeButton
            // 
            this.CancelChangeButton.Location = new System.Drawing.Point(491, 47);
            this.CancelChangeButton.Name = "CancelChangeButton";
            this.CancelChangeButton.Size = new System.Drawing.Size(75, 23);
            this.CancelChangeButton.TabIndex = 4;
            this.CancelChangeButton.Text = "退出";
            this.CancelChangeButton.UseVisualStyleBackColor = true;
            this.CancelChangeButton.Click += new System.EventHandler(this.CancelChangeButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(396, 47);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 4;
            this.ApplyButton.Text = "应用";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // EncodingSettingGroupBox
            // 
            this.EncodingSettingGroupBox.Controls.Add(this.SearchPatternTextBox);
            this.EncodingSettingGroupBox.Controls.Add(this.label3);
            this.EncodingSettingGroupBox.Controls.Add(this.EncodingListComboBox);
            this.EncodingSettingGroupBox.Controls.Add(this.CancelChangeButton);
            this.EncodingSettingGroupBox.Controls.Add(this.SearchButton);
            this.EncodingSettingGroupBox.Controls.Add(this.ApplyButton);
            this.EncodingSettingGroupBox.Controls.Add(this.label1);
            this.EncodingSettingGroupBox.Location = new System.Drawing.Point(12, 12);
            this.EncodingSettingGroupBox.Name = "EncodingSettingGroupBox";
            this.EncodingSettingGroupBox.Size = new System.Drawing.Size(577, 79);
            this.EncodingSettingGroupBox.TabIndex = 2;
            this.EncodingSettingGroupBox.TabStop = false;
            this.EncodingSettingGroupBox.Text = "编码设置";
            // 
            // SearchPatternTextBox
            // 
            this.SearchPatternTextBox.Location = new System.Drawing.Point(99, 17);
            this.SearchPatternTextBox.Name = "SearchPatternTextBox";
            this.SearchPatternTextBox.Size = new System.Drawing.Size(467, 21);
            this.SearchPatternTextBox.TabIndex = 7;
            this.SearchPatternTextBox.Text = "*.*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "搜索条件:";
            // 
            // EncodingListComboBox
            // 
            this.EncodingListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncodingListComboBox.FormattingEnabled = true;
            this.EncodingListComboBox.Location = new System.Drawing.Point(99, 47);
            this.EncodingListComboBox.Name = "EncodingListComboBox";
            this.EncodingListComboBox.Size = new System.Drawing.Size(168, 20);
            this.EncodingListComboBox.TabIndex = 5;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(299, 47);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.Text = "搜索";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "新编码格式:";
            // 
            // EncodingConvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 362);
            this.Controls.Add(this.PreviewGroupBox);
            this.Controls.Add(this.EncodingSettingGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EncodingConvertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量文本编码格式转换";
            this.PreviewGroupBox.ResumeLayout(false);
            this.PreviewGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewDataGridView)).EndInit();
            this.EncodingSettingGroupBox.ResumeLayout(false);
            this.EncodingSettingGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox SeleteAllCheckBox;
        private System.Windows.Forms.CheckBox OnlyCSCheckBox;
        private System.Windows.Forms.CheckBox OnlyHCheckBox;
        private System.Windows.Forms.CheckBox OnlyCCheckBox;
        private System.Windows.Forms.GroupBox PreviewGroupBox;
        private System.Windows.Forms.DataGridView PreviewDataGridView;
        private System.Windows.Forms.ToolTip MainToolTip;
        private System.Windows.Forms.Button CancelChangeButton;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.GroupBox EncodingSettingGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EncodingListComboBox;
        private System.Windows.Forms.CheckBox OnlyCPPCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox SubDirectoryTraversalCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SearchPatternTextBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.CheckBox OnlyTXTCheckBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EncodingColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileNameColumn;
    }
}