using System.IO;
using System.Linq;
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
        [DataRow("112255", new[] { 1d, 1d, 2d, 2d, 5d, 5d},DisplayName = "Duplicate Numbers")]
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
    }
}
