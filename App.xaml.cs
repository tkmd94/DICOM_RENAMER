using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DICOM_RENAMER
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private  void ApplicationStartup(object sender, StartupEventArgs e)
        {

            // コマンドライン引数を取得します
            string[] args = e.Args;
            if (args.Length > 0)
            {
                var result = DicomRename.RenameProcess(args);
                Application.Current.Shutdown();
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
    }
}
