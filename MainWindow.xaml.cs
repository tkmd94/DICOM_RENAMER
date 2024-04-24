using EvilDICOM.Core;
using EvilDICOM.Core.Helpers;
using System;
using System.IO;
using System.Linq;
using System.Windows;


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
                // ファイルパスをフィルタリングし、.dcmファイルのみを処理
                var dcmFiles = files.Where(file => Path.GetExtension(file).Equals(".dcm", StringComparison.OrdinalIgnoreCase));

                if (dcmFiles.Any())
                {
                    foreach (var file in dcmFiles)
                    {
                        // DICOMファイルを読み込む
                        var dcm = DICOMObject.Read(file);
                        // PatientIDを取得
                        var patientId = dcm.FindFirst(TagHelper.PatientID)?.DData.ToString();
                        var patientName = dcm.FindFirst(TagHelper.PatientName)?.DData.ToString();
                        var planId = dcm.FindFirst(TagHelper.RTPlanLabel)?.DData.ToString();
                        var modality = dcm.FindFirst(TagHelper.Modality)?.DData.ToString();
                        var refBeamNo = dcm.FindFirst(TagHelper.ReferencedBeamNumber)?.DData.ToString();
                        if (refBeamNo == null)
                        {
                            refBeamNo = "_PD";
                        }
                        else
                        {
                            refBeamNo = "_F" + refBeamNo;
                        }

                        var newFileName = "";
                        // 結果を表示（ここではコンソールに出力していますが、UIに適宜表示してください）

                        var oldFileName = Path.GetFileName(file);
                        var filePath = Path.GetDirectoryName(file);
                        if (modality == "RTPLAN")
                        {
                            newFileName = System.IO.Path.Combine(filePath,planId + "_" + oldFileName);
                            Console.WriteLine($"new File{newFileName}");
                        }
                        else if (modality == "RTDOSE")
                        {
                            var refSOPInstanceUID = dcm.FindFirst(TagHelper.ReferencedSOPInstanceUID)?.DData.ToString();
                            Console.WriteLine($"refSOPInstanceUID:{refSOPInstanceUID}");
                            var parenPath = new DirectoryInfo(file).Parent.Parent.FullName;
                            var RTPlanPath = System.IO.Path.Combine(parenPath, "DICOM RT Plan");
                            string[] RTplanfiles = Directory.GetFiles(RTPlanPath, "*.dcm");
                            var RTdcmFiles = RTplanfiles.Where(RTfile => Path.GetExtension(RTfile).Equals(".dcm", StringComparison.OrdinalIgnoreCase));

                            if (RTdcmFiles.Any())
                            {
                                foreach (var RTfile in RTdcmFiles)
                                {
                                    // DICOMファイルを読み込む
                                    var RTdcm = DICOMObject.Read(RTfile);
                                    var RTplanId = RTdcm.FindFirst(TagHelper.RTPlanLabel)?.DData.ToString();
                                    var RTmodality = RTdcm.FindFirst(TagHelper.Modality)?.DData.ToString();
                                    var SOPInstanceUID = RTdcm.FindFirst(TagHelper.SOPInstanceUID)?.DData.ToString();
                                    //Console.WriteLine($"RTfile: {RTfile}");
                                    //Console.WriteLine($"SOPInstanceUID:{SOPInstanceUID}");
                                    if (SOPInstanceUID == refSOPInstanceUID)
                                    {
                                        planId = RTplanId;
                                    }
                                }
                            }

                            Console.WriteLine($"File: {file}, " +
    $"Patient Id: {patientId}, " +
    $"Patient Name: {patientName}, " +
    $"Modality: {modality}, " +
    $"Plan Id: {planId}, " +
    $"Ref.BeamNo.: {refBeamNo}"
    );

                            newFileName = System.IO.Path.Combine(filePath, planId + refBeamNo + "_" + oldFileName);
                            Console.WriteLine($"new File{newFileName}");
                        }
                        else
                        { }
                        try
                        {
                            File.Move(file, newFileName);

                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("The renaming failed: {0}", ex.ToString());
                        }

                    }
                }
                else
                {
                    txtFilePath.Text = "ドロップされた.dcmファイルはありません。";
                }
            }
        }
    }
}