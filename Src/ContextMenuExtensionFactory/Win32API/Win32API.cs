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

    ////MF_BITMAP����һ��λͼ�����˵������lpNewltem�ﺬ�и�λͼ�ľ����
    ////MF_CHECKED���ڲ˵����Ա߷���һ��ѡȡ��ǡ����Ӧ�ó����ṩһ��ѡȡ��ǣ�λͼ���μ�SetMenultemBitmaps������ѡȡ���λͼ�����ڲ˵����Աߡ�
    ////MF_DISABLED��ʹ�˵�����Ч��ʹ����ܱ�ѡ�񣬵���ʹ�˵����ҡ�
    ////MF_ENABLED��ʹ�˵�����Ч��ʹ�����ܱ�ѡ�񣬲�ʹ��ӱ�ҵ�״̬�ָ���
    ////MF_GRAYED��ʹ�˵�����Ч����ң�ʹ�䲻�ܱ�ѡ��
    ////MF_MENUBARBREAK���Բ˵����Ĺ���ͬMF_MENUBREAK��־��������ʽ�˵����Ӳ˵����ݲ˵������к;��б���ֱ�߷ֿ���
    ////MF_MENUBREAK�����˵�����������У��Բ˵������������У�������ʽ�˵����Ӳ˵����ݲ˵������޷ָ��С�
    ////MF_OWNERDRAW��ָ���ò˵���Ϊ�Ի��Ʋ˵���˵���һ����ʾǰ��ӵ�в˵��Ĵ��ڽ���һ��WM_MEASUREITEM��Ϣ���õ��˵���Ŀ�͸ߡ�Ȼ��ֻҪ�˵���޸ģ���������WM_DRAWITEM��Ϣ���˵�ӵ���ߵĴ��ڳ���
    ////MF_POPUP��ָ���˵���һ������ʽ�˵����Ӳ˵�������uIDNewltem����ʽ�˵����Ӳ˵��ľ�����˱�־�������˵�������һ������ʽ�˵����ڲ˵��Ĳ˵���Ӳ˵����ݲ˵���һ�����֡�
    ////MF_SEPARATOR����һ��ˮƽ�����ߡ��˱�־ֻ������ʽ�˵����ڲ˵����ݲ˵�ʹ�á��������߲��ܱ���ҡ���Ч�����������IpNewltem��uIDNewltem���á�
    ////MF_STRING��ָ���˵�����һ�������ַ���������lpNewltemָ����ַ�����
    ////MF_UNCHECKED��������ѡȡ����ڲ˵����Աߣ�ȱʡ�������Ӧ�ó����ṩһ��ѡȡ���λͼ���μ�SetMenultemBitmaps������ѡȡ���λͼ�����ڲ˵����Աߡ�

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
