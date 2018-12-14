using System;

namespace NeuralTrainings
{
    class Link
    {
        private static Random rnd = new Random();

        public Link(Neuron neuron1, Neuron neuron2)
        {
            Neuron1 = neuron1;
            Neuron2 = neuron2;
            WeightValue = Math.Round(rnd.NextDouble() * 0.05, 4);
        }

        public Neuron Neuron1 { get; private set; }

        public double WeightValue { get; set; }

        public Neuron Neuron2 { get; private set; }
    }
}
