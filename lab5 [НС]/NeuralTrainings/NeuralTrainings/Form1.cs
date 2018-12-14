using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NeuralTrainings
{
    enum CurrentMouseStates { NotMouseMove, MouseMove };
    enum WorkMode { Study, Recognition };

    public partial class Form1 : Form
    {
        NeuralNetwork neuralNetwork;
        Graphics graphics;
        Pen pen;
        Bitmap bitmap;
        int pbWidth, pbHeight;
        float penWidth = 6.5F; // 0.5F - тонкое 2.0F - 2.5F - толстое   
        double[,] weights;
        string path = Directory.GetCurrentDirectory() + "/weights.txt";
        int ratio = 10, size = 0;

        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Blue, penWidth);
            CurrentMouseState = CurrentMouseStates.NotMouseMove;
            pbWidth = pictureBox1.Width;
            pbHeight = pictureBox1.Height;
            bitmap = new Bitmap(pbWidth, pbHeight);
            pictureBox1.Image = bitmap;
            weights = WeightsRead();
            size = pbWidth / ratio;
            neuralNetwork = new NeuralNetwork(size, weights);
            StudyModeRB.Checked = true;
        }

        CurrentMouseStates CurrentMouseState
        {
            get;
            set;
        }

        WorkMode WorkMode
        {
            get;
            set;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            CurrentMouseState = CurrentMouseStates.MouseMove;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (CurrentMouseState == CurrentMouseStates.MouseMove) //  && IsCursorOnPictureBox(e.X, e.Y)
            {
                graphics = Graphics.FromImage(bitmap);
                graphics.DrawLine(pen, e.X + penWidth, e.Y + penWidth, e.X, e.Y);
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            CurrentMouseState = CurrentMouseStates.NotMouseMove;
        }

        private void RecognitionBtn_Click(object sender, EventArgs e)
        {
            int[,] imageOnes = new int[pbWidth, pbHeight];

            for (int i = 0; i < pbWidth; i++)
            {
                for (int j = 0; j < pbHeight; j++)
                {
                    imageOnes[i, j] = bitmap.GetPixel(j, i).B;
                }
            }

            int[,] pixelsCounts = new int[size, size];

            for (int i = 0; i < imageOnes.GetLength(0); i++)
            {
                for (int j = 0; j < imageOnes.GetLength(1); j++)
                {
                    if (imageOnes[i, j] == 255)
                        pixelsCounts[i / ratio, j / ratio]++;
                }
            }

            int[,] newImageOnes = new int[size, size];

            for (int i = 0; i < pixelsCounts.GetLength(0); i++)
            {
                for (int j = 0; j < pixelsCounts.GetLength(1); j++)
                {
                    if (pixelsCounts[i, j] >= 1)
                        newImageOnes[i, j] = 1;
                }
            }

            Tuple<int, int> result = neuralNetwork.GetConclusion(newImageOnes);

            int neuronSignal = result.Item1;
            int number = result.Item2;

            DialogResult dialogResult = DialogResult.None;

            if (WorkMode == WorkMode.Study)
                dialogResult = MessageBox.Show("Это " + number + " ?", "Помоги...", MessageBoxButtons.YesNo);
            else
                MessageBox.Show("Это " + number + " !");

            if (dialogResult == DialogResult.No && WorkMode == WorkMode.Study)
                neuralNetwork.WeightsFix(neuronSignal, number);

            PictureBoxClear();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            weights = neuralNetwork.GetWeights();
            ArrayWrite(weights, path);
        }

        private void ArrayWrite(double[,] arr, string path)
        {
            File.WriteAllText(path, "");

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    File.AppendAllText(path, arr[i, j] + " ");
                }
                File.AppendAllText(path, "\r\n");
            }
        }

        private bool IsCursorOnPictureBox(float x, float y)
        {
            float PBwidth = pictureBox1.Width;
            float PBheight = pictureBox1.Height;

            if (x > 0 && x < PBwidth && y > 0 && y < PBheight)
                return true;

            return false;
        }

        private void PbClearBtn_Click(object sender, EventArgs e)
        {
            PictureBoxClear();
        }

        private void StudyModeRB_CheckedChanged(object sender, EventArgs e)
        {
            WorkMode = WorkMode.Study;
        }

        private void RecognitionModeRB_CheckedChanged(object sender, EventArgs e)
        {
            WorkMode = WorkMode.Recognition;
        }

        private void PictureBoxClear()
        {
            bitmap = new Bitmap(pbWidth, pbHeight);
            pictureBox1.Image = bitmap;
        }

        private double[,] WeightsRead()
        {
            string[] strArray = null;

            if (File.Exists(path))
                strArray = File.ReadAllLines(path);
            else
                return null;

            int columnsCount = strArray[0].Split(' ').Length - 1; // почему сплит видит 4-ый пустой элемент - неизвестно. поэтому отнимаем единицу

            double[,] weights = new double[strArray.Length, columnsCount];

            for (int i = 0; i < strArray.Length; i++)
            {
                string[] str = strArray[i].Split(' ');

                for (int j = 0; j < columnsCount; j++)
                {
                    weights[i, j] = Convert.ToDouble(str[j]);
                }
            }

            return weights;
        }
    }
}
