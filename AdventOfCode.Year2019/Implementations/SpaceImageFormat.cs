using System;
using System.Collections.Generic;
using System.Globalization;
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
                    layer.Pixels[rowCount] = pixelRow;
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

        public Layer BuildImage(List<Layer> input)
        {
            var imageHeight = input.First().ImageHeight;
            var imageWidth = input.First().ImageWidth;
            var picture = new Layer(imageHeight, imageWidth);

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
                for (var i = 0; i < row.Count; i++)
                {
                    var output = row[i].ToString(CultureInfo.InvariantCulture).Replace("0", " ");
                    Console.Write(output);
                    if (i == row.Count - 1)
                    {
                        Console.Write("\n");
                    }
                }
            }

            return picture;
        }
    }

    public class Layer : IEquatable<Layer>
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

            for (int i = 0; i < imageHeight; i++)
            {
                Pixels.Add(new List<double>(imageWidth));
            }
        }

        public bool Equals(Layer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ImageHeight == other.ImageHeight && ImageWidth == other.ImageWidth && Pixels.SequenceEqual(other.Pixels);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Layer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ImageHeight;
                hashCode = (hashCode * 397) ^ ImageWidth;
                hashCode = (hashCode * 397) ^ (Pixels != null ? Pixels.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}