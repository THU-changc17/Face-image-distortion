namespace FaceTPS
{
    partial class FaceTPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceTPS));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.S_pic = new System.Windows.Forms.Button();
            this.S_data = new System.Windows.Forms.Button();
            this.G_pic = new System.Windows.Forms.Button();
            this.G_data = new System.Windows.Forms.Button();
            this.R_pic = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.third = new System.Windows.Forms.RadioButton();
            this.linear = new System.Windows.Forms.RadioButton();
            this.near = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.align = new System.Windows.Forms.CheckBox();
            this.auto_source = new System.Windows.Forms.CheckBox();
            this.auto_guide = new System.Windows.Forms.CheckBox();
            this.sav_pic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(21, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(475, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(400, 400);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(927, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(400, 400);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // S_pic
            // 
            this.S_pic.Location = new System.Drawing.Point(166, 437);
            this.S_pic.Name = "S_pic";
            this.S_pic.Size = new System.Drawing.Size(90, 30);
            this.S_pic.TabIndex = 3;
            this.S_pic.Text = "源图片";
            this.S_pic.UseVisualStyleBackColor = true;
            this.S_pic.Click += new System.EventHandler(this.S_pic_Click);
            // 
            // S_data
            // 
            this.S_data.Location = new System.Drawing.Point(166, 490);
            this.S_data.Name = "S_data";
            this.S_data.Size = new System.Drawing.Size(90, 30);
            this.S_data.TabIndex = 4;
            this.S_data.Text = "导入数据";
            this.S_data.UseVisualStyleBackColor = true;
            this.S_data.Click += new System.EventHandler(this.S_data_Click);
            // 
            // G_pic
            // 
            this.G_pic.Location = new System.Drawing.Point(621, 437);
            this.G_pic.Name = "G_pic";
            this.G_pic.Size = new System.Drawing.Size(90, 30);
            this.G_pic.TabIndex = 5;
            this.G_pic.Text = "导向图片";
            this.G_pic.UseVisualStyleBackColor = true;
            this.G_pic.Click += new System.EventHandler(this.G_pic_Click);
            // 
            // G_data
            // 
            this.G_data.Location = new System.Drawing.Point(621, 490);
            this.G_data.Name = "G_data";
            this.G_data.Size = new System.Drawing.Size(90, 30);
            this.G_data.TabIndex = 6;
            this.G_data.Text = "导入数据";
            this.G_data.UseVisualStyleBackColor = true;
            this.G_data.Click += new System.EventHandler(this.G_data_Click);
            // 
            // R_pic
            // 
            this.R_pic.Location = new System.Drawing.Point(1137, 462);
            this.R_pic.Name = "R_pic";
            this.R_pic.Size = new System.Drawing.Size(90, 30);
            this.R_pic.TabIndex = 7;
            this.R_pic.Text = "生成图片";
            this.R_pic.UseVisualStyleBackColor = true;
            this.R_pic.Click += new System.EventHandler(this.R_pic_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.third);
            this.groupBox1.Controls.Add(this.linear);
            this.groupBox1.Controls.Add(this.near);
            this.groupBox1.Location = new System.Drawing.Point(927, 437);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 117);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "插值选择";
            // 
            // third
            // 
            this.third.AutoSize = true;
            this.third.Location = new System.Drawing.Point(44, 82);
            this.third.Name = "third";
            this.third.Size = new System.Drawing.Size(103, 19);
            this.third.TabIndex = 2;
            this.third.Text = "双三次插值";
            this.third.UseVisualStyleBackColor = true;
            // 
            // linear
            // 
            this.linear.AutoSize = true;
            this.linear.Location = new System.Drawing.Point(44, 53);
            this.linear.Name = "linear";
            this.linear.Size = new System.Drawing.Size(103, 19);
            this.linear.TabIndex = 1;
            this.linear.Text = "双线性插值";
            this.linear.UseVisualStyleBackColor = true;
            // 
            // near
            // 
            this.near.AutoSize = true;
            this.near.Checked = true;
            this.near.Location = new System.Drawing.Point(44, 24);
            this.near.Name = "near";
            this.near.Size = new System.Drawing.Size(103, 19);
            this.near.TabIndex = 0;
            this.near.TabStop = true;
            this.near.Text = "最近邻插值";
            this.near.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 539);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "未导入源图片数据";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(598, 539);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "未导入导向图片数据";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1137, 515);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(190, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // align
            // 
            this.align.AutoSize = true;
            this.align.Location = new System.Drawing.Point(1189, 437);
            this.align.Name = "align";
            this.align.Size = new System.Drawing.Size(74, 19);
            this.align.TabIndex = 12;
            this.align.Text = "预对齐";
            this.align.UseVisualStyleBackColor = true;
            // 
            // auto_source
            // 
            this.auto_source.AutoSize = true;
            this.auto_source.Location = new System.Drawing.Point(293, 497);
            this.auto_source.Name = "auto_source";
            this.auto_source.Size = new System.Drawing.Size(89, 19);
            this.auto_source.TabIndex = 13;
            this.auto_source.Text = "自动检测";
            this.auto_source.UseVisualStyleBackColor = true;
            // 
            // auto_guide
            // 
            this.auto_guide.AutoSize = true;
            this.auto_guide.Location = new System.Drawing.Point(746, 497);
            this.auto_guide.Name = "auto_guide";
            this.auto_guide.Size = new System.Drawing.Size(89, 19);
            this.auto_guide.TabIndex = 14;
            this.auto_guide.Text = "自动检测";
            this.auto_guide.UseVisualStyleBackColor = true;
            // 
            // sav_pic
            // 
            this.sav_pic.Location = new System.Drawing.Point(1237, 462);
            this.sav_pic.Name = "sav_pic";
            this.sav_pic.Size = new System.Drawing.Size(90, 30);
            this.sav_pic.TabIndex = 15;
            this.sav_pic.Text = "保存图片";
            this.sav_pic.UseVisualStyleBackColor = true;
            this.sav_pic.Click += new System.EventHandler(this.sav_pic_Click);
            // 
            // FaceTPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1353, 570);
            this.Controls.Add(this.sav_pic);
            this.Controls.Add(this.auto_guide);
            this.Controls.Add(this.auto_source);
            this.Controls.Add(this.align);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.R_pic);
            this.Controls.Add(this.G_data);
            this.Controls.Add(this.G_pic);
            this.Controls.Add(this.S_data);
            this.Controls.Add(this.S_pic);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FaceTPS";
            this.Text = "FaceTPS";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button S_pic;
        private System.Windows.Forms.Button S_data;
        private System.Windows.Forms.Button G_pic;
        private System.Windows.Forms.Button G_data;
        private System.Windows.Forms.Button R_pic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton third;
        private System.Windows.Forms.RadioButton linear;
        private System.Windows.Forms.RadioButton near;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox align;
        private System.Windows.Forms.CheckBox auto_source;
        private System.Windows.Forms.CheckBox auto_guide;
        private System.Windows.Forms.Button sav_pic;
    }
}

