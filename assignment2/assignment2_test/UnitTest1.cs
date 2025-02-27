using Assignment2;
using Xunit;
using System;

namespace assignment2_test
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetPrimeFactor()
        {
            int n = 30;
            SortedSet<int> res = Program.GetPrimeFactor(n);
            Assert.Contains(2, res);
            Assert.Contains(3, res);
            Assert.Contains(5, res);
        }

        [Fact]
        public void TestArrayInfo()
        {
            int[] array = {1, 99, 2, 98, 50, 50};
            int[] expected = { 99, 1, 50, 300 };
            int[] res = Program.ArrayInfo(array);
            Assert.Equal(res, expected);
        }

        [Fact]
        public void TestEratosthenes()
        {
            int n = 20;
            SortedSet<int> res = Program.Eratosthenes(n);
            SortedSet<int> expected = new SortedSet<int> {2, 3, 5, 7, 11, 13, 17, 19};
            Assert.Equal(res, expected);
        }

        [Fact]
        public void TestIsToeplitzMatrix1()
        {
            int[,] matrix = { { 1, 2, 3, 4},
                              { 5, 1, 2, 3},
                              { 6, 5, 1, 2} };
            Assert.True(Program.IsToeplitzMatrix(matrix));
        }

        [Fact]
        public void TestGetToeplitzMatrix2()
        {
            int[,] matrix = { { 1, 2, 3, 4},
                              { 5, 1, 2, 3},
                              { 6, 99, 1, 2} };
            Assert.False(Program.IsToeplitzMatrix(matrix));
        }
    }
}