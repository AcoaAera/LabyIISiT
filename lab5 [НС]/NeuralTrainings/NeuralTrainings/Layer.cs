using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralTrainings
{
    class Layer
    {
        private List<Link> layer;
        private int inputNeuronsCount, outputNeuronsCount;
        private const double errorFixValue = 0.15;

        public Layer(int inputNeuronsCount, int outputNeuronsCount, double[,] weights)
        {
            this.inputNeuronsCount = inputNeuronsCount;
            this.outputNeuronsCount = outputNeuronsCount;
            layer = new List<Link>();

            for (int i = 0; i < inputNeuronsCount; i++)
            {
                Neuron firstLayerNeuron = new Neuron();

                for (int j = 0; j < outputNeuronsCount; j++)
                    layer.Add(new Link(firstLayerNeuron, new Neuron()));  //layer.Add(new Link(new Neuron(), new Neuron()));
            }
        }

        public bool GetNeuronSignal(int linkIndex)
        {
            return layer[linkIndex].Neuron1.Signal;
        }

        public void SetNeuronSignal(int linkIndex, bool signalValue)
        {
            layer[linkIndex].Neuron1.Signal = signalValue;
        }

        public double GetWeight(int linkIndex)
        {
            return layer[linkIndex].WeightValue;
        }

        public void SetWeight(int linkIndex, double weightValue)
        {
            layer[linkIndex].WeightValue = weightValue;
        }

        public void WeightsFix(int neuronSignal, int neuronIndex)
        {
            for (int i = neuronIndex; i < layer.Count; i += outputNeuronsCount)
            {
                if (layer[i].Neuron1.Signal) // активный нейрон
                {
                    if (neuronSignal == 0)
                        layer[i].WeightValue += errorFixValue;
                    else
                        layer[i].WeightValue -= errorFixValue;
                }
            }
        }

        public double[,] GetWeights()
        {
            double[,] weights = new double[inputNeuronsCount, outputNeuronsCount];

            int i = 0, j = 0;

            for (int k = 0; k < layer.Count; k++)
            {
                weights[i, j++] = layer[k].WeightValue;

                if ((k + 1) % outputNeuronsCount == 0)
                {
                    i++;
                    j = 0;
                }
            }

            return weights;
        }

        public void SignalsReset()
        {
            foreach (var link in layer)
            {
                link.Neuron1.Signal = false;
                link.Neuron2.Signal = false;
            }
        }

        //Свертка
        public double[] GetMultiples()
        {
            double[] multiples = new double[outputNeuronsCount];

            for (int i = 0; i < outputNeuronsCount; i++)
                for (int j = i; j < layer.Count; j += outputNeuronsCount)
                {
                    if (layer[j].Neuron1.Signal)
                        multiples[i] += layer[j].WeightValue;
                }

            return multiples;
        }
    }
}
