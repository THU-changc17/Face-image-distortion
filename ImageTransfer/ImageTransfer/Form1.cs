using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTransfer
{
    public partial class ImageTransfer : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        public static extern void FreeConsole();
        //开启控制台依赖操作
        public Bitmap myBitmap;
        private int height;  //图像宽
        private int width;  //图像高
        public int[,,] pix;
        public ImageTransfer()
        {
            InitializeComponent();
            //AllocConsole();   //开启控制台
            this.progressBar1.Value = 0;
        }
        private void Input_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "JPG图像(*.jpg)|*.jpg|BMP图像(*.bmp)|*.bmp|所有文件(*.*)|*.*";
            of.FilterIndex = 0;
            of.ShowDialog();
            String filename = of.FileName.ToString();
            this.myBitmap = new Bitmap(filename);
            pictureBox1.Image = (Image)this.myBitmap;
            height = this.myBitmap.Height;
            width = this.myBitmap.Width;
            int[,,] RGB = new int[width, height, 3];
            pix = RGB;
            //获取图像像素点像素值
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    pix[i, j, 0] = this.myBitmap.GetPixel(i, j).R;
                    pix[i, j, 1] = this.myBitmap.GetPixel(i, j).G;
                    pix[i, j, 2] = this.myBitmap.GetPixel(i, j).B;
                }
            }
        }
        private double[] rotate_search_point(int new_x,int new_y)
        {
            double angle;
            double distance, Radius, a_max;
            double old_x, old_y;
            Radius = this.R_choose.Value*Math.Min((width - 1)/2 , (height - 1)/2) / 1000.0;  //选择Radius
            a_max = this.angle_choose.Value*Math.PI / 1800.0;  //选择最大旋转角度
            distance = Math.Sqrt((new_x - (width - 1) / 2) * (new_x - (width - 1) / 2)
                + (new_y - (height - 1) / 2) * (new_y - (height - 1) / 2));  
            if(distance<=Radius)
            {
                angle = a_max * (Radius - distance) / Radius;   
                //旋转坐标变换
                old_x = (new_x - (width - 1) / 2) * Math.Cos(angle) - ((height - 1) / 2 - new_y) * Math.Sin(angle);
                old_y = (new_x - (width - 1) / 2) * Math.Sin(angle) + ((height - 1) / 2 - new_y) * Math.Cos(angle);
                //逆时针旋转
                if (CCW.Checked == true)
                {
                    old_x = (new_x - (width - 1) / 2) * Math.Cos(angle) + ((height - 1) / 2 - new_y) * Math.Sin(angle);
                    old_y = -(new_x - (width - 1) / 2) * Math.Sin(angle) + ((height - 1) / 2 - new_y) * Math.Cos(angle);
                }
            }
            else
            {
                //半径之外的点不变
                old_x = (double)new_x - ((width - 1) / 2);
                old_y = ((height - 1) / 2) - (double)new_y;
            }
            double[] old_point = { old_x, old_y };
            return old_point;
        }
        private double[] distortion_search_point(int new_x,int new_y)
        {
            double old_x, old_y;
            double max_d, distance, Radius;
            distance = Math.Sqrt((new_x - (width - 1) / 2) * (new_x - (width - 1) / 2)
                + (new_y - (height - 1) / 2) * (new_y - (height - 1) / 2));
            max_d = Math.Sqrt(((width - 1) / 2) * ((width - 1) / 2)
                + ((height - 1) / 2) * ((height - 1) / 2));
            Radius = (this.DR_choose.Value) * max_d / 10.0;
            //图像畸变变换
            old_x = (Radius / distance) * Math.Asin(distance / Radius) * (new_x - (width - 1) / 2);
            old_y = (Radius / distance) * Math.Asin(distance / Radius) * ((height - 1) / 2 - new_y);
            //球心在内侧
            if(inR.Checked == true)
            {
                old_x = (new_x - (width - 1) / 2) / ((Radius / distance) * Math.Asin(distance / Radius));
                old_y = ((height - 1) / 2 - new_y) / ((Radius / distance) * Math.Asin(distance / Radius));
            }
            double[] old_point = { old_x, old_y };
            return old_point;
        }
        //显示选择的半径、角度、倍数值
        private void R_choose_Scroll(object sender, EventArgs e)
        {
            this.R_show.Text = (this.R_choose.Value / 10.0).ToString();
        }

        private void angle_choose_Scroll(object sender, EventArgs e)
        {
            this.angle_show.Text = (this.angle_choose.Value / 10.0).ToString();
        }
        private void DR_choose_Scroll(object sender, EventArgs e)
        {
            this.times_show.Text = (this.DR_choose.Value / 10.0).ToString();
        }
        //最近邻插值
        private Color nearest(double x,double y)
        {
            int[] old_point = new int[2];
            if (x - Math.Floor(x) >= 0.5)
                old_point[0] = (int)(Math.Ceiling(x));
            else
                old_point[0] = (int)Math.Floor(x);
            if (old_point[1] - Math.Floor(y) >= 0.5)
                old_point[1] = (int)Math.Ceiling(y);
            else
                old_point[1] = (int)Math.Floor(y);
            return Color.FromArgb(pix[old_point[0], old_point[1], 0],
                            pix[old_point[0], old_point[1], 1],
                            pix[old_point[0], old_point[1], 2]);
        }
        //双线性插值
        private Color Bilinear(double x, double y)
        {
            double u, v;
            int m, n;
            u = x- (int)Math.Floor(x);
            v = y - (int)Math.Floor(y);
            m = (int)Math.Floor(x);
            n = (int)Math.Floor(y);
            if (m < width - 1 && n < height - 1)
                return Color.FromArgb(
                           (int)((1 - u) * (1 - v) * pix[m, n, 0] + (1 - u) * v * pix[m, n + 1, 0] + u * (1 - v) * pix[m + 1, n, 0] + u * v * pix[m + 1, n + 1, 0]),
                           (int)((1 - u) * (1 - v) * pix[m, n, 1] + (1 - u) * v * pix[m, n + 1, 1] + u * (1 - v) * pix[m + 1, n, 1] + u * v * pix[m + 1, n + 1, 1]),
                           (int)((1 - u) * (1 - v) * pix[m, n, 2] + (1 - u) * v * pix[m, n + 1, 2] + u * (1 - v) * pix[m + 1, n, 2] + u * v * pix[m + 1, n + 1, 2]));
            else
                return Color.FromArgb(pix[m, n, 0], pix[m, n, 1], pix[m, n, 2]);

        }
        //双三次插值
        private Color Bicubic(double x, double y)
        {
            double u, v;
            int m, n;
            double[,,] B = new double[4, 4, 3];
            double[] A = new double[4];
            double[] C = new double[4];
            double[,] temp = new double[4, 3];
            int xpos = 0;
            int ypos = 0;
            u = x - (int)Math.Floor(x);
            v = y - (int)Math.Floor(y);
            m = (int)Math.Floor(x);
            n = (int)Math.Floor(y);
            if (m > 0 && n > 0 && m < (width - 2) && n < (height - 2))
            {
                for (int k = m - 1; k < m + 3; k++)
                {
                    for (int t = n - 1; t < n + 3; t++)
                    {
                        B[xpos, ypos, 0] = pix[k, t, 0];
                        B[xpos, ypos, 1] = pix[k, t, 1];
                        B[xpos, ypos, 2] = pix[k, t, 2];
                        ypos++;
                    }
                    ypos = 0;
                    xpos++;
                }
                xpos = 0;
                for (int k = 1; k > -3; k--)
                {
                    A[xpos] = get_S(u + k);
                    C[xpos] = get_S(v + k);
                    xpos++;
                }
                xpos = 0;
                for (int k = 0; k < 4; k++)
                {
                    double[] sum = new double[3] { 0, 0, 0 };
                    for (int t = 0; t < 4; t++)
                    {
                        sum[0] = sum[0] + C[t] * B[k, t, 0];
                        sum[1] = sum[1] + C[t] * B[k, t, 1];
                        sum[2] = sum[2] + C[t] * B[k, t, 2];
                    }
                    temp[k, 0] = sum[0];
                    temp[k, 1] = sum[1];
                    temp[k, 2] = sum[2];
                }
                double[] final = new double[3] { 0, 0, 0 };
                for (int k = 0; k < 4; k++)
                {
                    final[0] = final[0] + A[k] * temp[k, 0];
                    final[1] = final[1] + A[k] * temp[k, 1];
                    final[2] = final[2] + A[k] * temp[k, 2];
                }
                final[0] = (final[0] <= 255.0) ? final[0] : 255;
                final[0] = (final[0] >= 0.0) ? final[0] : 0;
                final[1] = (final[1] <= 255.0) ? final[1] : 255;
                final[1] = (final[1] >= 0.0) ? final[1] : 0;
                final[2] = (final[2] <= 255.0) ? final[2] : 255;
                final[2] = (final[2] >= 0.0) ? final[2] : 0;
                return Color.FromArgb((int)final[0], (int)final[1], (int)final[2]);
            }
            else
                return Color.FromArgb(pix[m, n, 0], pix[m, n, 1], pix[m, n, 2]);
        }
        //计算S值
        private double get_S(double x)
        {
            double s;
            if (Math.Abs(x) <= 1)
                s = 1 - 2 * Math.Abs(x) * Math.Abs(x) + Math.Abs(x) * Math.Abs(x) * Math.Abs(x);
            else if (Math.Abs(x) > 1 && Math.Abs(x) < 2)
                s = 4 - 8 * Math.Abs(x) + 5 * Math.Abs(x) * Math.Abs(x) - Math.Abs(x) * Math.Abs(x) * Math.Abs(x);
            else
                s = 0;
            return s;
        }
        private void outpic_Click(object sender, EventArgs e)
        {
            double[] double_old_point = new double[2];
            int[] old_point = new int[2];
            Bitmap new_bitmap = (Bitmap)myBitmap.Clone();
            progressBar1.Value = 0;
            progressBar1.Maximum = width * height;
            if (this.nearbox.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (this.rotate.CheckState == CheckState.Checked)
                        {
                            double_old_point[0] = rotate_search_point(i, j)[0] + ((width - 1) / 2);
                            double_old_point[1] = ((height - 1) / 2) - rotate_search_point(i, j)[1];
                            new_bitmap.SetPixel(i, j, nearest(double_old_point[0], double_old_point[1]));
                        }
                        else if (this.distortion.CheckState == CheckState.Checked)
                        {
                            double_old_point[0] = distortion_search_point(i, j)[0] + ((width - 1) / 2);
                            double_old_point[1] = ((height - 1) / 2) - distortion_search_point(i, j)[1];
                            //像素点越界置零
                            if (double_old_point[0] >= 0 && double_old_point[1] >= 0 && double_old_point[0] <= width - 1 && double_old_point[1] <= height - 1)
                                new_bitmap.SetPixel(i, j, nearest(double_old_point[0], double_old_point[1]));
                            else
                                new_bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        }
                        progressBar1.Value += 1;
                    }
                }
                pictureBox2.Image = (Image)new_bitmap;
            }
            else if (this.linearbox.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (this.rotate.CheckState == CheckState.Checked)
                        {
                            double_old_point[0] = rotate_search_point(i, j)[0] + ((width - 1) / 2);
                            double_old_point[1] = ((height - 1) / 2) - rotate_search_point(i, j)[1];
                            new_bitmap.SetPixel(i, j, Bilinear(double_old_point[0], double_old_point[1]));
                        }
                        else if (this.distortion.CheckState == CheckState.Checked)
                        {
                            double_old_point[0] = distortion_search_point(i, j)[0] + ((width - 1) / 2);
                            double_old_point[1] = ((height - 1) / 2) - distortion_search_point(i, j)[1];
                            if (double_old_point[0] >= 0 && double_old_point[1] >= 0 && double_old_point[0] <= width - 1 && double_old_point[1] <= height - 1)
                                new_bitmap.SetPixel(i, j, Bilinear(double_old_point[0], double_old_point[1]));
                            else
                                new_bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        }
                        progressBar1.Value += 1;
                    }
                }
                pictureBox2.Image = (Image)new_bitmap;
            }
            else if (this.thirdbox.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (this.rotate.CheckState == CheckState.Checked)
                        {
                            double_old_point[0] = rotate_search_point(i, j)[0] + ((width - 1) / 2);
                            double_old_point[1] = ((height - 1) / 2) - rotate_search_point(i, j)[1];
                            new_bitmap.SetPixel(i, j, Bicubic(double_old_point[0], double_old_point[1]));
                        }
                        else if (this.distortion.CheckState == CheckState.Checked)
                        {
                            double_old_point[0] = distortion_search_point(i, j)[0] + ((width - 1) / 2);
                            double_old_point[1] = ((height - 1) / 2) - distortion_search_point(i, j)[1];
                            if (double_old_point[0] >= 0 && double_old_point[1] >= 0 && double_old_point[0] <= width - 1 && double_old_point[1] <= height - 1)
                                new_bitmap.SetPixel(i, j, Bicubic(double_old_point[0], double_old_point[1]));
                            else
                                new_bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        }
                        progressBar1.Value += 1;
                    }
                }
                pictureBox2.Image = (Image)new_bitmap;
            }
        }
        //保存图片
        private void save_pic_Click(object sender, EventArgs e)
        {
            Image s_pic;
            s_pic = pictureBox2.Image;
            if(s_pic == null)
            {
                MessageBox.Show("未生成图片，无法保存", "提示");
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "JPG图像(*.jpg)|*.jpg|BMP图像(*.bmp)|*.bmp|所有文件(*.*)|*.*";
                if(sfd.ShowDialog()==DialogResult.OK)
                {
                    s_pic.Save(sfd.FileName);
                    MessageBox.Show("保存成功", "提示");
                    sfd.Dispose();
                }
            }
        }
    }
}
