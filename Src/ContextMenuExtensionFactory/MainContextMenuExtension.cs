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

using ContextMenuExtensionFactory.ContextMenuCommand;

namespace ContextMenuExtensionFactory
{
    [Guid("D66D3AD7-9F78-4663-A0C7-B47751FCBB38"), ComVisible(true)]
    public class MainContextMenuExtension : IContextMenu, IShellExtInit
    {
        private const string GUID = "{D66D3AD7-9F78-4663-A0C7-B47751FCBB38}";
        private const string KeyName = "SuperContextMenuTools";
        const int S_OK = 0;
        const int S_FALSE = 1;

        protected Win32API.IDataObject _CurrentDataObject = null;
        protected int _UnionMember = 0;

        Dictionary<int, IContextMenuCommand> commandDictionary = null;

        #region IContextMenu 接口实现

        int IContextMenu.QueryContextMenu(Win32API.MenuHandler hMenu, uint iMenu, uint idCmdFirst, uint idCmdLast, CMF_UFlags uFlags)
        {
            InitMenuCommand();

            int id = 0;
            if ((uFlags & (CMF_UFlags.VerbsOnly | CMF_UFlags.DefaultOnly | CMF_UFlags.Noverbs)) == 0 ||
                (uFlags & CMF_UFlags.Explore) != 0)
            {
                //创建子菜单
                Win32API.MenuHandler submenu = Win32API.Win32.CreatePopupMenu();

                //添加菜单名称
                foreach(KeyValuePair<int,IContextMenuCommand> pair in commandDictionary)
                    Win32.AppendMenu(submenu, MF_UFlags.String, new IntPtr(idCmdFirst + id++), pair.Value.Name);

                //将子菜单插入到上下文菜单中
                Win32.InsertMenu(hMenu, 1, MF_UFlags.ByPosition | MF_UFlags.Popup, submenu.handle, "扩展工具集(&Y)");
               
                //为菜单增加图标
                Win32.SetMenuItemBitmaps(hMenu, 1, MF_UFlags.ByPosition, Properties.Resource.Main.GetHbitmap(), Properties.Resource.Main.GetHbitmap());

                foreach (KeyValuePair<int, IContextMenuCommand> pair in commandDictionary)
                {
                    if(pair.Value.HBitmap != IntPtr.Zero)
                        Win32.SetMenuItemBitmaps(submenu, pair.Key, MF_UFlags.ByPosition, pair.Value.HBitmap, pair.Value.HBitmap);
                }
            }
            return id;
        }

        void IContextMenu.GetCommandString(uint idcmd, GCS_UFlags uflags, uint reserved, IntPtr commandstring, int cchMax)
        {
            string tip = "";

            switch (uflags)
            {
                case GCS_UFlags.HelpTextW:
                    IContextMenuCommand temp;
                    if (commandDictionary.TryGetValue((int)idcmd, out temp))
                        tip = temp.Description;

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
            uint nselected = Win32.DragQueryFile((uint)_UnionMember, 0xffffffff, null, 0);
            for (uint i = 0; i < nselected; i++)
            {
                Win32.DragQueryFile((uint)_UnionMember, i, sb, sb.Capacity + 1);
                sbAll.Append(sb.ToString());
            }

            IContextMenuCommand temp;
            if (commandDictionary.TryGetValue(cmdInfo.Verb.ToInt32(), out temp))
                temp.InvokeCommand(sbAll.ToString());
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

        /// <summary>
        /// 初始化菜单类字典,新增菜单项请加至此处，即可
        /// </summary>
        private void InitMenuCommand()
        {
            if (commandDictionary == null)
            {
                commandDictionary = new Dictionary<int, IContextMenuCommand>();

                commandDictionary.Add(0, new DeleteMatchingDotSVNFolder());
                commandDictionary.Add(1, new DeleteMatchingThumbsDotdbFile());
                commandDictionary.Add(2, new DeleteMatchingDotNetBuildFolder());
                commandDictionary.Add(3, new DebugMSBuildNetFX());
                commandDictionary.Add(4, new ReleaseMSBuildNetFX());
                commandDictionary.Add(5, new BatchRename());
                commandDictionary.Add(6, new EncodingConvert());
                commandDictionary.Add(7, new MailTo());
            }
        }
    }
}
