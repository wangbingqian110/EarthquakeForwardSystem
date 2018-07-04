using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFS
{
    public partial class ForwardCalculationForm : Form
    {
        public delegate void EventHandler(object sender, DataChangeEventArgs args);
        public event EventHandler DataChange;
        public ForwardCalculationForm(double sxvalue, double szvalue)
        {
            InitializeComponent();
            sx.Text = sxvalue.ToString();
            sz.Text = szvalue.ToString();
        }

        public class DataChangeEventArgs : EventArgs
        {
            public int Time { get; set; }
            public int Sx { get; set; }
            public int Sz { get; set; }
            public string File1 { get; set; }
            public string File2 { get; set; }
            public string File3 { get; set; }


            public DataChangeEventArgs(int nt, int sx, int sz, string f1, string f2, string f3)
            {
                Time = nt;
                Sx = sx;
                Sz = sz;
                File1 = f1;
                File2 = f2;
                File3 = f3;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (file1.Text == "" || file2.Text == "" || file3.Text == "")
            {
                MessageBox.Show("信息不全！");
            }
            else
            {
                if (DataChange != null)
                {
                    DataChange(this, new DataChangeEventArgs(int.Parse(time.Text), int.Parse(sx.Text), int.Parse(sz.Text), file1.Text, file2.Text, file3.Text));
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void file1btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "文本文件|*.txt";
            // 显示对话框
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 文件名
                file1.Text = openFileDialog.FileName;
            }
        }

        private void file2btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "文本文件|*.txt";
            // 显示对话框
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 文件名
                file2.Text = openFileDialog.FileName;
            }
        }

        private void file3btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "文本文件|*.txt";
            // 显示对话框
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 文件名
                file3.Text = openFileDialog.FileName;
            }
        }
    }
}
