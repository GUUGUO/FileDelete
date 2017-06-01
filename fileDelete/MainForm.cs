using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fileDelete
{
    public partial class MainForm : Form
    {
        private float _limitSize = 10;
        private readonly List<FileInfo> _fileinfos = new List<FileInfo>();
        private bool _isPath = false;
        private bool _isSearch = false;
        private int _delNum = 0;

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

        private void panel1_DragLeave(object sender, EventArgs e)
        {
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            labFloder.Text = ((System.Array) e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (File.Exists(labFloder.Text))
            {
                _isPath = false;
            }
            else
            {
                _isPath = true;
            }
            Charge();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        void Search()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("路径", 180, HorizontalAlignment.Right);
            listView1.Columns.Add("文件名", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("文件大小", 60, HorizontalAlignment.Left);
            listView1.Items.Clear(); //清空lv1中的记录
            _fileinfos.Clear();
            DirectoryInfo theFolder = new DirectoryInfo(labFloder.Text);
            SearchFile(theFolder);
            foreach (FileInfo file in _fileinfos) //前提是stu有数据，stu是DataTable

            {
                ListViewItem item = new ListViewItem(file.DirectoryName);
                item.SubItems.Add(file.Name);
                item.SubItems.Add((((float) file.Length) / 1024 / 1024).ToString("0.00") + " MB");
                this.listView1.Items.Add(item);
            }
            _isSearch = true;
            Charge();
        }

        private void Charge()
        {
            if (!_isPath)
            {
                btnSearch.Enabled = false;
                labAttention.Text = "该路径不是文件夹，请重新拖拽";
                btnSearch.Enabled = false;
                btnDelEmpty.Enabled = false;
            }
            else if (!_isSearch)
            {
                labAttention.Text = "可以开始搜索";
                btnSearch.Enabled = true;
                btnDelEmpty.Enabled = true;
                btnDelFIle.Enabled = false;
            }
            else
            {
                labAttention.Text = "请继续操作";
                btnDelFIle.Enabled = true;
            }
        }

        private void SearchFile(DirectoryInfo folder)
        {
            DirectoryInfo[] directory = folder.GetDirectories();
            foreach (DirectoryInfo f in directory)
            {
                SearchFile(f);
            }
            FileInfo[] fileInfo = folder.GetFiles();
            foreach (FileInfo file in fileInfo)
            {
                if (((float) file.Length) / 1024 / 1024 <= _limitSize)
                {
                    _fileinfos.Add(file);
                }
            }
            return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnDelFIle_Click(object sender, EventArgs e)
        {
            foreach (FileInfo file in _fileinfos)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
            Search();
        }


        private void txtSize_TextChanged(object sender, EventArgs e)
        {
            if (txtSize.Text != "" && Regex.IsMatch(txtSize.Text, @"^\d*\.?\d*$"))
            {
                _limitSize = float.Parse(txtSize.Text);
                Charge();
            }
            else
            {
                labAttention.Text = "请输入正确的限制数字";
            }
        }

        private bool DeleteEmptyFile(DirectoryInfo folder)
        {
            bool isEmpty = true;
            DirectoryInfo[] directory = folder.GetDirectories();
            foreach (DirectoryInfo Folder in directory)
            {
                isEmpty = DeleteEmptyFile(Folder);
                if (isEmpty)
                {
                    Folder.Delete();
                    _delNum++;
                    ListViewItem item = new ListViewItem(Folder.Name);
                    this.listView1.Items.Add(item);
                    labAttention.Text = "已删除 " + _delNum + " 个空文件夹";
                }
            }
            FileInfo[] fileInfo = folder.GetFiles();
            foreach (FileInfo file in fileInfo)
            {
                isEmpty = false;
            }
            return isEmpty;
        }

        private void btnDelEmpty_Click(object sender, EventArgs e)
        {
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("已删除文件夹", 300, HorizontalAlignment.Right);

            _delNum = 0;
            DirectoryInfo theFolder = new DirectoryInfo(labFloder.Text);
            if (DeleteEmptyFile(theFolder))
            {
                theFolder.Delete();
                _delNum++;
                ListViewItem item = new ListViewItem(theFolder.Name);
                this.listView1.Items.Add(item);
                labAttention.Text = "已删除 " + _delNum + " 个空文件夹";
            }
            if (_delNum == 0)
            {
                listView1.Columns.Clear();
                labAttention.Text = "没有找到空文件夹";
            }
        }
    }
}