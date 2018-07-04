namespace EFS
{
    partial class Chart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RecordZedGraphControl = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // RecordZedGraphControl
            // 
            this.RecordZedGraphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RecordZedGraphControl.Location = new System.Drawing.Point(12, 12);
            this.RecordZedGraphControl.Name = "RecordZedGraphControl";
            this.RecordZedGraphControl.ScrollGrace = 0D;
            this.RecordZedGraphControl.ScrollMaxX = 0D;
            this.RecordZedGraphControl.ScrollMaxY = 0D;
            this.RecordZedGraphControl.ScrollMaxY2 = 0D;
            this.RecordZedGraphControl.ScrollMinX = 0D;
            this.RecordZedGraphControl.ScrollMinY = 0D;
            this.RecordZedGraphControl.ScrollMinY2 = 0D;
            this.RecordZedGraphControl.Size = new System.Drawing.Size(776, 426);
            this.RecordZedGraphControl.TabIndex = 0;
            this.RecordZedGraphControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RecordZedGraphControl_MouseDoubleClick);
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RecordZedGraphControl);
            this.Name = "Chart";
            this.Text = "Chart";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl RecordZedGraphControl;
    }
}