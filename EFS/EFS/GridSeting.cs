using System;
using System.Windows.Forms;

namespace EFS
{
    public partial class GridSeting : Form
    {

        // 定义委托
        public delegate void DataChangeHandler(object sender, DataChangeEventArgs args);
        // 声明事件
        public event DataChangeHandler DataChange;
        // 调用事件函数
        public void OnDataChange(object sender, DataChangeEventArgs args) 
        {
            if (DataChange != null)
            {
                DataChange(this, args);
            }
        }
        public GridSeting()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sure_Click(object sender, EventArgs e)
        {
            string Xstep = Xfoot.Text;
            string Ystep = Yfoot.Text;
            string LeftBound = BoundLeft.Text;
            string RightBound = BoundRight.Text;
            string TopBound = BoundTop.Text;
            string BottomBound = BoundBottom.Text;
            OnDataChange(this, new DataChangeEventArgs(Xstep, Ystep, LeftBound, RightBound, TopBound, BottomBound));
        }

        /// <summary>
        /// 自定义事件参数类型，根据需要可设定多种参数便于传递
        /// </summary>

        public class DataChangeEventArgs : EventArgs
        {
            public string Xstep { get; set; }
            public string Ystep { get; set; }
            public string LeftBound { get; set; }
            public string RightBound { get; set; }
            public string TopBound { get; set; }
            public string BottomBound { get; set; }
            public DataChangeEventArgs(string s1, string s2, string s3,string s4,string s5, string s6)
            {
                Xstep = s1;
                Ystep = s2;
                LeftBound = s3;
                RightBound = s4;
                TopBound = s5;
                BottomBound = s6;
            }
        }
    }
}
