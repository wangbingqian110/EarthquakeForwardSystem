using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EFS
{
    public partial class CreateRockFormation : Form
    {
        public int index = -1;
        // 定义委托
        public delegate void EventHandler(object sender, DrawEventArgs args);
        // 声明事件
        public event EventHandler DataChange;
        // 调用事件函数
        public void OnDataChange(object sender, DrawEventArgs args)
        {
            if (DataChange != null)
            {
                DataChange(this, args);
            }
        }
        public class DrawEventArgs : EventArgs
        {
            public string Name { get; set; }
            public string Speed { get; set; }
            public string Density { get; set; }
            public Color Color { get; set; }

            public int Index { get; set; }

            public DrawEventArgs(string s1, string s2, string s3, Color s4,int index)
            {
                Name = s1;
                Speed = s2;
                Density = s3;
                Color = s4;
                Index = index;
            }
        }
        public CreateRockFormation()
        {
            InitializeComponent();
        }

        private void selectColor_Click(object sender, EventArgs e)
        {
            ColorDialog ColorForm = new ColorDialog();
            if (ColorForm.ShowDialog() == DialogResult.OK)
            {
                Color GetColor = ColorForm.Color;
                //GetColor就是用户选择的颜色，接下来就可以使用该颜色了
                selectColor.BackColor = GetColor;
            }
        }

        private void sure_Click(object sender, EventArgs e)
        {
            OnDataChange(this, new DrawEventArgs(name.Text, speed.Text, density.Text,selectColor.BackColor,index));
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
