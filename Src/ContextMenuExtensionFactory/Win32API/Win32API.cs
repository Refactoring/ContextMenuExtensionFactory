using System;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Drawing;

using System.Runtime.InteropServices.ComTypes;

namespace Win32API
{    

    #region Struct
    
    public struct MenuHandler
    {
        public MenuHandler(IntPtr x)
        {
            handle = x;
        }
        public IntPtr handle;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct MenuItemInfo
    {
        public int cbSize;
        public uint fMask;
        public uint fType;
        public uint fState;
        public int wID;
        public IntPtr	/*HMENU*/	  hSubMenu;
        public IntPtr	/*HBITMAP*/   hbmpChecked;
        public IntPtr	/*HBITMAP*/	  hbmpUnchecked;
        public IntPtr	/*ULONG_PTR*/ dwItemData;
        public String dwTypeData;
        public uint cch;
        public IntPtr /*HBITMAP*/ hbmpItem;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct InvokeCommandInfo
    {
        public int Size;
        public int Mask;
        public IntPtr Hwnd;
        public IntPtr Verb;
        public IntPtr Parameters;
        public IntPtr Directory;
        public int Show;
        public int HotKey;
        public IntPtr Icon;
    }

    #endregion

    #region Enum

    [Flags]

    ////MF_BITMAP：将一个位图用作菜单项。参数lpNewltem里含有该位图的句柄。
    ////MF_CHECKED：在菜单项旁边放置一个选取标记。如果应用程序提供一个选取标记，位图（参见SetMenultemBitmaps），则将选取标记位图放置在菜单项旁边。
    ////MF_DISABLED：使菜单项无效，使该项不能被选择，但不使菜单项变灰。
    ////MF_ENABLED：使菜单项有效，使该项能被选择，并使其从变灰的状态恢复。
    ////MF_GRAYED：使菜单项无效并变灰，使其不能被选择。
    ////MF_MENUBARBREAK：对菜单条的功能同MF_MENUBREAK标志。对下拉式菜单、子菜单或快捷菜单，新列和旧列被垂直线分开。
    ////MF_MENUBREAK：将菜单项放置于新行（对菜单条），或新列（对下拉式菜单、子菜单或快捷菜单）且无分割列。
    ////MF_OWNERDRAW：指定该菜单项为自绘制菜单项。菜单第一次显示前，拥有菜单的窗口接收一个WM_MEASUREITEM消息来得到菜单项的宽和高。然后，只要菜单项被修改，都将发送WM_DRAWITEM消息给菜单拥有者的窗口程序。
    ////MF_POPUP：指定菜单打开一个下拉式菜单或子菜单。参数uIDNewltem下拉式菜单或子菜单的句柄。此标志用来给菜单条、打开一个下拉式菜单或于菜单的菜单项、子菜单或快捷菜单加一个名字。
    ////MF_SEPARATOR：画一条水平区分线。此标志只被下拉式菜单、于菜单或快捷菜单使用。此区分线不能被变灰、无效或加亮。参数IpNewltem和uIDNewltem无用。
    ////MF_STRING：指定菜单项是一个正文字符串；参数lpNewltem指向该字符串。
    ////MF_UNCHECKED：不放置选取标记在菜单项旁边（缺省）。如果应用程序提供一个选取标记位图（参见SetMenultemBitmaps），则将选取标记位图放置在菜单项旁边。

    public enum MF_UFlags : uint
    {
        Unchecked = 0,
        String = 0,
        Enabled = 0,
        ByCommand = 0,
        Grayed = 1,
        Disabled = 0x00000002,
        Checked = 0x00000008,
        Popup = 0x00000010,
        Hilite = 0x00000080,
        ByPosition = 0x00000400,
        Separator = 0x00000800,
    }


    [Flags]
    public enum CMF_UFlags : uint
    {
        Normal = 0x00000000,
        DefaultOnly = 0x00000001,
        VerbsOnly = 0x00000002,
        Explore = 0x00000004,
        Noverbs = 0x00000008,
        CanRename = 0x00000010,
        NoDefault = 0x00000020,
        IncludeStatic = 0x00000040,
        Reserved = 0xffff0000
    }

    [Flags]
    public enum GCS_UFlags : uint
    {
        VerbA = 0x00000000,
        HelpTextA = 0x00000001,
        ValidateA = 0x00000002,
        VerbW = 0x00000004,
        HelpTextW = 0x00000005,
        ValidateW = 0x00000006,
    }

    #endregion

    #region IShellExtInit

    [ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), GuidAttribute("000214e8-0000-0000-c000-000000000046")]
    public interface IShellExtInit
    {
        [PreserveSig()]
        int Initialize(IntPtr pidlFolder, IntPtr lpdobj, uint /*HKEY*/ hKeyProgID);
    }

    #endregion

    #region IContextMenu

    [ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), GuidAttribute("000214e4-0000-0000-c000-000000000046")]
    public interface IContextMenu
    {
        [PreserveSig()]
        int QueryContextMenu(MenuHandler hmenu, uint iMenu, uint idCmdFirst, uint idCmdLast, CMF_UFlags uFlags);
        [PreserveSig()]
        void InvokeCommand(IntPtr pici);
        [PreserveSig()]
        void GetCommandString(uint idcmd, GCS_UFlags uflags, uint reserved, IntPtr commandstring, int cchMax);
    }

    #endregion

    #region IDataObject

    [ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), GuidAttribute("0000010e-0000-0000-C000-000000000046")]
    public interface IDataObject
    {
        [PreserveSig()]
        int GetData(ref FORMATETC formatEtc, ref STGMEDIUM stgMedium);
    }

    #endregion

    #region Win32

    public class Win32
    {
        public const uint WM_DrawItem = 0x002b;
        public const uint WM_MeasureItem = 0x002c;

        [DllImport("shell32")]
        internal static extern uint DragQueryFile(uint hDrop, uint iFile, StringBuilder buffer, int cch);

        [DllImport("user32")]
        internal static extern MenuHandler CreatePopupMenu();

        [DllImport("user32")]
        internal static extern bool InsertMenuItem(MenuHandler hmenu, uint uposition, uint uflags, ref MenuItemInfo mii);

        [DllImport("user32")]
        internal static extern bool AppendMenu(MenuHandler hmenu, MF_UFlags uflags, IntPtr uIDNewItemOrSubmenu, string text);

        [DllImport("user32")]
        internal static extern bool InsertMenu(MenuHandler hmenu, int position, MF_UFlags uflags, IntPtr uIDNewItemOrSubmenu, string text);

        [DllImport("user32")]
        internal static extern int SetMenuItemBitmaps(MenuHandler hmenu, int nPosition, MF_UFlags uflags, IntPtr hBitmapUnchecked, IntPtr hBitmapChecked);
    }

    #endregion

}
