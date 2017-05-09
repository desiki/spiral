using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpiralTest
{
    [TestClass]
    public class SpiralTest
    {
        [TestMethod]
        public void Test_Result_SumOfValues_zero()
        {
            int start = 0;
            int limit = 0;
            long expectedResult = 0;
            Assert.AreEqual(Spiral.SumOfValues(start, limit), expectedResult);
        }

        [TestMethod]
        public void Test_Result_SumOfValues_1()
        {
            int start = 0;
            int limit = 10;
            long expectedResult = 80;
            Assert.AreEqual(Spiral.SumOfValues(start, limit), expectedResult);
        }

        [TestMethod]
        public void Test_Result_SumOfValues_2()
        {
            int start = 1;
            int limit = 2;
            long expectedResult = 4;
            Assert.AreEqual(Spiral.SumOfValues(start, limit), expectedResult);
        }

        [TestMethod]
        public void Test_Result_SumOfValues_3()
        {
            int start = 0;
            int limit = 10;
            long expectedResult = 80;
            Assert.AreEqual(Spiral.SumOfValues(start, limit), expectedResult);
        }

        [TestMethod]
        public void Test_Result_getValueForY_positive()
        {
            int y = 3;
            int expectedResult = 39;
            Assert.AreEqual(Spiral.getValueForY(y), expectedResult);
        }

        [TestMethod]
        public void Test_Result_getValueForY_negative()
        {
            int y = -6;
            int expectedResult = 126;
            Assert.AreEqual(Spiral.getValueForY(y), expectedResult);
        }

        [TestMethod]
        public void Test_Result_getValueForY_zero()
        {
            int y = 0;
            int expectedResult = 0;
            Assert.AreEqual(Spiral.getValueForY(y), expectedResult);
        }

        [TestMethod]
        public void Test_Result_getValueForX_positive()
        {
            int x = 5;
            int expectedResult = 95;
            Assert.AreEqual(Spiral.getValueForX(x), expectedResult);
        }

        [TestMethod]
        public void Test_Result_getValueForX_negative()
        {
            int x = -5;
            int expectedResult = 115;
            Assert.AreEqual(Spiral.getValueForX(x), expectedResult);
        }

        [TestMethod]
        public void Test_Result_getValueForX_zero()
        {
            int x = 0;
            int expectedResult = 0;
            Assert.AreEqual(Spiral.getValueForX(x), expectedResult);
        }

        [TestMethod]
        public void Test_Result_FromPositiveAxisY_WrongInput()
        {
            int x = 2;
            int y = -1;
            int expectedResult = -1;
            Assert.AreEqual(Spiral.ValueFromPositiveAxisY(x, y), expectedResult);
        }

        [TestMethod]
        public void Test_Result_FromPositiveAxisY_CorrectInput()
        {
            int x = 2;
            int y = 3;
            int expectedResult = 37;
            Assert.AreEqual(Spiral.ValueFromPositiveAxisY(x, y), expectedResult);
        }

        [TestMethod]
        public void Test_Result_FromNegativeAxisY_WrongInput()
        {
            int x = 2;
            int y = 1;
            int expectedResult = -1;
            Assert.AreEqual(Spiral.ValueFromNegativeAxisY(x, y), expectedResult);
        }

        [TestMethod]
        public void Test_Result_FromNegativeAxisY_CorrectInput()
        {
            int x = -2;
            int y = -3;
            int expectedResult = 25;
            Assert.AreEqual(Spiral.ValueFromNegativeAxisY(x, y), expectedResult);
        }
        
        [TestMethod]
        public void Test_AreLimitsCorrect_WrongLimits()
        {
            int x = 1000000;
            int y = 1000000;
            bool expectedValue = false;
            Assert.AreEqual(Spiral.AreLimitsCorrect(x, y), expectedValue);
        }

        [TestMethod]
        public void Test_AreLimitsCorrect_WrongLimitsNegative()
        {
            int x = -1000000;
            int y = 999999;
            bool expectedValue = false;
            Assert.AreEqual(Spiral.AreLimitsCorrect(x, y), expectedValue);
        }

        [TestMethod]
        public void Test_AreLimitsCorrect_RigthLimits()
        {
            int x = 999999;
            int y = 999999;
            bool expectedValue = true;
            Assert.AreEqual(Spiral.AreLimitsCorrect(x, y), expectedValue);
        }
  
        [TestMethod]
        public void Test_Result_GetNumberAtPositionOrigin()
        {
            int x = 0;
            int y = 0;
            long expectedValue = 0;
            Assert.AreEqual(Spiral.GetNumberAtPosition(x, y), expectedValue);
        }

        [TestMethod]
        public void Test_Result_GetNumberAtPosition_test1()
        {
            int x = 1;
            int y = 1;
            long expectedValue = 4;
            Assert.AreEqual(Spiral.GetNumberAtPosition(x, y), expectedValue);
        }

        [TestMethod]
        public void Test_Result_GetNumberAtPosition_test2()
        {
            int x = 0;
            int y = 1;
            long expectedValue = 5;
            Assert.AreEqual(Spiral.GetNumberAtPosition(x, y), expectedValue);
        }

        [TestMethod]
        public void Test_Result_GetNumberAtPosition_test3()
        {
            int x = -1;
            int y = 1;
            long expectedValue = 6;
            Assert.AreEqual(Spiral.GetNumberAtPosition(x, y), expectedValue);
        }

        [TestMethod]
        public void Test_Result_GetNumberAtPosition_test4()
        {
            int x = 2;
            int y = 2;
            long expectedValue = 16;
            Assert.AreEqual(Spiral.GetNumberAtPosition(x, y), expectedValue);
        }

        [TestMethod]
        public void Test_Result_GetNumberAtPosition_test5()
        {
            int x = -4;
            int y = -5;
            long expectedValue = 81;
            Assert.AreEqual(Spiral.GetNumberAtPosition(x, y), expectedValue);
        }

        [TestMethod]
        public void Test_Result_GetNumberAtPosition_test6()
        {
            int x = 0;
            int y = -5;
            long expectedValue = 85;
            Assert.AreEqual(Spiral.GetNumberAtPosition(x, y), expectedValue);
        }

        [TestMethod]
        public void Test_Result_GetNumberAtPosition_test7()
        {
            int x = -2;
            int y = -1;
            long expectedValue = 23;
            Assert.AreEqual(Spiral.GetNumberAtPosition(x, y), expectedValue);
        }

        [TestMethod]
        public void Test_Result_GetNumberAtPosition_test8()
        {
            int x = 999999;
            int y = 999999;
            long expectedValue = 3999992000004;
            Assert.AreEqual(Spiral.GetNumberAtPosition(x, y), expectedValue);
        }

        [TestMethod]
        public void Test_Result_GetNumberAtPosition_test9()
        {
            int x = 1000000;
            int y = 1000000;
            long expectedValue = -1;
            Assert.AreEqual(Spiral.GetNumberAtPosition(x, y), expectedValue);
        }

        [TestMethod]
        public void Test_Result_GetNumberAtPosition_test10()
        {
            int x = -2;
            int y = -5;
            long expectedValue = 83;
            Assert.AreEqual(Spiral.GetNumberAtPosition(x, y), expectedValue);
        }
    }
}
