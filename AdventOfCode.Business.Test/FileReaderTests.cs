using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using AdventOfCode.Business.Services.Implementations;
using Microsoft.Extensions.FileProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventOfCode.Business.Test
{
    [TestClass]
    public class FileReaderTests
    {
        [DataTestMethod]
        [DataRow("123456", new[] { 1d, 2d, 3d, 4d, 5d, 6d }, DisplayName = "Consecutive Numbers")]
        [DataRow("112255", new[] { 1d, 1d, 2d, 2d, 5d, 5d }, DisplayName = "Duplicate Numbers")]
        [DataRow("1759", new[] { 1d, 7d, 5d, 9d }, DisplayName = "Non Consecutive Numbers")]
        [DataRow("17Az", new[] { 1d, 7d, -1d, -1d }, DisplayName = "Non Numeric Values")]
        public void StringOfNumbersConvertsToListOfNumbers(string input, double[] expectedResult)
        {
            var filePath = "testfile.txt";

            var fileProviderMock = new Mock<IFileProvider>();
            var fileInfoMock = new Mock<IFileInfo>();

            fileProviderMock.Setup(x => x.GetFileInfo(filePath)).Returns(fileInfoMock.Object);
            fileInfoMock.Setup(x => x.CreateReadStream()).Returns(new MemoryStream(Encoding.UTF8.GetBytes(input)));

            double[] result = new FileReader(fileProviderMock.Object).ReadFileToIntArray(filePath).ToArray();

            Assert.IsTrue(expectedResult.SequenceEqual(result));
        }

        [DataTestMethod]
        [DataRow("1\n2\n3\n4\n5\n6", new[] { 1, 2, 3, 4, 5, 6 }, DisplayName = "Consecutive Numbers")]
        [DataRow("1\n1\n2\n2\n5\n5", new[] { 1, 1, 2, 2, 5, 5 }, DisplayName = "Duplicate Numbers")]
        [DataRow("1\n7\n5\n9", new[] { 1, 7, 5, 9 }, DisplayName = "Non Consecutive Numbers")]
        public void NewLineStringOfNumbersConvertsToListOfNumbers(string input, int[] expectedResult)
        {
            var filePath = "testfile.txt";

            var fileProviderMock = new Mock<IFileProvider>();
            var fileInfoMock = new Mock<IFileInfo>();

            fileProviderMock.Setup(x => x.GetFileInfo(filePath)).Returns(fileInfoMock.Object);
            fileInfoMock.Setup(x => x.CreateReadStream()).Returns(new MemoryStream(Encoding.UTF8.GetBytes(input)));

            int[] result = new FileReader(fileProviderMock.Object).ReadFileByLineToNumberList(filePath).ToArray();

            Assert.IsTrue(expectedResult.SequenceEqual(result));
        }

        [TestMethod]
        public void DelimitedListOfNumbersConvertsToListOfNumbers()
        {
            int[] expectedResult = new[] { 1, 2, 3, 4 };

            var input = "1,2,3,4";
            var delimiter = ",";
            var filePath = "testFile.txt";

            var fileProviderMock = new Mock<IFileProvider>();
            var fileInfoMock = new Mock<IFileInfo>();

            fileProviderMock.Setup(x => x.GetFileInfo(filePath)).Returns(fileInfoMock.Object);
            fileInfoMock.Setup(x => x.CreateReadStream()).Returns(new MemoryStream(Encoding.UTF8.GetBytes(input)));

            var result = new FileReader(fileProviderMock.Object).ReadFileToNumberListBySeperator(filePath, delimiter);

            Assert.IsTrue(expectedResult.SequenceEqual(result));
        }

        [TestMethod]
        public void ConvertIndivualLinesToListOfVectors()
        {
            List<List<string>> expectedResult = new List<List<string>>() { new List<string>() { "R1", "U2", "D3", "L4" } };
            var input = "R1,U2,D3,L4";
            var filePath = "testFile.txt";
            var delimiter = ",";

            var fileProviderMock = new Mock<IFileProvider>();
            var fileInfoMock = new Mock<IFileInfo>();

            fileProviderMock.Setup(x => x.GetFileInfo(filePath)).Returns(fileInfoMock.Object);
            fileInfoMock.Setup(x => x.CreateReadStream()).Returns(new MemoryStream(Encoding.UTF8.GetBytes(input)));
            
            var result = new FileReader(fileProviderMock.Object).ReadFileToVectorLists(filePath, delimiter).ToList();
            
            Assert.AreEqual(expectedResult[0][0], result[0].ElementAt(0));
            Assert.AreEqual(expectedResult[0][1], result[0].ElementAt(1));
            Assert.AreEqual(expectedResult[0][2], result[0].ElementAt(2));
            Assert.AreEqual(expectedResult[0][3], result[0].ElementAt(3));
        }

        [TestMethod]
        public void ConvertStringToValueTuples()
        {
            var expectedResult = new List<(string, string)>(){("6WF", "DRK"), ("2PT", "PSM"),("H42", "FN8"), ("1XR", "LQD")};
            var input = "6WF)DRK\r\n2PT)PSM\r\nH42)FN8\r\n1XR)LQD";
            var filePath = "testFile.txt";

            var fileProviderMock = new Mock<IFileProvider>();
            var fileInfoMock = new Mock<IFileInfo>();

            fileProviderMock.Setup(x => x.GetFileInfo(filePath)).Returns(fileInfoMock.Object);
            fileInfoMock.Setup(x => x.CreateReadStream()).Returns(new MemoryStream(Encoding.UTF8.GetBytes(input)));

            var result = new FileReader(fileProviderMock.Object).ReadFileToValueTuple(filePath, ")").ToList();

            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}