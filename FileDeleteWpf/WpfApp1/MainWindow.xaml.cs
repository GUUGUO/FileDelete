using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using FileDeleteWpf.Model;

namespace FileDeleteWpf
{
    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<FileSystemInfo> _dragFiles = new List<FileSystemInfo>();
        private readonly List<FileSystemInfo> _searchFileInfos = new List<FileSystemInfo>();
        private List<String> _filterExtention = new List<String>();
        private float _limitSize = 10;
        private int _searchType = SearchTypeCondition;

        private const int SearchTypeCondition = 0;
        private const int SearchTypeEmpty = 1;

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
            {
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
            }

            DragListView.ItemsSource = dragFileModels;
            Charge();
        }

        private void Charge()
        {
            BtnConditionSearch.IsEnabled = false;
            BtnEmptySearch.IsEnabled = false;
            BtnDelFile.IsEnabled = false;
            BtnClearDrag.IsEnabled = false;
            if (_dragFiles.Count > 0)
            {
                if (TbAttention.Text.Length == 0)
                    TbAttention.Text = "可以开始搜索";
                BtnConditionSearch.IsEnabled = true;
                BtnClearDrag.IsEnabled = true;
                BtnEmptySearch.IsEnabled = true;
            }
            if (_searchFileInfos.Count > 0)
            {
                BtnDelFile.IsEnabled = true;
            }
        }

        private void btnConditionSearch_Click(object sender, RoutedEventArgs e)
        {
            ConditionSearch();
        }

        private void ConditionSearch()
        {
            RefreshValideDragList();
            _searchType = SearchTypeCondition;
            if (TBoxExtention.Text.Trim() != "")
                _filterExtention = TBoxExtention.Text.Split(',').ToList();
            else _filterExtention.Clear();
            for (int i = 0; i < _filterExtention.Count; i++)
            {
                _filterExtention[i] = _filterExtention[i].ToUpper();
            }
            _searchFileInfos.Clear();

            foreach (var file in _dragFiles)

                if (file is FileInfo)
                {
                    if (CheckFile((FileInfo) file))
                        _searchFileInfos.Add((FileInfo) file);
                }
                else if (file is DirectoryInfo)
                {
                    SearchFile((DirectoryInfo) file);
                }
            RefreshConditionSearchList();
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
            bool isSizeIn = (float) file.Length / 1024 / 1024 <= _limitSize;
            if (isSizeIn && _filterExtention.Count > 0)
                return _filterExtention.Contains(file.Extension.Remove(0, 1).ToUpper());
            return isSizeIn;
        }

        private void RefreshConditionSearchList()
        {
            var resultList = new List<FileBean>();
            foreach (var file in _searchFileInfos)
            {
                var tFile = (FileInfo) file;
                var bean = new FileBean()
                {
                    FileName = tFile.Name,
                    Icon = "Assets/文件.png",
                    FilePath = tFile.DirectoryName,
                    Describe = CommonUtil.GetSizeString(tFile.Length)
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
            }
            else
            {
                TbAttention.Text = "请输入正确的限制数字";
            }
        }

        private void BtnEmptySearchClick(object sender, RoutedEventArgs e)
        {
            EmptySearch();
        }

        private void EmptySearch()
        {
            _searchType = SearchTypeEmpty;
            var emptyNum = 0;

            var emptyDirectoryList = new List<DirectoryInfo>();
            RefreshValideDragList();
            foreach (var file in _dragFiles)
                if (file is DirectoryInfo)
                {
                    CheckEmptyFile(emptyDirectoryList, (DirectoryInfo) file);
                }
            var dragFileModels = new List<FileBean>();
            if (emptyDirectoryList.Count != 0)
            {
                foreach (var folder in emptyDirectoryList)
                {
                    emptyNum++;
                    var bean = new FileBean
                    {
                        FileName = folder.Name,
                        FilePath = folder.FullName,
                        Describe = "空文件夹"
                    };
                    dragFileModels.Add(bean);
                }
            }
            _searchFileInfos.Clear();
            _searchFileInfos.AddRange(emptyDirectoryList);
            ResultListView.ItemsSource = dragFileModels;
            Charge();
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
            for (var i = _dragFiles.Count - 1; i >= 0; i--)
            {
                if (!_dragFiles[i].Exists)
                    _dragFiles.RemoveAt(i);
                else if (_dragFiles[i] is DirectoryInfo)
                    try
                    {
                        ((DirectoryInfo) _dragFiles[i]).GetDirectories();
                    }
                    catch (Exception e)
                    {
                        _dragFiles.RemoveAt(i);
                    }
            }
            RefreshlvDragList();
        }

        private void BtnDelFile_Click(object sender, RoutedEventArgs e)
        {
            var delNum = 0;
            var needDelNum = _searchFileInfos.Count;
            foreach (var file in _searchFileInfos)
                try
                {
                    file.Delete();
                    file.Refresh();
                    delNum++;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            TbAttention.Text = "删除成功" + delNum + "个 失败" + (needDelNum - delNum) + "个";
            switch (_searchType)
            {
                case SearchTypeCondition:
                    ConditionSearch();
                    break;
                case SearchTypeEmpty:
                    EmptySearch();
                    break;
            }
        }

        //0是条件搜索 1是空文件夹搜索

        private void TBoxExtention_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
        }

        private void BtnClearDrag_Click(object sender, EventArgs e)
        {
            _dragFiles.Clear();
            _searchFileInfos.Clear();
            DragListView.ItemsSource = new List<FileBean>();
            ResultListView.ItemsSource = new List<FileBean>();
            TbAttention.Text = "";
            Charge();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Charge();
        }
    }
}