using System;
using System.Collections.Generic;
using System.Text;

namespace ContextMenuExtensionFactory.ContextMenuCommand
{
    public interface IContextMenuCommand
    {
        /// <summary>
        /// 菜单名称.
        /// </summary>
        /// <value>The name.</value>
        string Name { get;}

        /// <summary>
        /// 菜单功能描述.
        /// </summary>
        /// <value>The description.</value>
        string Description { get;}

        /// <summary>
        /// 菜单图标.
        /// </summary>
        /// <value>The H bitmap.</value>
        IntPtr HBitmap { get;}

        /// <summary>
        /// Invokes the command.
        /// </summary>
        /// <param name="parameter">The parameter.当前被操作的文件夹</param>
        void InvokeCommand(string parameter);
    }
}
