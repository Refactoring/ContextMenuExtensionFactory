using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace ContextMenuExtensionFactory.ContextMenuCommand
{
    public partial class BatchRenameForm : Form
    {
        string _RenameStyle = null;
        int _StartNum = -1;
        string _FormatString = "0";

        public BatchRenameForm(string dir)
        {
            InitializeComponent();

            InitDataGridView(dir);
            this.PreviewDataGridView.ReadOnly = false;
            this.OldNameColumn.ReadOnly = true;
            this.NewNameColumn.ReadOnly = true;
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            if (!CheckRenameStyle()) return;
            if (!CheckStartNum()) return;

            int addNum = _StartNum;
            foreach (DataGridViewRow row in this.PreviewDataGridView.Rows)
            {
                if (row.Cells["IsSelectColumn"].Value.ToString() == bool.TrueString)
                {
                    row.Cells["NewNameColumn"].Value = _RenameStyle.Replace("<O>", row.Cells["OldNameColumn"].Tag.ToString()).Replace("<*>", addNum.ToString(_FormatString)) + row.Cells["NewNameColumn"].Tag.ToString();
                    addNum++;
                }
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (!CheckRenameStyle()) return;
            if (!CheckStartNum()) return;

            string fileName = null;
            int addNum = _StartNum;
            try
            {
                foreach (DataGridViewRow row in this.PreviewDataGridView.Rows)
                {
                    if (row.Cells["IsSelectColumn"].Value.ToString() == bool.TrueString)
                    {
                        fileName = _RenameStyle.Replace("<O>", row.Cells["OldNameColumn"].Tag.ToString()).Replace("<*>", addNum.ToString(_FormatString)) + row.Cells["NewNameColumn"].Tag.ToString();
                        File.Move(row.Tag.ToString(), string.Format("{0}\\{1}", Path.GetDirectoryName(row.Tag.ToString()), fileName));
                        addNum++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }

            MessageBox.Show(string.Format("修改成功,总计:{0}", addNum - _StartNum));
            if (this.PreviewDataGridView.Rows.Count > 0 && fileName != null)
            {
                fileName = string.Format("{0}\\{1}", Path.GetDirectoryName(this.PreviewDataGridView.Rows[0].Tag.ToString()), fileName);
                this.PreviewDataGridView.Rows.Clear();
                InitDataGridView(Path.GetDirectoryName(fileName));
            }
        }

        private void CancelRenameButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckStartNum()
        {
            string tempStartNum = this.StartNumTextBox.Text;
            if (string.IsNullOrEmpty(tempStartNum))
            {
                MessageBox.Show("起始数字不能为空.", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.StartNumTextBox.SelectAll();
                return false;
            }
            else
            {
                try
                {
                    _StartNum = int.Parse(tempStartNum);
                    _FormatString = "";
                    for (int i = 0; i < tempStartNum.Trim().Length; ++i)
                        _FormatString += "0";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.StartNumTextBox.SelectAll();
                    return false;
                }
            }

            return true;
        }

        private bool CheckRenameStyle()
        {
            string tempStyle = this.ReNameStyleTextBox.Text;
            if (string.IsNullOrEmpty(tempStyle))
            {
                MessageBox.Show("重命名样式不能为空.", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ReNameStyleTextBox.SelectAll();
                return false;
            }
            else if (tempStyle.IndexOf("<*>") == -1 && tempStyle.IndexOf("<O>") == -1)
            {
                MessageBox.Show("必须至少存在一个特殊标记.", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ReNameStyleTextBox.SelectAll();
                return false;
            }
            //else if (tempStyle.IndexOfAny(Path.InvalidPathChars) != -1)
            //{
            //    MessageBox.Show("样式错误,存在错误字符.", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.ReNameStyleTextBox.SelectAll();
            //}
            _RenameStyle = tempStyle;

            return true;
        }

        private void OnlyPNGCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool setValue = this.OnlyPNGCheckBox.Checked;
            foreach (DataGridViewRow row in this.PreviewDataGridView.Rows)
            {
                if (row.Cells[2].Tag.ToString() == ".png")
                    row.Cells["IsSelectColumn"].Value = setValue;
            }
        }

        private void OnlyBMPCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool setValue = this.OnlyBMPCheckBox.Checked;
            foreach (DataGridViewRow row in this.PreviewDataGridView.Rows)
            {
                if (row.Cells[2].Tag.ToString() == ".bmp")
                    row.Cells["IsSelectColumn"].Value = setValue;
            }
        }

        private void OnlyJPGCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool setValue = this.OnlyJPGCheckBox.Checked;
            foreach (DataGridViewRow row in this.PreviewDataGridView.Rows)
            {
                if (row.Cells[2].Tag.ToString() == ".jpg")
                    row.Cells["IsSelectColumn"].Value = setValue;
            }
        }

        private void SeleteAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool setValue = this.SeleteAllCheckBox.Checked;
            foreach (DataGridViewRow row in this.PreviewDataGridView.Rows)
            {
                row.Cells["IsSelectColumn"].Value = setValue;
            }
        }

        private void InitDataGridView(string dir)
        {
            List<DataGridViewRow> dataRows = new List<DataGridViewRow>();
            string extension;
            string fileName;
            string fileNameNoExtension;

            foreach (string file in Directory.GetFiles(dir))
            {
                extension = Path.GetExtension(file).ToLower();
                fileName = Path.GetFileName(file);
                fileNameNoExtension = Path.GetFileNameWithoutExtension(file);

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.Tag = file;
                newRow.CreateCells(this.PreviewDataGridView);

                if ((this.OnlyPNGCheckBox.Checked && extension == ".png")
                    || (this.OnlyBMPCheckBox.Checked && extension == ".bmp")
                    || (this.OnlyJPGCheckBox.Checked && extension == ".jpg"))
                    newRow.Cells[0].Value = true;
                else
                    newRow.Cells[0].Value = false;
                newRow.Cells[1].Value = fileName;
                newRow.Cells[1].Tag = fileNameNoExtension;
                newRow.Cells[2].Value = "";
                newRow.Cells[2].Tag = extension;

                dataRows.Add(newRow);
            }

            this.PreviewDataGridView.Rows.AddRange(dataRows.ToArray());
        }

    }
}