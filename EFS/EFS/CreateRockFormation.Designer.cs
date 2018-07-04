namespace EFS
{
    partial class CreateRockFormation
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
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.speed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.density = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.selectColor = new System.Windows.Forms.Button();
            this.sure = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(117, 28);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(154, 21);
            this.name.TabIndex = 1;
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(117, 67);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(154, 21);
            this.speed.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "速度";
            // 
            // density
            // 
            this.density.Location = new System.Drawing.Point(117, 106);
            this.density.Name = "density";
            this.density.Size = new System.Drawing.Size(154, 21);
            this.density.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "密度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "颜色";
            // 
            // selectColor
            // 
            this.selectColor.Location = new System.Drawing.Point(117, 144);
            this.selectColor.Name = "selectColor";
            this.selectColor.Size = new System.Drawing.Size(75, 23);
            this.selectColor.TabIndex = 7;
            this.selectColor.Text = "...";
            this.selectColor.UseVisualStyleBackColor = true;
            this.selectColor.Click += new System.EventHandler(this.selectColor_Click);
            // 
            // sure
            // 
            this.sure.Location = new System.Drawing.Point(72, 196);
            this.sure.Name = "sure";
            this.sure.Size = new System.Drawing.Size(75, 23);
            this.sure.TabIndex = 8;
            this.sure.Text = "确定";
            this.sure.UseVisualStyleBackColor = true;
            this.sure.Click += new System.EventHandler(this.sure_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(196, 196);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 9;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // CreateRockFormation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 231);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.sure);
            this.Controls.Add(this.selectColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.density);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Name = "CreateRockFormation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "岩层属性";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox name;
        public System.Windows.Forms.TextBox speed;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox density;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button selectColor;
        private System.Windows.Forms.Button sure;
        private System.Windows.Forms.Button cancel;
    }
}