using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<FileSystemInfo> _dragFiles = new List<FileSystemInfo>();
        private readonly List<FileInfo> _searchFileInfos = new List<FileInfo>();
        private int _delNum;
        private string[] _filter_extention;
        private float _limitSize = 10;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Link;
            else e.Effects = DragDropEffects.None;
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            _dragFiles.Clear();
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
                foreach (var o in (Array) data)
                    if (File.Exists(o.ToString())) _dragFiles.Add(new FileInfo(o.ToString()));
                    else
                        _dragFiles.Add(new DirectoryInfo(o.ToString()));
            RefreshlvDragList();
        }

        private void RefreshlvDragList()
        {
            var dragFileModels = new List<FileBean>();
            foreach (var file in _dragFiles)
                if (file != null)
                    if (file is FileInfo)
                    {
                        var tFile = (FileInfo) file;
                        var bean = new FileBean
                        {
                            FileName = tFile.Name,
                            Icon = "Assets/文件.png",
                            FilePath = tFile.DirectoryName,
                            Describe = (tFile.Length / 1024 / 1024).ToString("0.00") + " MB"
                        };
                        dragFileModels.Add(bean);
                    }
                    else if (file is DirectoryInfo)
                    {
                        var tFile = (DirectoryInfo) file;
                        var bean = new FileBean
                        {
                            FileName = tFile.Name,
                            Icon = "Assets/文件夹.png",
                            FilePath = tFile.FullName,
                            Describe = tFile.GetFiles().Length + "项"
                        };
                        dragFileModels.Add(bean);
                    }
            DragListView.ItemsSource = dragFileModels;
            Charge();
        }

        private void Charge()
        {
//            btnSearch.Enabled = false;
//            btnDelEmpty.Enabled = false;
//            btnDelFIle.Enabled = false;
//            if (_dragFiles.Count > 0)
//            {
//                labAttention.Text = "可以开始搜索";
//                btnSearch.Enabled = true;
//                btnDelFIle.Enabled = true;
//            }
//            if (_searchFileInfos.Count > 0)
//            {
//                labAttention.Text = "请继续操作";
//                btnDelEmpty.Enabled = true;
//            }
        }
    }
}