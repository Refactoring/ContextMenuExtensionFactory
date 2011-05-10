using System;
using System.Collections.Generic;
using System.Text;

namespace ContextMenuExtensionFactory.ContextMenuCommand
{
    public class BatchRename : IContextMenuCommand
    {
        #region IContextMenuCommand 成员

        string IContextMenuCommand.Name
        {
            get { return "批量重命名(&R)"; }
        }

        string IContextMenuCommand.Description
        {
            get { return "批量文件重命名"; }
        }

        IntPtr IContextMenuCommand.HBitmap
        {
            get { return IntPtr.Zero; }
        }

        void IContextMenuCommand.InvokeCommand(string parameter)
        {
            BatchRenameForm encodingForm = new BatchRenameForm(parameter);
            encodingForm.Show();
        }

        #endregion
    }
}
