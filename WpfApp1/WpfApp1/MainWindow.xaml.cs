using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
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
                            Describe = CommonUtil.GetSizeString(tFile.Length)
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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void Search()
        {
            _searchFileInfos.Clear();

            foreach (var file in _dragFiles) //前提是stu有数据，stu是DataTable

                if (file is FileInfo)
                {
                    if (CheckFile((FileInfo) file))
                        _searchFileInfos.Add((FileInfo) file);
                }
                else if (file is DirectoryInfo)
                {
                    SearchFile((DirectoryInfo) file);
                }
            RefreshLvSearchList();
        }

        private void SearchFile(DirectoryInfo folder)
        {
            if (folder.Exists)
            {
                var directory = folder.GetDirectories();
                foreach (var f in directory)
                    SearchFile(f);
                var fileInfo = folder.GetFiles();
                foreach (var file in fileInfo)
                    if (CheckFile(file))
                        _searchFileInfos.Add(file);
            }
        }

        private bool CheckFile(FileInfo file)
        {
            return (float) file.Length / 1024 / 1024 <= _limitSize;
        }

        private void RefreshLvSearchList()
        {
            TbAttention.Text = "找到" + _searchFileInfos.Count + "个符合条件的结果";

            var resultList = new List<FileBean>();
            foreach (var file in _searchFileInfos) //前提是stu有数据，stu是DataTable
            {
                var bean = new FileBean()
                {
                    FileName = file.Name,
                    Icon = "Assets/文件.png",
                    FilePath = file.DirectoryName,
                    Describe = CommonUtil.GetSizeString(file.Length)
                };
                resultList.Add(bean);
            }
            ResultListView.ItemsSource = resultList;
            Charge();
        }

        private void TBoxLimitSize_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (TBoxLimitSize.Text != "" && Regex.IsMatch(TBoxLimitSize.Text, @"^\d*\.?\d*$"))
            {
                _limitSize = float.Parse(TBoxLimitSize.Text);
                Charge();
            }
            else
            {
                TbAttention.Text = "请输入正确的限制数字";
            }
        }

        private void btnDelEmpty_Click(object sender, RoutedEventArgs e)
        {
            _delNum = 0;

            var emptyDirectoryList = new List<DirectoryInfo>();
            foreach (var file in _dragFiles) //前提是stu有数据，stu是DataTable
                if (file is DirectoryInfo)
                    CheckEmptyFile(emptyDirectoryList, (DirectoryInfo) file);
            var dragFileModels = new List<FileBean>();
            if (emptyDirectoryList.Count == 0)
            {
                TbAttention.Text = "没有找到空文件夹";
            }
            else
            {
                //                lv_search_result.Columns.Clear();
                //                lv_search_result.Items.Clear();
                //                lv_search_result.Columns.Add("已删除文件夹", 300, HorizontalAlignment.Right);
                foreach (var folder in emptyDirectoryList) //前提是stu有数据，stu是DataTable
                {
                    _delNum++;
                    //                    var item = new ListViewItem(folder.Name);
                    //                    lv_search_result.Items.Add(item);
                    var bean = new FileBean
                    {
                        FileName = folder.Name,
                        FilePath = folder.FullName,
                        Describe = "空文件夹"
                    };
                    dragFileModels.Add(bean);
                    folder.Delete();
                    TbAttention.Text = "已删除 " + _delNum + " 个空文件夹";
                }
                RefreshValideDragList();
            }
            ResultListView.ItemsSource = dragFileModels;
        }

        private bool CheckEmptyFile(List<DirectoryInfo> list, DirectoryInfo folder)
        {
            var directory = folder.GetDirectories();

            foreach (var childFolder in directory)
                if (!CheckEmptyFile(list, childFolder)) return false;
            var childFiles = folder.GetFiles();
            if (childFiles.Length == 0)
            {
                list.Add(folder);
                return true;
            }
            return false;
        }

        private void RefreshValideDragList()
        {
            for (var i = _dragFiles.Count - 1; i > 0; i--)
                if (!_dragFiles[i].Exists)
                    _dragFiles.RemoveAt(i);
            RefreshlvDragList();
        }

        private void BtnDelFile_Click(object sender, RoutedEventArgs e)
        {
            foreach (var file in _searchFileInfos)
                try
                {
                    file.Delete();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            Search();
        }
    }
}