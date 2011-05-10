using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;

namespace ContextMenuExtensionFactory.ContextMenuCommand
{
    public class MailTo : IContextMenuCommand
    {
        #region IContextMenuCommand 成员

        string IContextMenuCommand.Name
        {
            get { return "反馈: Ethan.Zhang(&M)"; }
        }

        string IContextMenuCommand.Description
        {
            get { return "如果你有好的建议或意见，请发送邮件至OO.Snail@Gmail.Com"; }
        }

        IntPtr IContextMenuCommand.HBitmap
        {
            get { return Properties.Resource.MailTo.GetHbitmap(); }
        }

        void IContextMenuCommand.InvokeCommand(string parameter)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "IExplore.exe";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.Arguments = "mailto:OO.Snail@Gmail.Com?subject=ContextMenuExtensionFactory Suggestion";
            proc.Start();
            proc.WaitForExit();
            proc.Close();
        }

        #endregion
    }
}
