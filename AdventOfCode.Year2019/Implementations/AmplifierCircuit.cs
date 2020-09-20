using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Year2019.Interfaces;
using AdventOfCode.Year2019.Interfaces.ShipComputer;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Year2019.Implementations
{
    public class AmplifierCircuit : IAmplifierCircuit
    {
        private readonly IShipComputer _shipComputer;
        private readonly IServiceProvider _serviceCollection;

        public AmplifierCircuit(IShipComputer shipComputer, IServiceProvider serviceCollection)
        {
            _shipComputer = shipComputer;
            _serviceCollection = serviceCollection;
        }

        public double Amplify(double[] data, double input, double[] phaseSetting)
        {
            double[] dataCopy = new double[data.Length];
            data.ToList().CopyTo(dataCopy);
            //var maxAmplification = 0;
            double output = 0;

            for (var i = 0; i < phaseSetting.Length; i++)
            {
                if (i > 0) input = output;

                var inputQueue = new Queue<double>(new[] { phaseSetting[i], input });
                _shipComputer.Reset();
                _shipComputer.ComputeIntCode(dataCopy, out output, inputQueue, out bool halted);
            }

            return output;
        }

        public double AmplifyFeedback(double[] data, double input, double[] phaseSetting)
        {
            double output = 0;
            var halted = false;
            var amplifiers = new List<IShipComputer>();

            while (true)
            {
                int i;
                for (i = 0; i < phaseSetting.Length; i++)
                {
                    double[] dataCopy = new double[data.Length];
                    data.ToList().CopyTo(dataCopy);
                    var inputQueue = new Queue<double>();
                    if (amplifiers.ElementAtOrDefault(i) == null)
                    {
                        amplifiers.Add(_serviceCollection.GetService<IShipComputer>());
                        inputQueue.Enqueue(phaseSetting[i]);
                    }

                    inputQueue.Enqueue(input);

                    amplifiers[i].ComputeIntCode(dataCopy, out output, inputQueue, out halted);

                    if (output > 0) input = output;
                }

                if (halted && i == 5) break;
            }

            return input;
        }

        public double CalculateHighestAmplification(double[] data, bool feedback)
        {
            double[] dataCopy = new double[data.Length];
            data.ToList().CopyTo(dataCopy);
            double maxValue = 0;

            var sequences = SequenceGenerator(feedback);

            foreach (var sequence in sequences)
            {
                var result = feedback ? AmplifyFeedback(dataCopy, 0, sequence) : Amplify(dataCopy, 0, sequence);
                if (result > maxValue) maxValue = result;
            }

            return maxValue;
        }

        private List<double[]> SequenceGenerator(bool feedBackLoop)
        {
            var list = new List<double[]>();
            var feedbackOffset = feedBackLoop ? 5 : 0;


            for (double a = feedbackOffset; a <= 4 + feedbackOffset; a++)
            {
                for (double b = feedbackOffset; b <= 4 + feedbackOffset; b++)
                {
                    for (double c = feedbackOffset; c <= 4 + feedbackOffset; c++)
                    {
                        for (double d = feedbackOffset; d <= 4 + feedbackOffset; d++)
                        {
                            for (double e = feedbackOffset; e <= 4 + feedbackOffset; e++)
                            {
                                if (a == b || a == c || a == d || a == e || b == c || b == d || b == e || c == d || c == e || d == e)
                                    continue;

                                list.Add(new[] { a, b, c, d, e });
                            }
                        }
                    }
                }
            }

            return list;
        }
    }
}