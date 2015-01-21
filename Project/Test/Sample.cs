using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VSDriver;
using System.Diagnostics;
using System.Linq;

namespace Test
{
    [TestClass]
    public class Sample
    {
        AppDriver _app;

        [TestInitialize]
        public void TestInitialize()
        {
            //自分のVS以外のいずれかにアタッチ
            _app = new AppDriver(Process.GetProcessesByName("devenv").Where(e=>e.MainWindowTitle.IndexOf("VSDriver") == -1).First());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _app.Dispose();
        }

        [TestMethod]
        public void TestOutput()
        {
            //アウトプットを表示
            _app.MainWindow.MainMenu.GetItem("表示(_V)", "出力(_O)").EmulateClick();

            //アウトプットを取得
            var output = _app.AttachOutputWindow();

            //アウトプットの出力元コンボボックスの選択を1番目にする
            output.ComboBoxSource.EmulateChangeSelectedIndex(1);

            //テキスト取得
            string text = output.GetOutputText();
        }
    }
}
