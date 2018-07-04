using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace EFS
{
    public partial class Chart : Form
    {
        float[,] Record = null;
        CurveList GcurveItems = new CurveList();
        double NZ;
        public Chart(float[,] record, CurveList curveItems, double Nz)
        {
            InitializeComponent();
            CreateGraph(record);
            Record = record;
            GcurveItems = curveItems;
            NZ = Nz;
        }
        public Chart(float[,] record)
        {
            InitializeComponent();
            CreateGraph(record);
        }
        private void CreateGraph(float[,] record, CurveList curveItems)
        {
            GraphPane myPane = RecordZedGraphControl.GraphPane;
            int row = record.GetUpperBound(0) + 1;
            int col = record.GetUpperBound(1) + 1;
            for (int i = 0; i < curveItems.Count - 1; i++)
            {
                IPointListEdit oldlist = curveItems[i].Points as IPointListEdit;

                for (int j = 0; j < oldlist.Count - 1; j++)
                {
                    PointPairList Redlist1 = new PointPairList();
                    PointPairList Bluelist = new PointPairList();
                    PointPairList Redlist2 = new PointPairList();
                    double k = Math.Abs((((oldlist[j + 1].Y * col) / NZ - (oldlist[j].Y * col) / NZ)) / ((oldlist[j + 1].X - oldlist[j].X)));
                    if (k < 1)
                    {
                        Redlist1.Add(oldlist[j].X, (oldlist[j].Y * col) / NZ - 2);
                        Redlist1.Add(oldlist[j + 1].X, (oldlist[j + 1].Y * col) / NZ - 2);
                        LineItem myCurveRed1 = myPane.AddCurve("", Redlist1, Color.FromArgb(50, 255, 0, 255), SymbolType.None);
                        myCurveRed1.Line.Width = 3;
                        Bluelist.Add(oldlist[j].X, (oldlist[j].Y * col) / NZ);
                        Bluelist.Add(oldlist[j + 1].X, (oldlist[j + 1].Y * col) / NZ);
                        LineItem myCurveBlue = myPane.AddCurve("", Bluelist, Color.FromArgb(50, 40, 12, 243), SymbolType.None);
                        myCurveBlue.Line.Width = 3;
                        Bluelist.Add(oldlist[j].X, (oldlist[j].Y * col) / NZ + 2);
                        Bluelist.Add(oldlist[j + 1].X, (oldlist[j + 1].Y * col) / NZ + 2);
                        LineItem myCurveRed2 = myPane.AddCurve("", Redlist2, Color.FromArgb(50, 255, 0, 255), SymbolType.None);
                        myCurveRed2.Line.Width = 3;
                    }

                }
            }

            //绘制图形

            RecordZedGraphControl.AxisChange();
            RecordZedGraphControl.Refresh();
        }
        private void CreateGraph(float[,] record)
        {
            GraphPane myPane = RecordZedGraphControl.GraphPane;
            myPane.Title.Text = "    ";
            myPane.XAxis.Title.IsVisible = false;
            myPane.YAxis.Title.IsVisible = false;
            myPane.YAxis.Scale.IsReverse = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.Scale.FontSpec.Size = 10;
            myPane.XAxis.Cross = 0;
            myPane.XAxis.Scale.IsLabelsInside = true;
            myPane.YAxis.Scale.FontSpec.Size = 10;
            myPane.YAxis.Scale.FontSpec.Angle = 180;

            for (int i = 0; i < record.GetUpperBound(0) + 1; i++)
            {
                PointPairList list = new PointPairList();
                for (int j = 0; j < record.GetUpperBound(1) + 1; j++)
                {
                    list.Add(i + (record[i, j]), j);
                }
                LineItem myCurve = myPane.AddCurve("",
                   list, Color.Black, SymbolType.None);
            }

            //绘制图形

            RecordZedGraphControl.AxisChange();
            RecordZedGraphControl.Refresh();
        }

        private void RecordZedGraphControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CreateGraph(Record, GcurveItems);
        }
    }
}
