using AlgorithmNameSpace;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;
using SeismicProfileNameSpace;

namespace EFS
{
    public partial class MainForm : Form
    {
        private bool isStartDraw = false;
        private bool isModify = false;
        private List<RockFormation> rockFormations = new List<RockFormation>();
        private CurveItem TargetcurveItem = null;
        private int TarfgetIndex;
        private delegate void EventHandler();
        public delegate void Entrust(float[,] vs);
        private Color LineColor = Color.FromArgb(255, 1, 0, 34);
        private Color backColor = Color.FromArgb(255, 255, 255, 255);
        private Color AxisColor = Color.FromArgb(255, 0, 0, 0);
        float[,] Gv = null;
        Bitmap bmp = null;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl);
        }
        private void gridProperty_Click(object sender, EventArgs e)
        {
            GridSeting gridSeting = new GridSeting();
            gridSeting.DataChange += new EFS.GridSeting.DataChangeHandler(DataChanged);
            gridSeting.ShowDialog();
        }
        /// <summary>
        /// 设置网格窗口确定事件的委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void DataChanged(object sender, EFS.GridSeting.DataChangeEventArgs args)
        {
            SetGridRange(zedGraphControl, args);
            GridSeting gridSeting = (GridSeting)sender;
            gridSeting.Close();
            toolStrip.Enabled = true;
        }
        /// <summary>
        /// 设置网格范围
        /// </summary>
        /// <param name="zgc">控件名称</param>
        /// <param name="args">范围值</param>
        private void SetGridRange(ZedGraphControl zgc, EFS.GridSeting.DataChangeEventArgs args)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;
            //设置步长
            myPane.XAxis.Scale.MajorStep = double.Parse(args.Xstep);
            myPane.YAxis.Scale.MajorStep = double.Parse(args.Ystep);
            // 设置坐标轴的大小
            myPane.YAxis.Scale.Min = double.Parse(args.TopBound);
            myPane.YAxis.Scale.Max = double.Parse(args.BottomBound);
            myPane.XAxis.Scale.Min = double.Parse(args.LeftBound);
            myPane.XAxis.Scale.Max = double.Parse(args.RightBound);
            zgc.AxisChange();
            zgc.Refresh();
        }
        /// <summary>
        /// 初始化图表
        /// </summary>
        /// <param name="zgc">控件名称</param>
        private void CreateGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
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
            zgc.AxisChange();
        }
        private void zedGraphControl_MouseMove(object sender, MouseEventArgs e)
        {
            // Save the mouse location
            PointF mousePt = new PointF(e.X, e.Y);

            // Find the Chart rect that contains the current mouse location
            GraphPane pane = ((ZedGraphControl)sender).MasterPane.FindChartRect(mousePt);

            // If pane is non-null, we have a valid location.  Otherwise, the mouse is not
            // within any chart rect.
            if (pane != null)
            {
                double x, y;
                // Convert the mouse location to X, and Y scale values
                pane.ReverseTransform(mousePt, out x, out y);

                // 获取横纵坐标信息
                coordinateX.Text = x.ToString("f2");
                coordinateY.Text = y.ToString("f2");
                //coordinateX.Text = e.X.ToString();
                //coordinateY.Text = e.Y.ToString();
                //ColorRGB.Text = ;

                // 改变鼠标指针
                object nearestCurve;
                int iNearest;
                bool isSelected = zedGraphControl.GraphPane.FindNearestObject(mousePt, zedGraphControl.CreateGraphics(), out nearestCurve, out iNearest);
                if (isSelected)
                {
                    zedGraphControl.Cursor = Cursors.Hand;
                }
                else
                {
                    if (isStartDraw || isModify)
                    {
                        zedGraphControl.Cursor = Cursors.Cross;
                    }
                    else
                    {
                        zedGraphControl.Cursor = Cursors.Default;
                    }
                }

                // 拖拽修改折线
                if (isModify)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (TargetcurveItem != null)
                        {
                            IPointListEdit newlist = TargetcurveItem.Points as IPointListEdit;
                            newlist[TarfgetIndex].X = double.Parse(x.ToString("f2"));
                            newlist[TarfgetIndex].Y = double.Parse(y.ToString("f2"));
                            zedGraphControl.AxisChange();
                            zedGraphControl.Refresh();
                        }
                    }
                }
            }
        }
        private void startDraw_Click(object sender, EventArgs e)
        {
            isStartDraw = true;
            completeDraw.Enabled = true;
            startDraw.Enabled = false;
            zedGraphControl.Cursor = Cursors.Cross;
            zedGraphControl.Refresh();
        }
        /// <summary>
        /// 新建岩层窗口确定事件委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CreateRockFormationDelegate(object sender, CreateRockFormation.DrawEventArgs args)
        {

            PointPairList list = new PointPairList();
            // get a reference to the GraphPane
            GraphPane myPane = zedGraphControl.GraphPane;
            LineItem myCurve = myPane.AddCurve("",
               list, LineColor, SymbolType.None);
            // add data to rockFormations
            rockFormations.Add(new RockFormation(args.Name, args.Speed, args.Density, args.Color));
            CreateRockFormation createRockFormation = (CreateRockFormation)sender;
            createRockFormation.Close();
            startDraw.Enabled = true;
            Modify.Enabled = false;
            Create.Enabled = false;
            Goback.Enabled = false;
            Clear.Enabled = false;
        }

        private void zedGraphControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (isStartDraw)
            {
                GraphPane myPane = zedGraphControl.GraphPane;
                // Save the mouse location
                PointF mousePt = new PointF(e.X, e.Y);


                // Find the Chart rect that contains the current mouse location
                GraphPane pane = ((ZedGraphControl)sender).MasterPane.FindChartRect(mousePt);

                // If pane is non-null, we have a valid location.  Otherwise, the mouse is not
                // within any chart rect.
                if (pane != null)
                {
                    double x, y;
                    // Convert the mouse location to X, and Y scale values
                    pane.ReverseTransform(mousePt, out x, out y);
                    // Determine if the clicked point exists
                    object nearestCurve;
                    int iNearest;
                    bool isSelected = zedGraphControl.GraphPane.FindNearestObject(mousePt, zedGraphControl.CreateGraphics(), out nearestCurve, out iNearest);
                    if (isSelected && iNearest == 0)
                    {
                        CurveItem curveItem = (CurveItem)nearestCurve;
                        x = curveItem.Points[iNearest].X;
                        y = curveItem.Points[iNearest].Y;
                    }
                    LineItem myCurve = (LineItem)pane.CurveList[pane.CurveList.Count - 1];
                    IPointListEdit newlist = myCurve.Points as IPointListEdit;

                    newlist.Add(x, y);
                    zedGraphControl.AxisChange();
                    zedGraphControl.Refresh();

                }
            }
        }

        private void completeDraw_Click(object sender, EventArgs e)
        {
            isStartDraw = false;
            isModify = false;
            //设置按钮的可用性
            Goback.Enabled = true;
            Create.Enabled = true;
            Modify.Enabled = true;
            completeDraw.Enabled = false;
            Clear.Enabled = true;
            zedGraphControl.Cursor = Cursors.Default;
            //画布操作
            GraphPane myPane = zedGraphControl.GraphPane;
            LineItem myCurve = (LineItem)myPane.CurveList[myPane.CurveList.Count - 1];
            myCurve.Line.Fill = new Fill(rockFormations[rockFormations.Count - 1].Color);
            //拓扑检查
            PointF pointXYAxis_Min = zedGraphControl.GraphPane.GeneralTransform(myPane.XAxis.Scale.Min, myPane.YAxis.Scale.Min, CoordType.AxisXYScale);
            PointF pointXYAxis_Max = zedGraphControl.GraphPane.GeneralTransform(myPane.XAxis.Scale.Max, myPane.YAxis.Scale.Max, CoordType.AxisXYScale);
            for (int j = 0; j < myPane.CurveList.Count; j++)
            {
                IPointListEdit newlist = myPane.CurveList[j].Points as IPointListEdit;
                for (int i = 0; i < newlist.Count; i++)
                {
                    double x = newlist[i].X;
                    double y = newlist[i].Y;
                    PointF pointF = zedGraphControl.GraphPane.GeneralTransform(newlist[i], CoordType.AxisXYScale);
                    if ((pointF.X - pointXYAxis_Min.X) < 5)
                    {
                        x = myPane.XAxis.Scale.Min;
                    }
                    else if ((pointXYAxis_Max.X - pointF.X) < 5)
                    {
                        x = myPane.XAxis.Scale.Max;
                    }
                    if ((pointF.Y - pointXYAxis_Min.Y) < 5)
                    {
                        y = myPane.YAxis.Scale.Min;
                    }
                    else if ((pointXYAxis_Max.Y - pointF.Y) < 5)
                    {
                        y = myPane.YAxis.Scale.Max;
                    }

                    newlist[i].X = x;
                    newlist[i].Y = y;
                }
            }
            zedGraphControl.Refresh();
        }

        private void zedGraphControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 获取颜色信息
            initBMP();
            Color color = GetColor(e.X, e.Y);
            int length = rockFormations.Count;
            for (int i = 0; i < length; i++)
            {
                if (rockFormations[i].Color.ToArgb() == color.ToArgb())
                {
                    CreateRockFormation createRockFormation = new CreateRockFormation();
                    createRockFormation.name.Text = rockFormations[i].Name;
                    createRockFormation.speed.Text = rockFormations[i].Speed;
                    createRockFormation.density.Text = rockFormations[i].Density;
                    createRockFormation.selectColor.BackColor = rockFormations[i].Color;
                    createRockFormation.Text = "修改岩层属性";
                    createRockFormation.index = i;
                    createRockFormation.DataChange += new EFS.CreateRockFormation.EventHandler(ModifyRockFormationDelegate);
                    createRockFormation.ShowDialog();
                    break;
                }

            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            CreateRockFormation createRockFormation = new CreateRockFormation();
            createRockFormation.DataChange += new EFS.CreateRockFormation.EventHandler(CreateRockFormationDelegate);
            createRockFormation.ShowDialog();
        }

        /// <summary>
        /// 修改岩层事件委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ModifyRockFormationDelegate(object sender, CreateRockFormation.DrawEventArgs args)
        {
            RockFormation rockFormation = new RockFormation(args.Name, args.Speed, args.Density, args.Color);
            rockFormations[args.Index] = rockFormation;
            GraphPane myPane = zedGraphControl.GraphPane;
            LineItem myCurve = (LineItem)myPane.CurveList[args.Index];
            myCurve.Line.Fill = new Fill(args.Color);
            CreateRockFormation createRockFormation = (CreateRockFormation)sender;
            createRockFormation.Close();
            zedGraphControl.Refresh();

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            zedGraphControl.GraphPane.CurveList.Clear();
            zedGraphControl.AxisChange();
            rockFormations.Clear();
            zedGraphControl.Refresh();
            ToolStripButton button = (ToolStripButton)sender;
            button.Enabled = false;
            Modify.Enabled = false;
            Goback.Enabled = false;
            startDraw.Enabled = false;
        }

        #region 获取指定坐标点的颜色
        private void initBMP()
        {
            bmp = new Bitmap(zedGraphControl.Width, zedGraphControl.Height);
            if (zedGraphControl.InvokeRequired)
            {
                Invoke(new EventHandler(() =>
                {
                    zedGraphControl.DrawToBitmap(bmp, zedGraphControl.ClientRectangle);
                }));
            }
            else
            {
                zedGraphControl.DrawToBitmap(bmp, zedGraphControl.ClientRectangle);
            }
        }
        public Color GetColor(int x, int y)
        {
            PointBitmap pointBitmap = new PointBitmap(bmp);
            //锁定Bitmap，通过Pixel访问颜色
            pointBitmap.LockBits();

            //获取颜色
            Color color = pointBitmap.GetPixel(x, y);

            //从内存解锁Bitmap
            pointBitmap.UnlockBits();

            return color;
        }
        #endregion

        private bool zedGraphControl_MouseDownEvent(ZedGraphControl sender, MouseEventArgs e)
        {
            // Save the mouse location
            PointF mousePt = new PointF(e.X, e.Y);
            // Find the Chart rect that contains the current mouse location
            GraphPane pane = ((ZedGraphControl)sender).MasterPane.FindChartRect(mousePt);
            if (pane != null)
            {
                // Determine if the clicked point exists
                object nearestCurve;
                int iNearest;
                bool isSelected = zedGraphControl.GraphPane.FindNearestObject(mousePt, zedGraphControl.CreateGraphics(), out nearestCurve, out iNearest);
                if (isSelected)
                {
                    TargetcurveItem = (CurveItem)nearestCurve;
                    TarfgetIndex = iNearest;
                }
            }

            return true;
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            isModify = true;
            Create.Enabled = false;
            completeDraw.Enabled = true;
            Modify.Enabled = false;
            Goback.Enabled = false;
            Clear.Enabled = false;
            zedGraphControl.Cursor = Cursors.Cross;
            zedGraphControl.Refresh();
        }

        private bool zedGraphControl_MouseUpEvent(ZedGraphControl sender, MouseEventArgs e)
        {
            TargetcurveItem = null;
            TarfgetIndex = -1;
            return true;
        }
        /// <summary>
        /// 获取指定坐标点的速度值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="z"></param>
        /// <returns>返回速度值</returns>
        private float GetV(int x, int z)
        {
            float v = 0;
            GraphPane myPane = zedGraphControl.GraphPane;
            PointF pointF = myPane.GeneralTransform(x, z, CoordType.AxisXYScale);
            PointF pointXYAxis_Min = zedGraphControl.GraphPane.GeneralTransform(myPane.XAxis.Scale.Min, myPane.YAxis.Scale.Min, CoordType.AxisXYScale);
            PointF pointXYAxis_Max = zedGraphControl.GraphPane.GeneralTransform(myPane.XAxis.Scale.Max, myPane.YAxis.Scale.Max, CoordType.AxisXYScale);
            //if ((pointF.X - pointXYAxis_Min.X) < 3 || (pointF.Y - pointXYAxis_Min.Y) < 3)
            //{
            //    pointF.X += 10;
            //    pointF.Y += 10;
            //}
            // 如果点在Y轴上
            if (pointF.X == pointXYAxis_Min.X)
            {
                pointF.X += 10;
            }
            // 如果点在X轴上
            if (pointF.Y == pointXYAxis_Min.Y)
            {
                pointF.Y += 10;
            }
            Color color = GetColor((int)pointF.X, (int)pointF.Y);
            for (int i = 0; i < rockFormations.Count; i++)
            {
                if (rockFormations[i].Color.ToArgb() == color.ToArgb())
                {
                    v = float.Parse(rockFormations[i].Speed);
                    break;
                }
                if (LineColor.ToArgb() == color.ToArgb())
                {
                    if (rockFormations[i].Color.ToArgb() == GetColor((int)pointF.X + 2, ((int)pointF.Y + 2)).ToArgb())
                    {
                        v = float.Parse(rockFormations[i].Speed);
                        break;
                    }
                }
                if (AxisColor.ToArgb() == color.ToArgb())
                {
                    if (rockFormations[i].Color.ToArgb() == GetColor((int)pointF.X + 10, ((int)pointF.Y + 10)).ToArgb())
                    {
                        v = float.Parse(rockFormations[i].Speed);
                        break;
                    }
                }
                if (backColor.ToArgb() == color.ToArgb())
                {
                    v = -1;
                }
            }
            return v;
        }
        private void CreateDigitalModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zedGraphControl.GraphPane.CurveList.Count != 0)
            {
                initBMP();
                Entrust callback = new Entrust(SaveVToFile);
                Thread thread = new Thread(GetVThread)
                {
                    IsBackground = true
                };
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start(callback);
            }
            else
            {
                MessageBox.Show("无地层！");
            }
        }
        private void GetVThread(object obj)
        {

            double Nz = zedGraphControl.GraphPane.YAxis.Scale.Max - zedGraphControl.GraphPane.YAxis.Scale.Min;
            double Nx = zedGraphControl.GraphPane.XAxis.Scale.Max - zedGraphControl.GraphPane.XAxis.Scale.Min;
            float[,] v = new float[(int)Nx, (int)Nz];
            Invoke(new EventHandler(() =>
            {
                DigitalModelProgressBar.Visible = true;
                DigitalModelProgressBar.Value = 0;
                DigitalModelProgressBar.Minimum = 0;
                DigitalModelProgressBar.Maximum = (int)Nx;
                progressTip.Visible = true;
                progressTip.Text = "正在转化为数字模型...";
                toolStrip.Enabled = false;
                menuStrip1.Enabled = false;
            }));

            for (int ix = 0; ix < Nx; ix++)
            {
                for (int iz = 0; iz < Nz; iz++)
                {
                    if (GetV(ix, iz) == -1)
                    {
                        Invoke(new EventHandler(() =>
                        {
                            DigitalModelProgressBar.Visible = false;
                            progressTip.Visible = false;
                        }));
                        MessageBox.Show("图形中存在空缺！");
                        Invoke(new EventHandler(() =>
                        {
                            DigitalModelProgressBar.Visible = false;
                            progressTip.Visible = false;
                            toolStrip.Enabled = true;
                            menuStrip1.Enabled = true;
                        }));
                        return;
                    }
                    else
                    {
                        v[ix, iz] = GetV(ix, iz);
                    }
                    Invoke(new EventHandler(() =>
                    {
                        DigitalModelProgressBar.Value = ix + 1;
                    }));
                }
            }
            Invoke(new EventHandler(() =>
            {
                DigitalModelProgressBar.Visible = false;
                progressTip.Visible = false;
                toolStrip.Enabled = true;
                menuStrip1.Enabled = true;
                ForwardCalculationToolStripMenuItem.Enabled = true;
            }));
            Entrust callback = obj as Entrust;//强转为委托
            callback(v);

        }
        //回调方法
        private void SaveVToFile(float[,] v)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "文本文件|*.txt";
            // 显示对话框
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 文件名
                string fileName = saveFileDialog.FileName;
                // 创建文件，准备写入
                FileStream fs = File.Open(fileName,
                        FileMode.Create,
                        FileAccess.Write);
                StreamWriter wr = new StreamWriter(fs);

                // 将v的内容写入到文件中

                for (int i = 0; i < v.GetLength(1); i++)
                {
                    string txt = "";
                    for (int j = 0; j < v.GetLength(0); j++)
                    {
                        txt += v[j, i] + ",";
                    }
                    wr.WriteLine(txt);
                }
                Gv = v;
                // 关闭文件
                wr.Flush();
                wr.Close();
                fs.Close();
            }
        }

        private void ForwardCalculate_CalculateSeismicProfile(object sender, SeismicProfileForm.DataChangeEventArgs args)
        {
            Thread thread = new Thread(ForwardCalculateThread_CalculateSeismicProfile)
            {
                IsBackground = true
            };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start(args);
            SeismicProfileForm forwardCalculationForm = (SeismicProfileForm)sender;
            forwardCalculationForm.Close();
        }

        private void ForwardCalculateThread_CalculateSeismicProfile(object obj)
        {
            Invoke(new EventHandler(() =>
            {
                DigitalModelProgressBar.Visible = true;
                DigitalModelProgressBar.Style = ProgressBarStyle.Marquee;
                progressTip.Visible = true;
                progressTip.Text = "正在计算...";
            }));
            double Nz = zedGraphControl.GraphPane.YAxis.Scale.Max - zedGraphControl.GraphPane.YAxis.Scale.Min;
            double Nx = zedGraphControl.GraphPane.XAxis.Scale.Max - zedGraphControl.GraphPane.XAxis.Scale.Min;
            SeismicProfileForm.DataChangeEventArgs args = obj as SeismicProfileForm.DataChangeEventArgs;
            float[,] record = new float[(int)Nx, args.Time];
            float[,] arr = Gv;
            SeismicProfile algorithm = new SeismicProfile(args.Time, (int)Nx, (int)Nz, arr, zedGraphControl.GraphPane.CurveList);
            algorithm.Calculate();
            record = algorithm.Record;

            Invoke(new EventHandler(() =>
            {
                DigitalModelProgressBar.Visible = false;
                progressTip.Visible = false;
                DigitalModelProgressBar.Style = ProgressBarStyle.Blocks;
                if (record != null)
                {
                    OpenChartForm_CalculateSeismicProfile(record);
                }
            }));

        }
        private void OpenChartForm_CalculateSeismicProfile(float[,] record)
        {
            double Nz = zedGraphControl.GraphPane.YAxis.Scale.Max - zedGraphControl.GraphPane.YAxis.Scale.Min;
            Chart chart = new Chart(record, zedGraphControl.GraphPane.CurveList, Nz);
            chart.Text = "地震剖面波形图";
            chart.Show();
        }

        private void Goback_Click(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraphControl.GraphPane;
            if (myPane.CurveList.Count == 1)
            {
                Modify.Enabled = false;
                completeDraw.Enabled = false;
                Clear.Enabled = false;
                Goback.Enabled = false;
            }
            if (myPane.CurveList.Count != 0)
            {
                LineItem myCurve = (LineItem)myPane.CurveList[myPane.CurveList.Count - 1];
                myPane.CurveList.Remove(myCurve);
                rockFormations.Remove(rockFormations[rockFormations.Count - 1]);
                zedGraphControl.AxisChange();
                zedGraphControl.Refresh();
            }

        }

        private void CalculateaSingleGunSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double Nz = zedGraphControl.GraphPane.YAxis.Scale.Max - zedGraphControl.GraphPane.YAxis.Scale.Min;
            double Nx = zedGraphControl.GraphPane.XAxis.Scale.Max - zedGraphControl.GraphPane.XAxis.Scale.Min;
            ForwardCalculationForm forwardCalculationForm = new ForwardCalculationForm(Nx / 2, 50);
            forwardCalculationForm.DataChange += new ForwardCalculationForm.EventHandler(ForwardCalculate);
            forwardCalculationForm.ShowDialog();
        }
        private void ForwardCalculate(object sender, ForwardCalculationForm.DataChangeEventArgs args)
        {
            Thread thread = new Thread(ForwardCalculateThread)
            {
                IsBackground = true
            };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start(args);
            ForwardCalculationForm forwardCalculationForm = (ForwardCalculationForm)sender;
            forwardCalculationForm.Close();
        }

        private void ForwardCalculateThread(object obj)
        {

            Invoke(new EventHandler(() =>
            {
                DigitalModelProgressBar.Visible = true;
                DigitalModelProgressBar.Style = ProgressBarStyle.Marquee;
                progressTip.Visible = true;
                progressTip.Text = "正在计算...";
            }));
            double Nz = zedGraphControl.GraphPane.YAxis.Scale.Max - zedGraphControl.GraphPane.YAxis.Scale.Min;
            double Nx = zedGraphControl.GraphPane.XAxis.Scale.Max - zedGraphControl.GraphPane.XAxis.Scale.Min;
            ForwardCalculationForm.DataChangeEventArgs args = obj as ForwardCalculationForm.DataChangeEventArgs;
            float[,] record = new float[(int)Nx, args.Time]; ;
            unsafe
            {
                float[,] arr = Gv;
                int row = arr.GetUpperBound(0) + 1;
                int col = arr.GetUpperBound(1) + 1;
                fixed (float* fp = arr)
                {
                    float*[] farr = new float*[row];
                    for (int i = 0; i < row; i++)
                    {
                        farr[i] = fp + i * col;
                    }
                    fixed (float** v = farr)
                    {
                        Algorithm algorithm = new Algorithm(args.Time, (int)Nx, (int)Nz, args.Sx, args.Sz, v);
                        algorithm.Calculate(args.File1, args.File2, args.File3);
                        for (int i = 0; i < args.Time; i++)
                        {
                            for (int j = 0; j < Nx; j++)
                            {
                                record[j, i] = algorithm.Record[j][i];
                            }
                        }

                    }
                }

            }
            Invoke(new EventHandler(() =>
            {
                DigitalModelProgressBar.Visible = false;
                progressTip.Visible = false;
                DigitalModelProgressBar.Style = ProgressBarStyle.Blocks;
                if (record != null)
                {
                    OpenChartForm(record);
                }
            }));

        }
        private void OpenChartForm(float[,] record)
        {
            Chart chart = new Chart(record);
            chart.Text = "单炮炮集波形图";
            chart.Show();
        }
        private void CalculateSeismicProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double Nz = zedGraphControl.GraphPane.YAxis.Scale.Max - zedGraphControl.GraphPane.YAxis.Scale.Min;
            double Nx = zedGraphControl.GraphPane.XAxis.Scale.Max - zedGraphControl.GraphPane.XAxis.Scale.Min;
            SeismicProfileForm forwardCalculationForm = new SeismicProfileForm(Nx / 2, 0);
            forwardCalculationForm.DataChange += new SeismicProfileForm.EventHandler(ForwardCalculate_CalculateSeismicProfile);
            forwardCalculationForm.ShowDialog();
        }

        private void TriButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double Nz = zedGraphControl.GraphPane.YAxis.Scale.Max - zedGraphControl.GraphPane.YAxis.Scale.Min;
            double Nx = zedGraphControl.GraphPane.XAxis.Scale.Max - zedGraphControl.GraphPane.XAxis.Scale.Min;
            SeismicProfileForm forwardCalculationForm = new SeismicProfileForm(Nx / 2, 0);
            forwardCalculationForm.DataChange += new SeismicProfileForm.EventHandler(TriButton_CalculateSeismicProfile);
            forwardCalculationForm.ShowDialog();
        }

        private void TriButton_CalculateSeismicProfile(object sender, SeismicProfileForm.DataChangeEventArgs args)
        {
            Thread thread = new Thread(TriButton_CalculateSeismicProfile)
            {
                IsBackground = true
            };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start(args);
            SeismicProfileForm forwardCalculationForm = (SeismicProfileForm)sender;
            forwardCalculationForm.Close();
        }

        private void TriButton_CalculateSeismicProfile(object obj)
        {
            Invoke(new EventHandler(() =>
            {
                DigitalModelProgressBar.Visible = true;
                DigitalModelProgressBar.Style = ProgressBarStyle.Marquee;
                progressTip.Visible = true;
                progressTip.Text = "正在计算...";
            }));
            double Nz = zedGraphControl.GraphPane.YAxis.Scale.Max - zedGraphControl.GraphPane.YAxis.Scale.Min;
            double Nx = zedGraphControl.GraphPane.XAxis.Scale.Max - zedGraphControl.GraphPane.XAxis.Scale.Min;
            SeismicProfileForm.DataChangeEventArgs args = obj as SeismicProfileForm.DataChangeEventArgs;
            float[,] record = new float[(int)Nx, args.Time];
            unsafe
            {
                float[,] arr = Gv;
                int row = arr.GetUpperBound(0) + 1;
                int col = arr.GetUpperBound(1) + 1;
                fixed (float* fp = arr)
                {
                    float*[] farr = new float*[row];
                    for (int i = 0; i < row; i++)
                    {
                        farr[i] = fp + i * col;
                    }
                    fixed (float** v = farr)
                    {
                        Algorithm algorithm = new Algorithm(args.Time, (int)Nx, (int)Nz, v);
                        algorithm.Calculate();
                        for (int i = 0; i < args.Time; i++)
                        {
                            for (int j = 0; j < Nx; j++)
                            {
                                record[j, i] = algorithm.Record[j][i];
                            }
                        }

                    }
                }

            }
            Invoke(new EventHandler(() =>
            {
                DigitalModelProgressBar.Visible = false;
                progressTip.Visible = false;
                DigitalModelProgressBar.Style = ProgressBarStyle.Blocks;
                if (record != null)
                {
                    TriButtonCalculateSeismicProfile(record);
                }
            }));
        }

        private void TriButtonCalculateSeismicProfile(float[,] record)
        {
            Chart chart = new Chart(record);
            chart.Text = "chart";
            chart.Show();
        }
    }
}
