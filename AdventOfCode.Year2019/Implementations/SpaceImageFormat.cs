using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Year2019.Interfaces;

namespace AdventOfCode.Year2019.Implementations
{
    public class SpaceImageFormat : ISpaceImageFormat
    {
        public List<Layer> DecodeImage(List<double> input, int imageWidth, int imageHeight)
        {
            var layerList = new List<Layer>();
            var layer = new Layer(imageHeight, imageWidth);
            var pixelRow = new List<double>(imageWidth);
            var rowCount = 0;

            for (int i = 0; i < input.Count; i++)
            {
                pixelRow.Add(input[i]);

                if (i > 0 && (i + 1) % imageWidth == 0)
                {
                    layer.Pixels.Add(pixelRow);
                    pixelRow = new List<double>(imageWidth);
                    rowCount++;
                }

                if (rowCount == imageHeight)
                {
                    layerList.Add(layer);
                    layer = new Layer(imageHeight, imageWidth);
                    pixelRow = new List<double>(imageWidth);
                    rowCount = 0;
                }
            }

            return layerList;
        }

        public double CheckCorruptedImage(List<Layer> layers)
        {
            var layer = layers.Aggregate((x, min) => x.ZeroCount < min.ZeroCount ? x : min);

            return layer.Pixels.SelectMany(x => x.Where(i => i == 1)).Count() * layer.Pixels.SelectMany(x => x.Where(i => i == 2)).Count();
        }

        public int BuildImage(List<Layer> input)
        {
            var imageHeight = input.First().ImageHeight;
            var imageWidth = input.First().ImageWidth;
            var picture = new Layer(imageHeight, imageWidth, true);

            for (var i = 0; i < imageHeight; i++)
            {
                for (var j = 0; j < imageWidth; j++)
                {
                    foreach (var layer in input)
                    {
                        if (layer.Pixels[i][j] == 2)
                        {
                            continue;
                        }

                        picture.Pixels[i].Add(layer.Pixels[i][j]);

                        break;
                    }
                }
            }

            foreach (var row in picture.Pixels)
            {
                for (int i = 0; i < row.Count; i++)
                {
                    var output = row[i].ToString().Replace("0", " ");
                    Console.Write(output);
                    if (i == row.Count - 1)
                    {
                        Console.Write("\n");
                    }
                }
            }

            return 0;
        }
    }

    public class Layer
    {
        public int ImageHeight;
        public int ImageWidth;

        public List<List<double>> Pixels;

        public int ZeroCount => Pixels.SelectMany(x => x).Count(x => x == 0);

        public Layer(int imageHeight, int imageWidth)
        {
            ImageHeight = imageHeight;
            ImageWidth = imageWidth;
            Pixels = new List<List<double>>(imageHeight);
        }

        public Layer(int imageHeight, int imageWidth, bool prePopulatePixels)
        {
            ImageHeight = imageHeight;
            ImageWidth = imageWidth;
            Pixels = new List<List<double>>(imageHeight);
            if (prePopulatePixels)
            {
                for (int i = 0; i < imageHeight; i++)
                {
                    Pixels.Add(new List<double>(imageWidth));
                }
            }
        }
    }
}