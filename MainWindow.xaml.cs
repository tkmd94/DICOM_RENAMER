using EvilDICOM.Core;
using EvilDICOM.Core.Helpers;
using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;



namespace DICOM_RENAMER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Top = 0;
            this.Left = SystemParameters.WorkArea.Width - this.Width;

        }

        private void Grid_DragOver(object sender, DragEventArgs e)
        {
            // ファイルがドラッグされていることを確認
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            // ドロップされたファイルのパスを取得
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                var result= DicomRename.RenameProcess(files);
                if (result == false)
                    txtFilePath.Text = "ドロップされた.dcmファイルはありません。";
            }
        }
    }
}