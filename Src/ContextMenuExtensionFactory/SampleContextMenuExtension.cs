using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

using Win32API;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;

namespace ContextMenuExtensionFactory
{
    [Guid("D66D3AD7-9F78-4663-A0C7-B47751FCBB38"), ComVisible(true)]
    public class SampleContextMenuExtension : IContextMenu, IShellExtInit
    {
        private const string GUID = "{D66D3AD7-9F78-4663-A0C7-B47751FCBB38}";
        private const string KeyName = "SuperContextMenuTools";
        const int S_OK = 0;
        const int S_FALSE = 1;

        protected Win32API.IDataObject _CurrentDataObject = null;
        protected int _UnionMember = 0;

        #region IContextMenu 接口实现

        int IContextMenu.QueryContextMenu(Win32API.MenuHandler hMenu, uint iMenu, uint idCmdFirst, uint idCmdLast, CMF_UFlags uFlags)
        {
            int id = 0;
            if ((uFlags & (CMF_UFlags.VerbsOnly | CMF_UFlags.DefaultOnly | CMF_UFlags.Noverbs)) == 0 ||
                (uFlags & CMF_UFlags.Explore) != 0)
            {
                //创建子菜单
                Win32API.MenuHandler submenu = Win32API.Helpers.CreatePopupMenu();
                Helpers.AppendMenu(submenu, MF_UFlags.String, new IntPtr(idCmdFirst + id++), "删除 .svn(&S)");
                Helpers.AppendMenu(submenu, MF_UFlags.String, new IntPtr(idCmdFirst + id++), "删除 Thumbs.db(&T)");
                Helpers.AppendMenu(submenu, MF_UFlags.String, new IntPtr(idCmdFirst + id++), "批量重命名(&R)");
                Helpers.AppendMenu(submenu, MF_UFlags.String, new IntPtr(idCmdFirst + id++), "批量文本编码格式转换(&E)");
                Helpers.AppendMenu(submenu, MF_UFlags.String, new IntPtr(idCmdFirst + id++), "反馈: Dragon.Zhang(&M)");

                //将子菜单插入到上下文菜单中
                Helpers.InsertMenu(hMenu, 1, MF_UFlags.ByPosition | MF_UFlags.Popup, submenu.handle, "扩展工具集(&Y)");
               
                //为菜单增加图标
                Helpers.SetMenuItemBitmaps(hMenu, 1, MF_UFlags.ByPosition, Properties.Resource.Main.GetHbitmap(), Properties.Resource.Main.GetHbitmap());
                Helpers.SetMenuItemBitmaps(submenu, 0, MF_UFlags.ByPosition, Properties.Resource.DeleteFolder.GetHbitmap(), Properties.Resource.DeleteFolder.GetHbitmap());
                Helpers.SetMenuItemBitmaps(submenu, 1, MF_UFlags.ByPosition, Properties.Resource.DeleteFile.GetHbitmap(), Properties.Resource.DeleteFile.GetHbitmap());
                Helpers.SetMenuItemBitmaps(submenu, 3, MF_UFlags.ByPosition, Properties.Resource.EncodingConvert.GetHbitmap(), Properties.Resource.EncodingConvert.GetHbitmap());
                Helpers.SetMenuItemBitmaps(submenu, 4, MF_UFlags.ByPosition, Properties.Resource.MailTo.GetHbitmap(), Properties.Resource.MailTo.GetHbitmap());
            }
            return id;
        }

        void IContextMenu.GetCommandString(uint idcmd, GCS_UFlags uflags, uint reserved, IntPtr commandstring, int cchMax)
        {
            string tip = "";

            switch (uflags)
            {
                case GCS_UFlags.HelpTextW:
                    switch (idcmd)
                    {
                        case 0:
                            tip = "删除此目录下的所有.svn文件夹";
                            break;
                        case 1:
                            tip = "删除此目录下的所有Thumbs.db文件";
                            break;
                        case 2:
                            tip = "批量文件重命名";
                            break;
                       case 3:
                            tip = "批量文本编码格式转换";
                            break;
                        case 4:
                            tip = "如果你有好的建议或意见，请发送邮件至Dragon.Zhang@Promexus.cn";
                            break;
                        default:
                            break;
                    }
                    if (!string.IsNullOrEmpty(tip))
                    {
                        byte[] data = new byte[cchMax * 2];
                        Encoding.Unicode.GetBytes(tip, 0, tip.Length, data, 0);
                        Marshal.Copy(data, 0, commandstring, data.Length);
                    }
                    break;
            }
        }

