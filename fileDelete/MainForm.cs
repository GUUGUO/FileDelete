using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace fileDelete
{
    public partial class MainForm : Form
    {
        private readonly List<FileSystemInfo> _dragFiles = new List<FileSystemInfo>();
        private readonly List<FileInfo> _searchFileInfos = new List<FileInfo>();
        private int _delNum;
        private string[] _filter_extention;
        private float _limitSize = 10;

        public MainForm()
        {
            InitializeComponent();


            btnSearch.Enabled = false;
            btnDelFIle.Enabled = false;
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            _dragFiles.Clear();

            foreach (var o in (Array) e.Data.GetData(DataFormats.FileDrop))
                if (File.Exists(o.ToString())) _dragFiles.Add(new FileInfo(o.ToString()));
                else
                    _dragFiles.Add(new DirectoryInfo(o.ToString()));
            RefreshlvDragList();
        }

        private void RefreshlvDragList()
        {
            var dragWidth = lv_drag_list.Width;
            lv_drag_list.Columns.Clear();
            lv_drag_list.Columns.Add("文件名", (dragWidth - 120) / 3, HorizontalAlignment.Left);
            lv_drag_list.Columns.Add("路径", (dragWidth - 120) * 2 / 3, HorizontalAlignment.Left);
            lv_drag_list.Columns.Add("文件大小", 120, HorizontalAlignment.Center);

            lv_drag_list.Items.Clear(); //清空lv1中的记录
            lv_search_result.BeginUpdate();
            foreach (var file in _dragFiles) 

                if (file is FileInfo)
                {
                    var item = new ListViewItem(((FileInfo) file).Name);
                    item.SubItems.Add(((FileInfo) file).DirectoryName);
                    item.SubItems.Add(((float) ((FileInfo) file).Length / 1024 / 1024).ToString("0.00") + " MB");
                    lv_drag_list.Items.Add(item);
                }
                else if (file is DirectoryInfo)
                {
                    var item = new ListViewItem(((DirectoryInfo) file).Name);
                    item.SubItems.Add(((DirectoryInfo) file).FullName);
                    lv_drag_list.Items.Add(item);
                }
            lv_search_result.EndUpdate(); //结束数据处理，UI界面一次性绘制。  
            Charge();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private bool CheckFile(FileInfo file)
        {
            return (float) file.Length / 1024 / 1024 <= _limitSize;
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

        private void RefreshLvSearchList()
        {
                labAttention.Text = "找到"+_searchFileInfos.Count+"个符合条件的结果";

                lv_search_result.Columns.Clear();
                lv_search_result.Columns.Add("路径", 180, HorizontalAlignment.Right);
                lv_search_result.Columns.Add("文件名", 100, HorizontalAlignment.Left);
                lv_search_result.Columns.Add("文件大小", 60, HorizontalAlignment.Left);
                lv_search_result.Items.Clear(); //清空lv1中的记录
                foreach (var file in _searchFileInfos) //前提是stu有数据，stu是DataTable
                {
                    var item = new ListViewItem(file.DirectoryName);
                    item.SubItems.Add(file.Name);
                    item.SubItems.Add(((float) file.Length / 1024 / 1024).ToString("0.00") + " MB");
                    lv_search_result.Items.Add(item);
                }
                Charge();
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

        private void Charge()
        {
            btnSearch.Enabled = false;
            btnDelEmpty.Enabled = false;
            btnDelFIle.Enabled = false;
            if (_dragFiles.Count > 0)
            {
                labAttention.Text = "可以开始搜索";
                btnSearch.Enabled = true;
            btnDelFIle.Enabled = true;
            }
            if (_searchFileInfos.Count > 0)
            {
                labAttention.Text = "请继续操作";
                btnDelEmpty.Enabled = true;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnDelFIle_Click(object sender, EventArgs e)
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

        private void tv_extention_TextChanged(object sender, EventArgs e)
        {
            _filter_extention = tv_extention.Text.Split(',');
        }

        private void txtSize_TextChanged(object sender, EventArgs e)
        {
            if (tv_limit_size.Text != "" && Regex.IsMatch(tv_limit_size.Text, @"^\d*\.?\d*$"))
            {
                _limitSize = float.Parse(tv_limit_size.Text);
                Charge();
            }
            else
            {
                labAttention.Text = "请输入正确的限制数字";
            }
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

        private void btnDelEmpty_Click(object sender, EventArgs e)
        {
            _delNum = 0;

            var emptyDirectoryList = new List<DirectoryInfo>();
            foreach (var file in _dragFiles) //前提是stu有数据，stu是DataTable
                if (file is DirectoryInfo)
                    CheckEmptyFile(emptyDirectoryList, (DirectoryInfo) file);
            if (emptyDirectoryList.Count == 0)
            {
                labAttention.Text = "没有找到空文件夹";
            }
            else
            {
                lv_search_result.Columns.Clear();
                lv_search_result.Items.Clear();
                lv_search_result.Columns.Add("已删除文件夹", 300, HorizontalAlignment.Right);
                foreach (var folder in emptyDirectoryList) //前提是stu有数据，stu是DataTable
                {
                    _delNum++;
                    var item = new ListViewItem(folder.Name);
                    lv_search_result.Items.Add(item);
                    folder.Delete();
                    labAttention.Text = "已删除 " + _delNum + " 个空文件夹";
                }
                RefreshValideDragList();
            }
        }

        private void RefreshValideDragList()
        {
            for (var i = _dragFiles.Count - 1; i > 0; i--)
                if (!_dragFiles[i].Exists)
                    _dragFiles.RemoveAt(i);
            RefreshlvDragList();
        }

        private void btnClearDrag_Click(object sender, EventArgs e)
        {
            _dragFiles.Clear();
            _searchFileInfos.Clear();
            RefreshlvDragList();
            RefreshLvSearchList();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            Search();
        }
    }
}