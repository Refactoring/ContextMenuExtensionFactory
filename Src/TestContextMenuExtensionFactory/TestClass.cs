using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using ContextMenuExtensionFactory.ContextMenuCommand;

namespace TestContextMenuExtensionFactory
{
    [TestFixture]
    class TestClass
    {
        [Test]
        public void TestBatchRename()
        {
            BatchRenameForm from = new BatchRenameForm(@"E:\MySolution\GreedyPenguin");
            from.ShowDialog();
        }

        [Test]
        public void TestChangeEncoding()
        {
            EncodingConvertForm from = new EncodingConvertForm(@"E:\MySolution\GreedyPenguin");
            from.ShowDialog();
        }

        [Test]
        public void TestBuild()
        {
            IContextMenuCommand build = new ReleaseMSBuildNetFX();
            build.InvokeCommand(@"D:\My Documents\×ÀÃæ\ShengTeng.HIS");
        }
    }
}
