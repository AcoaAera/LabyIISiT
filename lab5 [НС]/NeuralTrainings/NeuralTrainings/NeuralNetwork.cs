using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralTrainings
{
    class NeuralNetwork
    {
        private List<Layer> network;
        private double[,] weights;
        private int inputNeuronsCount, outputNeuronsCount;

        public NeuralNetwork(int matrixSide, double[,] weights)
        {
            network = new List<Layer>();
            inputNeuronsCount = matrixSide * matrixSide;
            outputNeuronsCount = 3;
            network.Add(new Layer(inputNeuronsCount, outputNeuronsCount, weights));
            Threshold = 0.6;

            if (weights != null)
            {
                this.weights = weights;
                WriteWeightsFromFileToNeurons();
            }
        }

        private void WriteWeightsFromFileToNeurons()
        {
            for (int i = 0; i < weights.GetLength(0); i++)
            {
                for (int j = 0; j < weights.GetLength(1); j++)
                {
                    int index = (i + 1) * weights.GetLength(1) - (weights.GetLength(1) - j);
                    double weightValue = weights[i, j];
                    network[0].SetWeight(index, weightValue);
                }
            }
        }

        private int ActivateFunction(double value)
        {
            return 1 / (1 + Math.Exp(-value)) > Threshold ? 1 : 0;
        }

        private double Threshold
        {
            get;
            set;
        }

        public Tuple<int, int> GetConclusion(int[,] imageOnes)
        {
            network[0].SignalsReset();

            for (int i = 0; i < imageOnes.GetLength(0); i++) // активация нужных нейронов и увеличение их весов
            {
                for (int j = 0; j < imageOnes.GetLength(1); j++)
                    if (imageOnes[i, j] == 1)
                    {
                        int index = (i + 1) * imageOnes.GetLength(1) - (imageOnes.GetLength(1) - j);
                        network[0].SetNeuronSignal(index, true);
                    }
            }

            double[] multiples = network[0].GetMultiples();

            int[] outputNeuronsSignals = new int[outputNeuronsCount];

            for (int i = 0; i < multiples.Length; i++)
            {
                double y = 1 / (1 + Math.Exp(-multiples[i]));
                outputNeuronsSignals[i] = y > Threshold ? 1 : 0; //outputNeuronsSignals[i] = ActivateFunction(multiples[i]);
            }

            int resultIndex = multiples.ToList().IndexOf(multiples.Max());
            int resultNeuronSignal = outputNeuronsSignals[resultIndex];

            return Tuple.Create(resultNeuronSignal, resultIndex);
        }

        public void WeightsFix(int neuronValue, int weightIndex)
        {
            network[0].WeightsFix(neuronValue, weightIndex);
        }

        public double[,] GetWeights()
        {
            return network[0].GetWeights();
        }
    }
}