        void IContextMenu.InvokeCommand(IntPtr pici)
        {
            InvokeCommandInfo cmdInfo = (InvokeCommandInfo)Marshal.PtrToStructure(pici, typeof(Win32API.InvokeCommandInfo));
            StringBuilder sb = new StringBuilder(1024);
            StringBuilder sbAll = new StringBuilder();
            uint nselected = Helpers.DragQueryFile((uint)_UnionMember, 0xffffffff, null, 0);
            for (uint i = 0; i < nselected; i++)
            {
                Helpers.DragQueryFile((uint)_UnionMember, i, sb, sb.Capacity + 1);
                sbAll.Append(sb.ToString());
            }

            switch (cmdInfo.Verb.ToInt32())
            {
                case 0:
                    //删除 .svn
                    DeleteMatchingFolder(sbAll.ToString(), ".svn");
                    break;
                case 1:
                    //删除 Thumbs.db
                    DeleteMatchingFile(sbAll.ToString(), "Thumbs.db");
                    break;
                case 2:
                    //批量重命名
                    BatchRenameForm renameForm = new BatchRenameForm(sbAll.ToString());
                    renameForm.Show();
                    break;
                case 3:
                    //批量文本编码格式转换
                    EncodingConvertForm encodingForm = new EncodingConvertForm(sbAll.ToString());
                    encodingForm.Show();
                    break;
                case 4:
                    //发送反馈邮件
                    Process proc = new Process();
                    proc.StartInfo.FileName = "IExplore.exe";
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.Arguments = "mailto:Dragon.Zhang@Promexus.cn?subject=ContextMenuExtensionFactory Suggestion";
                    proc.Start();
                    proc.WaitForExit();
                    proc.Close();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region IShellExtInit

        int IShellExtInit.Initialize(IntPtr pidlFolder, IntPtr lpdobj, uint hKeyProgID)
        {
            try
            {
                _CurrentDataObject = null;
                if (lpdobj != (IntPtr)0)
                {
                    _CurrentDataObject = (Win32API.IDataObject)Marshal.GetObjectForIUnknown(lpdobj);
                    FORMATETC formatEtc = new FORMATETC();
                    formatEtc.cfFormat = 15;
                    formatEtc.ptd = IntPtr.Zero;
                    formatEtc.dwAspect = DVASPECT.DVASPECT_CONTENT;
                    formatEtc.lindex = -1;
                    formatEtc.tymed = TYMED.TYMED_HGLOBAL;
                    STGMEDIUM stgMedium = new STGMEDIUM();
                    _CurrentDataObject.GetData(ref formatEtc, ref stgMedium);
                    _UnionMember = stgMedium.unionmember.ToInt32();
                }
            }
            catch (Exception)
            {
            }
            return S_OK;
        }

        #endregion

        #region Registration

        [System.Runtime.InteropServices.ComRegisterFunctionAttribute()]
        static void RegisterServer(Type type)
        {
            try
            {
                //注册 DLL
                RegistryKey root;
                RegistryKey rk;
                root = Registry.LocalMachine;
                rk = root.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved", true);
                rk.SetValue(GUID, KeyName);
                rk.Close();
                root.Close();

                //注册文件
                RegisterToDirectory(type);
            }
            catch{
            }
        }

        [System.Runtime.InteropServices.ComUnregisterFunctionAttribute()]
        static void UnregisterServer(Type type)
        {
            try
            {
                //注销 DLL
                RegistryKey root;
                RegistryKey rk;
                root = Registry.LocalMachine;
                rk = root.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved", true);
                rk.DeleteValue(GUID);
                rk.Close();
                root.Close();

                //注销文件
                UnRegisterFromDirectory(type);
            }
            catch
            {
            }
        }

        private static void RegisterToDirectory(Type type)
        {
            RegistryKey rk, rk2;
            //rk = Registry.ClassesRoot.OpenSubKey(@"*\shellex\ContextMenuHandlers", true);
            //rk2 = rk.OpenSubKey(KeyName);
            //if (rk2 == null)
            //    rk2 = rk.CreateSubKey(KeyName);
            //rk2.SetValue("", GUID);
            //rk2.Close();
            //rk.Close();

            rk = Registry.ClassesRoot.OpenSubKey(@"Directory\shellex\ContextMenuHandlers", true);
            rk2 = rk.OpenSubKey(type.Name);
            if (rk2 == null)
                rk2 = rk.CreateSubKey(type.Name);
            rk2.SetValue("", GUID);
            rk2.Close(); 
        }

        private static void UnRegisterFromDirectory(Type type)
        {
            RegistryKey rk;
            //rk = Registry.ClassesRoot.OpenSubKey(@"*\shellex\ContextMenuHandlers", true);
            //rk.DeleteSubKey(KeyName, false);
            //rk.Close();
            rk = Registry.ClassesRoot.OpenSubKey(@"Directory\shellex\ContextMenuHandlers", true);
            rk.DeleteSubKey(type.Name, false);
            rk.Close();
        }
        
        #endregion

        #region Invoke Method

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

            MessageBox.Show(string.Format("匹配文件夹: {0} 个.", directories.Length), "提示:", MessageBoxButtons.OK);

            return arguments.ToString();
        }

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
            MessageBox.Show(string.Format("匹配文件: {0} 个.", files.Length), "提示:", MessageBoxButtons.OK);
            return arguments.ToString();
        }

        #endregion

    }
}
