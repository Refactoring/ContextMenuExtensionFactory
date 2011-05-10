using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace ContextMenuExtensionFactory.ContextMenuCommand
{
    public class DebugMSBuildNetFX : IContextMenuCommand
    {
        #region IContextMenuCommand 成员

        string IContextMenuCommand.Name
        {
            get { return "编译.NET项目Debug模式(.sln)(&B)"; }
        }

        string IContextMenuCommand.Description
        {
            get { return "查找当前目录下的.sln,根据文件的版本自动选择MSBuild版本,并进行编译"; }
        }

        IntPtr IContextMenuCommand.HBitmap
        {
            get { return Properties.Resource.Build.GetHbitmap(); }
        }

        void IContextMenuCommand.InvokeCommand(string parameter)
        {
            ConstructFileArguments(parameter, "*.sln");
        }

        #endregion

        /// <summary>
        /// 使用Process编译，指定目录下所有匹配的文件
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private static string BuildMatchingFile(string parameter)
        {
            string result;
            Process process = null;
            try
            {
                process = new Process();
                process.StartInfo.FileName = "CMD";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.StartInfo.Arguments = parameter;
                process.Start();
                //process.WaitForExit();
                result = process.StandardOutput.ReadToEnd();
                process.Close();

            }
            finally
            {
                if (process != null)
                    process.Dispose();
            }
            return result;
        }

        /// <summary>
        /// Constructs the folder arguments.
        /// 返回所有匹配的目录
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <returns></returns>
        private static void ConstructFileArguments(string rootPath, string searchPattern)
        {
            StringBuilder output = new StringBuilder();
            string arumentsString = null;
            string temp = null;
            string netFX2MSBuild = @" /Q /C %windir%\Microsoft.NET\Framework\v2.0.50727\MSBuild.exe #File /t:Build /p:Configuration=Debug ";
            string netFX3MSBuild = @" /Q /C  %windir%\Microsoft.NET\Framework\v3.5\MSBuild.exe #File /t:Build /p:Configuration=Debug ";
            string netFX4MSBuild = @" /Q /C %windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe #File /t:Build /p:Configuration=Debug ";

            string[] files = Directory.GetFiles(rootPath, searchPattern, SearchOption.AllDirectories);
            foreach (string file in files)
            {
                arumentsString = null;
                using (StreamReader sr = new StreamReader(file))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        temp = sr.ReadLine();
                        if (temp.StartsWith("#"))
                        {
                            if (temp.Contains("Visual Studio 2005"))
                                arumentsString = netFX2MSBuild.Replace("#File", string.Format("\"{0}\"", file));
                            else if (temp.Contains("Visual Studio 2008"))
                                arumentsString = netFX3MSBuild.Replace("#File", string.Format("\"{0}\"", file));
                            else if (temp.Contains("Visual Studio 2010"))
                                arumentsString = netFX4MSBuild.Replace("#File", string.Format("\"{0}\"", file));
                            break;
                        }
                    }
                }
                
                output.AppendLine(BuildMatchingFile(arumentsString));
            }

            MessageForm message = new MessageForm();
            message.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            message.Title = "编译信息:";
            message.Message = output.ToString();
            message.Show();
        }
    }
}
