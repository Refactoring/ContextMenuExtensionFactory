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
    public partial class EncodingConvertForm : Form
    {
        private string _Directory = string.Empty;

        public EncodingConvertForm(string dir)
        {
            InitializeComponent();

            _Directory = dir;
            InitDataGridView(_Directory,this.SearchPatternTextBox.Text,SearchOption.TopDirectoryOnly);
            this.PreviewDataGridView.ReadOnly = false;
            this.EncodingColumn.ReadOnly = true;
            this.FileNameColumn.ReadOnly = true;

            InitEncodingListComboBox();
        }

        private void InitEncodingListComboBox()
        {
            this.EncodingListComboBox.Items.Add("ANSI(和本机语言设置相关)");
            this.EncodingListComboBox.Items.Add("UTF-8");
            //this.EncodingListComboBox.Items.Add("UTF-8 无 BOM");
            this.EncodingListComboBox.Items.Add("UTF-16 Big-Endian");
            this.EncodingListComboBox.Items.Add("UTF-16 Little-Endian");
            this.EncodingListComboBox.Items.Add("UTF-32 Big-Endian");
            this.EncodingListComboBox.Items.Add("UTF-32 Little-Endian");
            this.EncodingListComboBox.Text = "UTF-8";
        }

        private void InitDataGridView(string dir, string searchPattern, SearchOption searchOption)
        {
            try
            {
                List<DataGridViewRow> dataRows = new List<DataGridViewRow>();
                string extension;
                string dirName;

                foreach (string file in Directory.GetFiles(dir, searchPattern, searchOption))
                {
                    extension = Path.GetExtension(file).ToLower();

                    //过滤
                    dirName = Path.GetDirectoryName(file).ToLower();
                    if (dirName.IndexOf(".svn") != -1 || dirName.IndexOf("bin") != -1 || dirName.IndexOf("obj") != -1 || dirName.IndexOf("debug") != -1 || dirName.IndexOf("release") != -1)
                        continue;
                    if (extension == ".png" || extension == ".bmp" || extension == ".jpg" || extension == ".db")
                        continue;
                    if (extension == ".dll" || extension == ".exe" || extension == ".bin")
                        continue;

                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.Tag = file;
                    newRow.CreateCells(this.PreviewDataGridView);

                    if (this.SeleteAllCheckBox.Checked
                        || (this.OnlyCCheckBox.Checked && extension == ".c")
                        || (this.OnlyCPPCheckBox.Checked && extension == ".cpp")
                        || (this.OnlyHCheckBox.Checked && extension == ".h")
                        || (this.OnlyCSCheckBox.Checked && extension == ".cs")
                        || (this.OnlyTXTCheckBox.Checked && extension == ".txt"))
                        newRow.Cells[0].Value = true;
                    else
                        newRow.Cells[0].Value = false;

                    Encoding encoding = GetEncodingTypeByFile(file);
                    newRow.Cells[1].Value = encoding.EncodingName;
                    newRow.Cells[1].Tag = encoding;

                    newRow.Cells[2].Value = file;
                    newRow.Cells[2].ToolTipText = file;
                    newRow.Cells[2].Tag = extension;

                    dataRows.Add(newRow);
                }

                this.PreviewDataGridView.Rows.AddRange(dataRows.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Encoding GetEncodingTypeByFile(string file)
        {
            Encoding result = Encoding.Default;
            if (File.Exists(file))
            {
                byte[] bomByte = new byte[4];
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    using(BinaryReader br = new BinaryReader(fs))
                    {
                        bomByte = br.ReadBytes(4);
                    }
                }
                if (bomByte[0] == 0xEF && bomByte[1] == 0xBB && bomByte[2] == 0xBF)
                    result = Encoding.UTF8;
                else if (bomByte[0] == 0x00 && bomByte[1] == 0x00 && bomByte[2] == 0xFE && bomByte[3] == 0xFF)
                    result = new System.Text.UTF32Encoding(true, true);
                else if (bomByte[0] == 0xFF && bomByte[1] == 0xFE && bomByte[2] == 0x00 && bomByte[3] == 0x00)
                    result = new System.Text.UTF32Encoding(false, true);
                else if (bomByte[0] == 0xFE && bomByte[1] == 0xFF)
                    result = new System.Text.UnicodeEncoding(true, true);
                else if (bomByte[0] == 0xFF && bomByte[1] == 0xFE)
                    result = new System.Text.UnicodeEncoding(false, true);
            }
            return result;
        }

        private Encoding GetEncodingTypeByString(string str)
        {
            Encoding result = Encoding.Default;
            if (this.EncodingListComboBox.Text.IndexOf("UTF-8") != -1)
                result = Encoding.UTF8;
            else if (this.EncodingListComboBox.Text == "UTF-16 Big-Endian")
                result = new System.Text.UnicodeEncoding(true, true);
            else if (this.EncodingListComboBox.Text == "UTF-16 Little-Endian")
                result = new System.Text.UnicodeEncoding(false, true);
            else if (this.EncodingListComboBox.Text == "UTF-32 Big-Endian")
                result = new System.Text.UTF32Encoding(true, true);
            else if (this.EncodingListComboBox.Text == "UTF-32 Little-Endian")
                result = new System.Text.UTF32Encoding(false, true);

            return result;
        }


        #region Event Handler

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SubDirectoryTraversalCheckBox_CheckedChanged(sender, e);
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (this.PreviewDataGridView.Rows.Count == 0) return;
            
            Encoding encoding = GetEncodingTypeByString(this.EncodingListComboBox.Text);
            int count = 0;
            string txtFileContent;
            bool isNoBOMUTF8 = (this.EncodingListComboBox.Text.IndexOf("BOM") != -1);
            try
            {
                foreach (DataGridViewRow row in this.PreviewDataGridView.Rows)
                {
                    if (row.Cells["IsSelectColumn"].Value.ToString() == bool.TrueString)
                    {
                        using (StreamReader sr = new StreamReader(row.Tag.ToString(), (Encoding)row.Cells["EncodingColumn"].Tag))
                        {
                            txtFileContent = sr.ReadToEnd();
                        }

                        using(StreamWriter sw = new StreamWriter(row.Tag.ToString(), false, encoding))
                        {                                
                            sw.Write(txtFileContent);
                        }

                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }

            MessageBox.Show(string.Format("格式转换成功,总计:{0}", count));
        }

        private void CancelChangeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnlyCCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool setValue = this.OnlyCCheckBox.Checked;
            foreach (DataGridViewRow row in this.PreviewDataGridView.Rows)
            {
                if (row.Cells[2].Tag.ToString() == ".c")
                    row.Cells["IsSelectColumn"].Value = setValue;
            }
        }

        private void OnlyCPPCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool setValue = this.OnlyCPPCheckBox.Checked;
            foreach (DataGridViewRow row in this.PreviewDataGridView.Rows)
            {
                if (row.Cells[2].Tag.ToString() == ".cpp")
                    row.Cells["IsSelectColumn"].Value = setValue;
            }
        }

        private void OnlyHCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool setValue = this.OnlyHCheckBox.Checked;
            foreach (DataGridViewRow row in this.PreviewDataGridView.Rows)
            {
                if (row.Cells[2].Tag.ToString() == ".h")
                    row.Cells["IsSelectColumn"].Value = setValue;
            }
        }

        private void OnlyCSCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool setValue = this.OnlyCSCheckBox.Checked;
            foreach (DataGridViewRow row in this.PreviewDataGridView.Rows)
            {
                if (row.Cells[2].Tag.ToString() == ".cs")
                    row.Cells["IsSelectColumn"].Value = setValue;
            }
        }

        private void OnlyTXTCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool setValue = this.OnlyTXTCheckBox.Checked;
            foreach (DataGridViewRow row in this.PreviewDataGridView.Rows)
            {
                if (row.Cells[2].Tag.ToString() == ".txt")
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

        private void SubDirectoryTraversalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.PreviewDataGridView.Rows.Clear();

            SearchOption searchOpt;
            if(this.SubDirectoryTraversalCheckBox.Checked)
                searchOpt = SearchOption.AllDirectories;
            else 
                searchOpt = SearchOption.TopDirectoryOnly;
            InitDataGridView(_Directory, this.SearchPatternTextBox.Text,searchOpt);
        }

        private void PreviewDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null && e.Value.ToString().Length > 40)
            {
                e.Value = string.Format("......{0}", e.Value.ToString().Substring(e.Value.ToString().Length - 40));
            }
        }

        #endregion


    }
}