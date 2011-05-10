using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ContextMenuExtensionFactory.ContextMenuCommand
{
    public class DeleteMatchingDotSVNFolder : IContextMenuCommand
    {

        #region IContextMenuCommand 成员

        string IContextMenuCommand.Name
        {
            get { return "删除 .svn(&S)"; }
        }

        string IContextMenuCommand.Description
        {
            get { return "删除此目录下的所有.svn文件夹"; }
        }

        IntPtr IContextMenuCommand.HBitmap
        {
            get { return Properties.Resource.DeleteFolder.GetHbitmap(); }
        }

        void IContextMenuCommand.InvokeCommand(string parameter)
        {
            DeleteMatchingFolder(parameter, ".svn");
        }

        #endregion

        /// <summary>
        /// Deletes the matching folder.
        /// 使用Process删除指定目录下所有匹配的目录
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="searchPattern">The search pattern.</param>
        private static void DeleteMatchingFolder(string rootPath, string searchPattern)
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

                process.StartInfo.Arguments = ConstructFolderArguments(rootPath, searchPattern);
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
        /// Constructs the folder arguments.
        /// 返回所有匹配的目录
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <returns></returns>
        private static string ConstructFolderArguments(string rootPath, string searchPattern)
        {
            StringBuilder arguments = new StringBuilder();
            arguments.Append(" /Q /C rd /S /Q ");
            string[] directories = Directory.GetDirectories(rootPath, searchPattern, SearchOption.AllDirectories);
            foreach (string str in directories)
                arguments.AppendFormat("\"{0}\" ", str);

			MessageBox.Show(string.Format("匹配{0}文件夹: {1} 个.", searchPattern,directories.Length), "提示:", MessageBoxButtons.OK);

            return arguments.ToString();
        }
    }
}
