namespace EFS
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模型编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制模型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateDigitalModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ForwardCalculationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CalculateaSingleGunSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CalculateSeismicProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TriButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输入输出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.画笔设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.Create = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.startDraw = new System.Windows.Forms.ToolStripButton();
            this.Modify = new System.Windows.Forms.ToolStripButton();
            this.completeDraw = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Goback = new System.Windows.Forms.ToolStripButton();
            this.Clear = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.coordinateX = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.coordinateY = new System.Windows.Forms.ToolStripLabel();
            this.progressTip = new System.Windows.Forms.ToolStripLabel();
            this.DigitalModelProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.menuStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工程ToolStripMenuItem,
            this.模型编辑ToolStripMenuItem,
            this.ForwardCalculationToolStripMenuItem,
            this.输入输出ToolStripMenuItem,
            this.画笔设置ToolStripMenuItem,
            this.查看ToolStripMenuItem,
            this.设计ToolStripMenuItem,
            this.计算ToolStripMenuItem,
            this.窗口ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1223, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 工程ToolStripMenuItem
            // 
            this.工程ToolStripMenuItem.Name = "工程ToolStripMenuItem";
            this.工程ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工程ToolStripMenuItem.Text = "工程";
            // 
            // 模型编辑ToolStripMenuItem
            // 
            this.模型编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制模型ToolStripMenuItem,
            this.CreateDigitalModelToolStripMenuItem});
            this.模型编辑ToolStripMenuItem.Name = "模型编辑ToolStripMenuItem";
            this.模型编辑ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.模型编辑ToolStripMenuItem.Text = "模型编辑";
            // 
            // 绘制模型ToolStripMenuItem
            // 
            this.绘制模型ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridProperty});
            this.绘制模型ToolStripMenuItem.Name = "绘制模型ToolStripMenuItem";
            this.绘制模型ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.绘制模型ToolStripMenuItem.Text = "绘制模型";
            // 
            // gridProperty
            // 
            this.gridProperty.Name = "gridProperty";
            this.gridProperty.Size = new System.Drawing.Size(124, 22);
            this.gridProperty.Text = "网格属性";
            this.gridProperty.Click += new System.EventHandler(this.gridProperty_Click);
            // 
            // CreateDigitalModelToolStripMenuItem
            // 
            this.CreateDigitalModelToolStripMenuItem.Name = "CreateDigitalModelToolStripMenuItem";
            this.CreateDigitalModelToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.CreateDigitalModelToolStripMenuItem.Text = "转化为数字模型";
            this.CreateDigitalModelToolStripMenuItem.Click += new System.EventHandler(this.CreateDigitalModelToolStripMenuItem_Click);
            // 
            // ForwardCalculationToolStripMenuItem
            // 
            this.ForwardCalculationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CalculateaSingleGunSetToolStripMenuItem,
            this.CalculateSeismicProfileToolStripMenuItem,
            this.TriButtonToolStripMenuItem});
            this.ForwardCalculationToolStripMenuItem.Enabled = false;
            this.ForwardCalculationToolStripMenuItem.Name = "ForwardCalculationToolStripMenuItem";
            this.ForwardCalculationToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.ForwardCalculationToolStripMenuItem.Text = "正演计算";
            // 
            // CalculateaSingleGunSetToolStripMenuItem
            // 
            this.CalculateaSingleGunSetToolStripMenuItem.Name = "CalculateaSingleGunSetToolStripMenuItem";
            this.CalculateaSingleGunSetToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CalculateaSingleGunSetToolStripMenuItem.Text = "计算单炮炮集";
            this.CalculateaSingleGunSetToolStripMenuItem.Click += new System.EventHandler(this.CalculateaSingleGunSetToolStripMenuItem_Click);
            // 
            // CalculateSeismicProfileToolStripMenuItem
            // 
            this.CalculateSeismicProfileToolStripMenuItem.Name = "CalculateSeismicProfileToolStripMenuItem";
            this.CalculateSeismicProfileToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CalculateSeismicProfileToolStripMenuItem.Text = "地震剖面图";
            this.CalculateSeismicProfileToolStripMenuItem.Click += new System.EventHandler(this.CalculateSeismicProfileToolStripMenuItem_Click);
            // 
            // TriButtonToolStripMenuItem
            // 
            this.TriButtonToolStripMenuItem.Name = "TriButtonToolStripMenuItem";
            this.TriButtonToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.TriButtonToolStripMenuItem.Text = "起个名字";
            this.TriButtonToolStripMenuItem.Click += new System.EventHandler(this.TriButtonToolStripMenuItem_Click);
            // 
            // 输入输出ToolStripMenuItem
            // 
            this.输入输出ToolStripMenuItem.Name = "输入输出ToolStripMenuItem";
            this.输入输出ToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.输入输出ToolStripMenuItem.Text = "输入/输出";
            // 
            // 画笔设置ToolStripMenuItem
            // 
            this.画笔设置ToolStripMenuItem.Name = "画笔设置ToolStripMenuItem";
            this.画笔设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.画笔设置ToolStripMenuItem.Text = "画笔设置";
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查看ToolStripMenuItem.Text = "查看";
            // 
            // 设计ToolStripMenuItem
            // 
            this.设计ToolStripMenuItem.Name = "设计ToolStripMenuItem";
            this.设计ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设计ToolStripMenuItem.Text = "工具";
            // 
            // 计算ToolStripMenuItem
            // 
            this.计算ToolStripMenuItem.Name = "计算ToolStripMenuItem";
            this.计算ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.计算ToolStripMenuItem.Text = "计算";
            // 
            // 窗口ToolStripMenuItem
            // 
            this.窗口ToolStripMenuItem.Name = "窗口ToolStripMenuItem";
            this.窗口ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.窗口ToolStripMenuItem.Text = "窗口";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // toolStrip
            // 
            this.toolStrip.Enabled = false;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Create,
            this.toolStripSeparator3,
            this.startDraw,
            this.Modify,
            this.completeDraw,
            this.toolStripSeparator4,
            this.Goback,
            this.Clear});
            this.toolStrip.Location = new System.Drawing.Point(0, 25);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1223, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // Create
            // 
            this.Create.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Create.Image = global::EFS.Properties.Resources.新建;
            this.Create.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(23, 22);
            this.Create.Text = "新建岩层";
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // startDraw
            // 
            this.startDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startDraw.Enabled = false;
            this.startDraw.Image = global::EFS.Properties.Resources.工程绘图;
            this.startDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startDraw.Name = "startDraw";
            this.startDraw.Size = new System.Drawing.Size(23, 22);
            this.startDraw.Text = "开始绘图";
            this.startDraw.ToolTipText = "开始绘图";
            this.startDraw.Click += new System.EventHandler(this.startDraw_Click);
            // 
            // Modify
            // 
            this.Modify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Modify.Enabled = false;
            this.Modify.Image = global::EFS.Properties.Resources.修改;
            this.Modify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Modify.Name = "Modify";
            this.Modify.Size = new System.Drawing.Size(23, 22);
            this.Modify.Text = "修改";
            this.Modify.Click += new System.EventHandler(this.Modify_Click);
            // 
            // completeDraw
            // 
            this.completeDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.completeDraw.Enabled = false;
            this.completeDraw.Image = global::EFS.Properties.Resources.结束;
            this.completeDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.completeDraw.Name = "completeDraw";
            this.completeDraw.Size = new System.Drawing.Size(23, 22);
            this.completeDraw.Text = "结束绘图";
            this.completeDraw.Click += new System.EventHandler(this.completeDraw_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // Goback
            // 
            this.Goback.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Goback.Enabled = false;
            this.Goback.Image = global::EFS.Properties.Resources.撤销;
            this.Goback.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Goback.Name = "Goback";
            this.Goback.Size = new System.Drawing.Size(23, 22);
            this.Goback.Text = "回退";
            this.Goback.Click += new System.EventHandler(this.Goback_Click);
            // 
            // Clear
            // 
            this.Clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Clear.Enabled = false;
            this.Clear.Image = global::EFS.Properties.Resources.清除;
            this.Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(23, 22);
            this.Clear.Text = "清除";
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.coordinateX,
            this.toolStripLabel3,
            this.toolStripLabel4,
            this.coordinateY,
            this.progressTip,
            this.DigitalModelProgressBar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 649);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1223, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel1.Text = "坐标";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(16, 22);
            this.toolStripLabel2.Text = "X";
            // 
            // coordinateX
            // 
            this.coordinateX.Name = "coordinateX";
            this.coordinateX.Size = new System.Drawing.Size(28, 22);
            this.coordinateX.Text = "null";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(11, 22);
            this.toolStripLabel3.Text = ",";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(15, 22);
            this.toolStripLabel4.Text = "Y";
            // 
            // coordinateY
            // 
            this.coordinateY.Name = "coordinateY";
            this.coordinateY.Size = new System.Drawing.Size(28, 22);
            this.coordinateY.Text = "null";
            // 
            // progressTip
            // 
            this.progressTip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressTip.Name = "progressTip";
            this.progressTip.Size = new System.Drawing.Size(28, 22);
            this.progressTip.Text = "null";
            this.progressTip.Visible = false;
            // 
            // DigitalModelProgressBar
            // 
            this.DigitalModelProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DigitalModelProgressBar.Name = "DigitalModelProgressBar";
            this.DigitalModelProgressBar.Size = new System.Drawing.Size(100, 22);
            this.DigitalModelProgressBar.Visible = false;
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.zedGraphControl.IsEnableHPan = false;
            this.zedGraphControl.IsEnableHZoom = false;
            this.zedGraphControl.IsEnableVPan = false;
            this.zedGraphControl.IsEnableVZoom = false;
            this.zedGraphControl.Location = new System.Drawing.Point(0, 53);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(1223, 593);
            this.zedGraphControl.TabIndex = 0;
            this.zedGraphControl.MouseDownEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.zedGraphControl_MouseDownEvent);
            this.zedGraphControl.MouseUpEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.zedGraphControl_MouseUpEvent);
            this.zedGraphControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zedGraphControl_MouseClick);
            this.zedGraphControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.zedGraphControl_MouseDoubleClick);
            this.zedGraphControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.zedGraphControl_MouseMove);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 674);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.zedGraphControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P_R-人机交互地震正演系统1.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem 模型编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ForwardCalculationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输入输出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 画笔设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton completeDraw;
        private System.Windows.Forms.ToolStripButton Clear;
        private System.Windows.Forms.ToolStripMenuItem 绘制模型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridProperty;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel coordinateX;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel coordinateY;
        private System.Windows.Forms.ToolStripButton startDraw;
        private System.Windows.Forms.ToolStripButton Create;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton Modify;
        private System.Windows.Forms.ToolStripMenuItem CreateDigitalModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar DigitalModelProgressBar;
        private System.Windows.Forms.ToolStripLabel progressTip;
        private System.Windows.Forms.ToolStripButton Goback;
        private System.Windows.Forms.ToolStripMenuItem CalculateaSingleGunSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CalculateSeismicProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TriButtonToolStripMenuItem;
    }
}

