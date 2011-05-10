using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ContextMenuExtensionFactory.ContextMenuCommand
{
    public class DeleteMatchingThumbsDotdbFile : IContextMenuCommand
    {
        #region IContextMenuCommand 成员

        string IContextMenuCommand.Name
        {
            get { return "删除 Thumbs.db(&T)"; }
        }

        string IContextMenuCommand.Description
        {
            get { return "删除此目录下的所有Thumbs.db文件"; }
        }

        IntPtr IContextMenuCommand.HBitmap
        {
            get { return Properties.Resource.DeleteFile.GetHbitmap(); }
        }

        void IContextMenuCommand.InvokeCommand(string parameter)
        {
            DeleteMatchingFile(parameter, "Thumbs.db");
        }

        #endregion

        /// <summary>
        /// Deletes the matching file.
        /// 使用Process删除指定目录下所有匹配的文件
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="searchPattern">The search pattern.</param>
        private void DeleteMatchingFile(string rootPath, string searchPattern)
        {
            Process process = null;
            try
            {
                process = new Process();
                process.StartInfo.FileName = "CMD";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.StartInfo.Arguments = ConstructFileArguments(rootPath, searchPattern);
                process.Start();
                process.WaitForExit();
                process.Close();
            }
            finally
            {
                if (process != null)
                    process.Dispose();
            }
        }

        /// <summary>
        /// Constructs the file arguments.
        /// 返回所有匹配的文件
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <returns></returns>
        private static string ConstructFileArguments(string rootPath, string searchPattern)
        {
            StringBuilder arguments = new StringBuilder();
            arguments.Append(" /Q /C del /Q /A:S ");
            string[] files = Directory.GetFiles(rootPath, searchPattern, SearchOption.AllDirectories);
            foreach (string str in files)
                arguments.AppendFormat("\"{0}\" ", str);
			MessageBox.Show(string.Format("匹配{0}文件: {1} 个.", searchPattern,files.Length), "提示:", MessageBoxButtons.OK);
            return arguments.ToString();
        }

    }
}
