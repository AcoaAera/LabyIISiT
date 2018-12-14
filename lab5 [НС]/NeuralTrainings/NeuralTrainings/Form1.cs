using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;

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
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
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
        }

        private void PbClearBtn_Click(object sender, EventArgs e)
        {
        }

        private void StudyModeRB_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void RecognitionModeRB_CheckedChanged(object sender, EventArgs e)
        {
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
