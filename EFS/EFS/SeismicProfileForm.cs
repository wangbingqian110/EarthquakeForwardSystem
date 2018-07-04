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
    public partial class SeismicProfileForm : Form
    {
        public delegate void EventHandler(object sender, DataChangeEventArgs args);
        public event EventHandler DataChange;
        public SeismicProfileForm(double sxvalue, double szvalue)
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


            public DataChangeEventArgs(int nt, int sx, int sz)
            {
                Time = nt;
                Sx = sx;
                Sz = sz;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (DataChange != null)
            {
                DataChange(this, new DataChangeEventArgs(int.Parse(time.Text), int.Parse(sx.Text), int.Parse(sz.Text)));
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
