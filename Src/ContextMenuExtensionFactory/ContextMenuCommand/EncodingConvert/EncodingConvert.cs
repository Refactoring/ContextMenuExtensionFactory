using System;
using System.Collections.Generic;
using System.Text;

namespace ContextMenuExtensionFactory.ContextMenuCommand
{
    public class EncodingConvert : IContextMenuCommand
    {
        #region IContextMenuCommand 成员

        string IContextMenuCommand.Name
        {
            get { return "批量文本编码格式转换(&E)"; }
        }

        string IContextMenuCommand.Description
        {
            get { return "批量文本编码格式转换"; }
        }

        IntPtr IContextMenuCommand.HBitmap
        {
            get { return Properties.Resource.EncodingConvert.GetHbitmap(); }
        }

        void IContextMenuCommand.InvokeCommand(string parameter)
        {
            EncodingConvertForm encodingForm = new EncodingConvertForm(parameter);
            encodingForm.Show();
        }

        #endregion
    }
}
