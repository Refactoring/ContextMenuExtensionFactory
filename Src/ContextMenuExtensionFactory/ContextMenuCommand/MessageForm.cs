using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ContextMenuExtensionFactory.ContextMenuCommand
{
    public partial class MessageForm : Form
    {
        /// <summary>
        /// 标题说明
        /// </summary>
        /// <value>The title.</value>
        public string Title 
        {
            get { return this.LabelTitle.Text;}
            set { this.LabelTitle.Text = value; } 
        }

        /// <summary>
        /// 显示的消息
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            get { return this.TextBoxMessage.Text; }
            set { this.TextBoxMessage.Text = value; }
        }

        public MessageForm()
        {
            InitializeComponent();
        }
    }
}
