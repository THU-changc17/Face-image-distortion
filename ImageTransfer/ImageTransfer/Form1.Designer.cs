namespace ImageTransfer
{
    partial class ImageTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageTransfer));
            this.Input = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.nearbox = new System.Windows.Forms.CheckBox();
            this.outpic = new System.Windows.Forms.Button();
            this.linearbox = new System.Windows.Forms.CheckBox();
            this.thirdbox = new System.Windows.Forms.CheckBox();
            this.R_choose = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.R_show = new System.Windows.Forms.Label();
            this.angle_choose = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.angle_show = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rotate = new System.Windows.Forms.CheckBox();
            this.distortion = new System.Windows.Forms.CheckBox();
            this.DR_choose = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.times_show = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.save_pic = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CCW = new System.Windows.Forms.RadioButton();
            this.CW = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.inR = new System.Windows.Forms.RadioButton();
            this.outR = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_choose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angle_choose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DR_choose)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(202, 30);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(89, 30);
            this.Input.TabIndex = 0;
            this.Input.Text = "导入图片";
            this.Input.UseVisualStyleBackColor = true;
            this.Input.Click += new System.EventHandler(this.Input_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(50, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1098, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(512, 512);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // nearbox
            // 
            this.nearbox.AutoSize = true;
            this.nearbox.Location = new System.Drawing.Point(17, 37);
            this.nearbox.Name = "nearbox";
            this.nearbox.Size = new System.Drawing.Size(104, 19);
            this.nearbox.TabIndex = 13;
            this.nearbox.Text = "最近邻插值";
            this.nearbox.UseVisualStyleBackColor = true;
            // 
            // outpic
            // 
            this.outpic.Location = new System.Drawing.Point(201, 71);
            this.outpic.Name = "outpic";
            this.outpic.Size = new System.Drawing.Size(90, 30);
            this.outpic.TabIndex = 14;
            this.outpic.Text = "输出图片";
            this.outpic.UseVisualStyleBackColor = true;
            this.outpic.Click += new System.EventHandler(this.outpic_Click);
            // 
            // linearbox
            // 
            this.linearbox.AutoSize = true;
            this.linearbox.Location = new System.Drawing.Point(17, 78);
            this.linearbox.Name = "linearbox";
            this.linearbox.Size = new System.Drawing.Size(104, 19);
            this.linearbox.TabIndex = 15;
            this.linearbox.Text = "双线性插值";
            this.linearbox.UseVisualStyleBackColor = true;
            // 
            // thirdbox
            // 
            this.thirdbox.AutoSize = true;
            this.thirdbox.Location = new System.Drawing.Point(17, 120);
            this.thirdbox.Name = "thirdbox";
            this.thirdbox.Size = new System.Drawing.Size(104, 19);
            this.thirdbox.TabIndex = 16;
            this.thirdbox.Text = "双三次插值";
            this.thirdbox.UseVisualStyleBackColor = true;
            // 
            // R_choose
            // 
            this.R_choose.Location = new System.Drawing.Point(7, 90);
            this.R_choose.Maximum = 1000;
            this.R_choose.Name = "R_choose";
            this.R_choose.Size = new System.Drawing.Size(300, 56);
            this.R_choose.TabIndex = 17;
            this.R_choose.Scroll += new System.EventHandler(this.R_choose_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "0%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "100%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "旋转半径";
            // 
            // R_show
            // 
            this.R_show.AutoSize = true;
            this.R_show.Location = new System.Drawing.Point(317, 100);
            this.R_show.Name = "R_show";
            this.R_show.Size = new System.Drawing.Size(37, 15);
            this.R_show.TabIndex = 21;
            this.R_show.Text = "比例";
            // 
            // angle_choose
            // 
            this.angle_choose.Location = new System.Drawing.Point(7, 195);
            this.angle_choose.Maximum = 3600;
            this.angle_choose.Name = "angle_choose";
            this.angle_choose.Size = new System.Drawing.Size(300, 56);
            this.angle_choose.TabIndex = 22;
            this.angle_choose.Scroll += new System.EventHandler(this.angle_choose_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "旋转角度";
            // 
            // angle_show
            // 
            this.angle_show.AutoSize = true;
            this.angle_show.Location = new System.Drawing.Point(317, 205);
            this.angle_show.Name = "angle_show";
            this.angle_show.Size = new System.Drawing.Size(37, 15);
            this.angle_show.TabIndex = 24;
            this.angle_show.Text = "角度";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "0°";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(277, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 26;
            this.label8.Text = "360°";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(53, 46);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(226, 23);
            this.progressBar1.TabIndex = 29;
            // 
            // rotate
            // 
            this.rotate.AutoSize = true;
            this.rotate.Location = new System.Drawing.Point(7, 25);
            this.rotate.Name = "rotate";
            this.rotate.Size = new System.Drawing.Size(89, 19);
            this.rotate.TabIndex = 30;
            this.rotate.Text = "旋转扭曲";
            this.rotate.UseVisualStyleBackColor = true;
            // 
            // distortion
            // 
            this.distortion.AutoSize = true;
            this.distortion.Location = new System.Drawing.Point(6, 36);
            this.distortion.Name = "distortion";
            this.distortion.Size = new System.Drawing.Size(89, 19);
            this.distortion.TabIndex = 31;
            this.distortion.Text = "图像畸变";
            this.distortion.UseVisualStyleBackColor = true;
            // 
            // DR_choose
            // 
            this.DR_choose.Location = new System.Drawing.Point(6, 103);
            this.DR_choose.Maximum = 50;
            this.DR_choose.Name = "DR_choose";
            this.DR_choose.Size = new System.Drawing.Size(300, 56);
            this.DR_choose.TabIndex = 32;
            this.DR_choose.Scroll += new System.EventHandler(this.DR_choose_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "畸变半径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = "5";
            // 
            // times_show
            // 
            this.times_show.AutoSize = true;
            this.times_show.Location = new System.Drawing.Point(316, 113);
            this.times_show.Name = "times_show";
            this.times_show.Size = new System.Drawing.Size(37, 15);
            this.times_show.TabIndex = 36;
            this.times_show.Text = "倍数";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.save_pic);
            this.groupBox2.Controls.Add(this.nearbox);
            this.groupBox2.Controls.Add(this.linearbox);
            this.groupBox2.Controls.Add(this.thirdbox);
            this.groupBox2.Controls.Add(this.Input);
            this.groupBox2.Controls.Add(this.outpic);
            this.groupBox2.Location = new System.Drawing.Point(645, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 160);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "插值方式";
            // 
            // save_pic
            // 
            this.save_pic.Location = new System.Drawing.Point(201, 113);
            this.save_pic.Name = "save_pic";
            this.save_pic.Size = new System.Drawing.Size(90, 30);
            this.save_pic.TabIndex = 41;
            this.save_pic.Text = "保存图片";
            this.save_pic.UseVisualStyleBackColor = true;
            this.save_pic.Click += new System.EventHandler(this.save_pic_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CCW);
            this.groupBox3.Controls.Add(this.CW);
            this.groupBox3.Controls.Add(this.R_choose);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.R_show);
            this.groupBox3.Controls.Add(this.angle_choose);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.angle_show);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.rotate);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(645, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 258);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "旋转扭曲";
            // 
            // CCW
            // 
            this.CCW.AutoSize = true;
            this.CCW.Location = new System.Drawing.Point(232, 25);
            this.CCW.Name = "CCW";
            this.CCW.Size = new System.Drawing.Size(73, 19);
            this.CCW.TabIndex = 32;
            this.CCW.TabStop = true;
            this.CCW.Text = "逆时针";
            this.CCW.UseVisualStyleBackColor = true;
            // 
            // CW
            // 
            this.CW.AutoSize = true;
            this.CW.Checked = true;
            this.CW.Location = new System.Drawing.Point(130, 25);
            this.CW.Name = "CW";
            this.CW.Size = new System.Drawing.Size(73, 19);
            this.CW.TabIndex = 31;
            this.CW.TabStop = true;
            this.CW.Text = "顺时针";
            this.CW.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.inR);
            this.groupBox4.Controls.Add(this.outR);
            this.groupBox4.Controls.Add(this.distortion);
            this.groupBox4.Controls.Add(this.DR_choose);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.times_show);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(645, 466);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(370, 168);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "图像畸变";
            // 
            // inR
            // 
            this.inR.AutoSize = true;
            this.inR.Location = new System.Drawing.Point(232, 36);
            this.inR.Name = "inR";
            this.inR.Size = new System.Drawing.Size(58, 19);
            this.inR.TabIndex = 43;
            this.inR.TabStop = true;
            this.inR.Text = "向内";
            this.inR.UseVisualStyleBackColor = true;
            // 
            // outR
            // 
            this.outR.AutoSize = true;
            this.outR.Checked = true;
            this.outR.Location = new System.Drawing.Point(130, 35);
            this.outR.Name = "outR";
            this.outR.Size = new System.Drawing.Size(58, 19);
            this.outR.TabIndex = 42;
            this.outR.TabStop = true;
            this.outR.Text = "向外";
            this.outR.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.progressBar1);
            this.groupBox5.Location = new System.Drawing.Point(645, 653);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(370, 100);
            this.groupBox5.TabIndex = 41;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "进度条";
            // 
            // ImageTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1664, 774);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageTransfer";
            this.Text = "ImageTransfer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_choose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angle_choose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DR_choose)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Input;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox nearbox;
        private System.Windows.Forms.Button outpic;
        private System.Windows.Forms.CheckBox linearbox;
        private System.Windows.Forms.CheckBox thirdbox;
        private System.Windows.Forms.TrackBar R_choose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label R_show;
        private System.Windows.Forms.TrackBar angle_choose;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label angle_show;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox rotate;
        private System.Windows.Forms.CheckBox distortion;
        private System.Windows.Forms.TrackBar DR_choose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label times_show;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button save_pic;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton CCW;
        private System.Windows.Forms.RadioButton CW;
        private System.Windows.Forms.RadioButton inR;
        private System.Windows.Forms.RadioButton outR;
    }
}

