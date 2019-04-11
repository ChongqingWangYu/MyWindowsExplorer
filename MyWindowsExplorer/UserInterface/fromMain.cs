﻿using MyWindowsExplorer.BusinessLogicLayer;
using System;
using System.Windows.Forms;

namespace MyWindowsExplorer
{
    public partial class FromMain : Form
    {
        FromMainBLL bll;
         //主窗口构造方法
         public FromMain()
        {
            //主窗控件初始化
            InitializeComponent();
        }

        //窗口加载事件
        private void fromMain_Load(object sender, EventArgs e)
        {
            bll = new FromMainBLL(TreeView,ListView, this.Handle, imageList,curPathText,  leftPathButton,  rightPathButton,  backUpPathButton);
            bll.fromMainInit();
        }
        //树节点点击事件
        private void TreeViewFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //树节点显示
            bll.TreeViewShow(e.Node);
            //列表显示
            bll.ListViewShow(e.Node);
            bll.updatePathButtonState();
        }
        //列表文件夹双击事件
        private void ListViewFile_DoubleClick(object sender, EventArgs e)
        {
            foreach (int ListIndex in ListView.SelectedIndices)
            {
                bll.ListViewShow(bll.curPath + ListView.Items[ListIndex].Text);
            }
            bll.updatePathButtonState();
        }
        
        //left目录
        private void leftPath_Click(object sender, EventArgs e)
        {
            bll.leftReturnPath();
            bll.updatePathButtonState();
        }
        //rigth目录
        private void rightPath_Click(object sender, EventArgs e)
        {
            bll.rightReturnPath();
            bll.updatePathButtonState();
        }
        //回到上一级目录
        private void backUp_Click(object sender, EventArgs e)
        {
            bll.backUpPath();
            bll.updatePathButtonState();
        }

        private void curPathText_KeyDown(object sender, KeyEventArgs e)
        {
            //判断回车键
            if (e.KeyCode == Keys.Enter)
            {
                bll.ListViewShow(curPathText.Text);
            }
        }
    }
}