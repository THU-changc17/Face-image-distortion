using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DlibDotNet;

namespace FaceTPS
{
    public partial class FaceTPS : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        //打开控制台Debug必须操作
        public static extern void FreeConsole();
        public double[,] Source_data = new double[68, 2]; //源图片数据
        public double[,] Guide_data = new double[68, 2];  //导向图片数据
        public Bitmap Source_pic;
        public Bitmap Guide_pic;
        public string Source_loc; //源图片路径
        public string Guide_loc;  //导向图片路径
        public double[,] ini_Guide_data = new double[68, 2];
        public int width; //图像宽
        public int height; //图像高
        public int[,,] pix; 
        public FaceTPS()
        {
            InitializeComponent();
            //AllocConsole();   //开启控制台
        }
        private void S_pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog(); //导入源图片
            of.Filter = "JPG图像(*.jpg)|*.jpg|BMP图像(*.bmp)|*.bmp|所有文件(*.*)|*.*";
            of.FilterIndex = 0;
            of.ShowDialog();
            Source_loc = of.FileName.ToString();
            String filename = of.FileName.ToString();
            this.Source_pic = new Bitmap(filename);
            pictureBox1.Image = (Image)this.Source_pic;
            width = Source_pic.Width;
            height = Source_pic.Height;
            int[,,] RGB = new int[width, height, 3];
            pix = RGB;
            //获取源图片RGB像素值
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    pix[i, j, 0] = this.Source_pic.GetPixel(i, j).R;
                    pix[i, j, 1] = this.Source_pic.GetPixel(i, j).G;
                    pix[i, j, 2] = this.Source_pic.GetPixel(i, j).B;
                }
            }
            label1.Text = "未导入源图片数据";
        }
        private void G_pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog(); //导入导向图片
            of.Filter = "JPG图像(*.jpg)|*.jpg|BMP图像(*.bmp)|*.bmp|所有文件(*.*)|*.*";
            of.FilterIndex = 0;
            of.ShowDialog();
            Guide_loc = of.FileName.ToString();
            String filename = of.FileName.ToString();
            this.Guide_pic = new Bitmap(filename);
            pictureBox2.Image = (Image)this.Guide_pic;
            label2.Text = "未导入导向图片数据";
        }
        private void S_data_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "All files(*.*)|*.*|txt files(*.txt)|*.txt";
            of.FilterIndex = 0;
            of.ShowDialog();
            String filename = of.FileName.ToString();
            StreamReader RD = File.OpenText(filename);
            for (int i = 0; i < 68; i++)
            {
                string line = RD.ReadLine();
                string[] data = line.Split(' ');
                //将科学计数法表示的数据转化为浮点型
                if (data[0].Contains("e"))
                    Source_data[i, 0] = double.Parse(data[0], System.Globalization.NumberStyles.Float);
                else
                    Source_data[i, 0] = double.Parse(data[0]);
                if (data[1].Contains("e"))
                    Source_data[i, 1] = double.Parse(data[1], System.Globalization.NumberStyles.Float);
                else
                    Source_data[i, 1] = double.Parse(data[1]);
            }
            //在图片上标注人脸关键点
            var g = Graphics.FromImage(Source_pic);
            for (int i = 0; i < 68; i++)
                g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), (int)Source_data[i, 0], (int)Source_data[i, 1], 5, 5);
            g.Dispose();
            pictureBox1.Image = Source_pic.Clone() as Image;
            label1.Text = "已导入源图片数据";
            of.Dispose();
        }
        private void G_data_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "All files(*.*)|*.*|txt files(*.txt)|*.txt";
            of.FilterIndex = 0;
            of.ShowDialog();
            String filename = of.FileName.ToString();
            StreamReader RD = File.OpenText(filename);
            for (int i = 0; i < 68; i++)
            {
                string line = RD.ReadLine();
                string[] data = line.Split(' ');
                if (data[0].Contains("e"))
                    Guide_data[i, 0] = double.Parse(data[0], System.Globalization.NumberStyles.Float);
                else
                    Guide_data[i, 0] = double.Parse(data[0]);
                if (data[1].Contains("e"))
                    Guide_data[i, 1] = double.Parse(data[1], System.Globalization.NumberStyles.Float);
                else
                    Guide_data[i, 1] = double.Parse(data[1]);
            }
            //将初始导向图片数据保存起来ini
            for(int i = 0; i < 68; i++)
            {
                ini_Guide_data[i, 0] = Guide_data[i, 0];
                ini_Guide_data[i, 1] = Guide_data[i, 1];
            }
            var h = Graphics.FromImage(Guide_pic);
            for (int i = 0; i < 68; i++)
                h.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), (int)Guide_data[i, 0], (int)Guide_data[i, 1], 5, 5);
            h.Dispose();
            pictureBox2.Image = Guide_pic.Clone() as Image;
            label2.Text = "已导入导向图片数据";
            of.Dispose();
        }
        private double[,] my_affine()
        {
            //仿射变换矩阵最小二乘法求解
            double[,] Guide_Point = new double[68, 3];
            double[,] Source_Point = new double[68, 3];
            for(int i = 0; i < 68; i++)
            {
                Source_Point[i, 0] = Source_data[i, 0];
                Source_Point[i, 1] = Source_data[i, 1];
                Source_Point[i, 2] = 1;
            }
            for (int i = 0; i < 68; i++)
            {
                Guide_Point[i, 0] = Guide_data[i, 0];
                Guide_Point[i, 1] = Guide_data[i, 1];
                Guide_Point[i, 2] = 1;
            }
            return Mulmatrix(inverse_matrix(Mulmatrix(transposition_matrix(Guide_Point), Guide_Point)),
                Mulmatrix(transposition_matrix(Guide_Point), Source_Point));
        }
        //获取U值
        private double get_U(double x1, double y1, double x2, double y2)
        {
            double r;
            r = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            double u;
            if (r != 0)
                u = r * r * Math.Log(r * r);
            else
                u = 0;
            return u;
        }
        //矩阵转置
        private double[,] transposition_matrix(double[,] M)
        {
            int row, col;
            row = M.GetLength(0);
            col = M.GetLength(1);
            double[,] N = new double[col, row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                    N[j, i] = M[i, j];
            }
            return N;
        }
        //高斯-约旦消元矩阵求逆
        private double[,] inverse_matrix(double[,] M)
        {
            int n;//M为对称矩阵，n定义为阶次
            int judge = 0;
            n = M.GetLength(0);
            double temp;
            double[,] N = new double[n, 2 * n];
            double[,] inv_M = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    N[i, j] = M[i, j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = n; j < 2 * n; j++)
                {
                    if (j == i + n)
                        N[i, j] = 1;
                    else
                        N[i, j] = 0;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (N[i, i] == 0)
                {
                    double[] Vexchange = new double[2 * n];
                    double Vmax = N[i, i];
                    int pos = i;
                    for (int p = i; p < n; p++)
                    {
                        if (Math.Abs(N[p, i]) > Vmax)
                        {
                            Vmax = Math.Abs(N[p, i]);
                            pos = p;
                        }
                    }
                    if (pos == i) 
                    {
                        MessageBox.Show("TPS矩阵不可逆", "提示！");
                        judge = 1;
                    }
                    for(int q = 0; q < 2 * n; q++)
                    {
                        Vexchange[q] = N[pos, q];
                        N[pos, q] = N[i, q];
                        N[i, q] = Vexchange[q];
                    }
                }
                temp = N[i, i];
                for (int j = 0; j < 2 * n; j++)
                    N[i, j] = N[i, j] / temp;
                for (int u = 0; u < n; u++)
                {
                    temp = N[u, i];
                    for (int v = 0; v < 2 * n; v++)
                    {
                        if (u != i)
                        {
                            N[u, v] = N[u, v] - temp * N[i, v];
                        }
                    }
                }
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    inv_M[i, j] = N[i, j + n];
            Tuple<int, double[,]> tup = new Tuple<int, double[,]>(judge, inv_M);
            return inv_M;
        }
        //矩阵乘法
        private double[,] Mulmatrix(double[,]M,double[,]N)
        {
            int row = M.GetLength(0);
            int col = N.GetLength(1);
            int mid = M.GetLength(1);
            double[,] Mul = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Mul[i, j] = 0;
                }
            }
            for (int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    for(int k = 0; k < mid; k++)
                    {
                        Mul[i, j] = Mul[i, j] + M[i, k] * N[k, j];
                    }
                }
            }
            return Mul;
        }
        //TPS插值求解原图像浮点型点
        private double[] TPS_search(int new_x,int new_y,double[,]solution)
        {
            double old_x = 0;
            double old_y = 0;
            old_x = solution[0, 68] + solution[0, 69] * new_x + solution[0, 70] * new_y;
            old_y = solution[1, 68] + solution[1, 69] * new_x + solution[1, 70] * new_y;
            for(int i = 0; i < 68; i++)
            {
                old_x += solution[0, i] * get_U(Guide_data[i, 0], Guide_data[i, 1], new_x, new_y);
                old_y += solution[1, i] * get_U(Guide_data[i, 0], Guide_data[i, 1], new_x, new_y);
            }
            double[] P = new double[2];
            P[0] = old_x;
            P[1] = old_y;
            return P;
        }
        //获取S值
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
        //最近邻插值
        private Color nearest(double x, double y)
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
            u = x - (int)Math.Floor(x);
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

        private void R_pic_Click(object sender, EventArgs e)
        {
            //是否选择自动检测
            if(this.auto_source.CheckState == CheckState.Checked)
            {
                var detector = Dlib.GetFrontalFaceDetector();
                var img = Dlib.LoadImage<int>(Source_loc);
                Dlib.PyramidUp(img);
                var det = detector.Operator(img);
                var sp = ShapePredictor.Deserialize("./shape_predictor_68_face_landmarks.dat");
                //利用Dlib库自动检测人脸关键点
                foreach (var rect in det)
                {
                    var shape = sp.Detect(img, rect);
                    for (uint i = 0; i < 68; i++)
                    {
                        Source_data[i, 0] = shape.GetPart(i).X / 2;
                        Source_data[i, 1] = shape.GetPart(i).Y / 2;
                    }
                }
                var g = Graphics.FromImage(Source_pic);
                for (int i = 0; i < 68; i++)
                    g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), (int)Source_data[i, 0], (int)Source_data[i, 1], 5, 5);
                g.Dispose();
                pictureBox1.Image = Source_pic.Clone() as Image;
            }
            if(this.auto_guide.CheckState == CheckState.Checked)
            {
                var detector = Dlib.GetFrontalFaceDetector();
                var img = Dlib.LoadImage<int>(Guide_loc);
                Dlib.PyramidUp(img);
                var det = detector.Operator(img);
                var sp = ShapePredictor.Deserialize("./shape_predictor_68_face_landmarks.dat");
                foreach (var rect in det)
                {
                    var shape = sp.Detect(img, rect);
                    for (uint i = 0; i < 68; i++)
                    {
                        Guide_data[i, 0] = shape.GetPart(i).X / 2;
                        Guide_data[i, 1] = shape.GetPart(i).Y / 2;
                        ini_Guide_data[i, 0] = shape.GetPart(i).X / 2;
                        ini_Guide_data[i, 1] = shape.GetPart(i).Y / 2;
                        //Console.Write(Guide_data[i, 0].ToString()+"  "+ Guide_data[i, 1].ToString()+"\n");
                    }
                }
                var g = Graphics.FromImage(Guide_pic);
                for (int i = 0; i < 68; i++)
                    g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), (int)Guide_data[i, 0], (int)Guide_data[i, 1], 5, 5);
                g.Dispose();
                pictureBox2.Image = Guide_pic.Clone() as Image;
            }
            double[,] K = new double[68, 68];
            double[,] P = new double[68, 3];
            double[,] trans_P = new double[3, 68];
            double[,] L = new double[71, 71];
            double[,] trans_Y = new double[2, 71];
            double[,] Y = new double[71, 2];
            double[,] solution = new double[2, 71];
            double[] old_Point = new double[2];
            progressBar1.Value = 0;
            progressBar1.Maximum = width * height;
            //生成图片前刷新导向图片数据，用于区分是否对齐
            for (int i = 0; i < 68; i++)
            {
                Guide_data[i, 0] = ini_Guide_data[i, 0];
                Guide_data[i, 1] = ini_Guide_data[i, 1];
            }
            //是否选择对齐人脸
            if (align.CheckState == CheckState.Checked)
            {
                double[,] align_matrix = new double[3, 3];
                //align_matrix = my_affine();
                for(int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        align_matrix[i, j] = my_affine()[i, j];
                    }
                }
                for (int i = 0; i < 68; i++)
                {
                    Guide_data[i, 0] = align_matrix[0, 0] * Guide_data[i, 0] + align_matrix[1, 0] * Guide_data[i, 1] + align_matrix[2, 0];
                    Guide_data[i, 1] = align_matrix[0, 1] * Guide_data[i, 0] + align_matrix[1, 1] * Guide_data[i, 1] + align_matrix[2, 1]; 
                }
            }
            for (int i = 0; i < 68; i++)
            {
                for (int j = 0; j < 68; j++)
                {
                    if (i == j)
                        K[i, j] = 0;
                    else
                        //控制点是导向点
                        K[i, j] = get_U(Guide_data[i, 0], Guide_data[i, 1], Guide_data[j, 0], Guide_data[j, 1]);
                    L[i, j] = K[i, j];
                }
                P[i, 0] = 1;
                P[i, 1] = Guide_data[i, 0];
                P[i, 2] = Guide_data[i, 1];
            }
            trans_P = transposition_matrix(P);
            for (int i = 0; i < 68; i++)
                for (int j = 68; j < 71; j++)
                    L[i, j] = P[i, j - 68];

            for (int i = 68; i < 71; i++)
                for (int j = 0; j < 68; j++)
                    L[i, j] = trans_P[i - 68, j];

            for (int i = 68; i < 71; i++)
                for (int j = 68; j < 71; j++)
                    L[i, j] = 0;
            for (int k = 0; k < 68; k++)
            {
                //源图中的点为目标点
                trans_Y[0, k] = Source_data[k, 0];
                trans_Y[1, k] = Source_data[k, 1];
            }
            for (int k = 68; k < 71; k++)
            {
                trans_Y[0, k] = 0;
                trans_Y[1, k] = 0;
            }
            Y = transposition_matrix(trans_Y);
            solution = transposition_matrix(Mulmatrix(inverse_matrix(L), Y));
            Bitmap new_bitmap = (Bitmap)Source_pic.Clone();
            for (int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    old_Point = TPS_search(i, j, solution);
                    if(this.near.Checked == true)
                    {
                        if (old_Point[0] >= 0 && old_Point[1] >= 0 && old_Point[0] <= width - 1 && old_Point[1] <= height - 1)
                            new_bitmap.SetPixel(i, j, nearest(old_Point[0], old_Point[1]));
                        else
                            new_bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else if(this.linear.Checked == true)
                    {
                        if (old_Point[0] >= 0 && old_Point[1] >= 0 && old_Point[0] <= width - 1 && old_Point[1] <= height - 1)
                            new_bitmap.SetPixel(i, j, Bilinear(old_Point[0], old_Point[1]));
                        else
                            new_bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else if(this.third.Checked == true)
                    {
                        if (old_Point[0] >= 0 && old_Point[1] >= 0 && old_Point[0] <= width - 1 && old_Point[1] <= height - 1)
                            new_bitmap.SetPixel(i, j, Bicubic(old_Point[0], old_Point[1]));
                        else
                            new_bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    progressBar1.Value += 1;
                }
            }
            pictureBox3.Image = (Image)new_bitmap;
        }

        private void sav_pic_Click(object sender, EventArgs e)
        {
            Image s_pic;
            s_pic = pictureBox3.Image;
            if (s_pic == null)
            {
                MessageBox.Show("未生成图片，无法保存", "提示");
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "JPG图像(*.jpg)|*.jpg|所有文件(*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    s_pic.Save(sfd.FileName);
                    MessageBox.Show("保存成功", "提示");
                    sfd.Dispose();
                }
            }
        }
    }

}
