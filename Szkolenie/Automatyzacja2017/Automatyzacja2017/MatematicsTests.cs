﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Automatyzacja2017
{
    public class MatematicsTests
    {
        [Theory]
        [InlineData(10,20,30)]
        [InlineData(20,20,40)]
        [InlineData(20,30,50)]
        public void Method_add_returns_sum_of_given__integers(double x, double y, double expected)
        {
            //arrange
            var math = new Mathematics();

            //act
            double result = math.Add(x, y);

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Method_add_returns_sum_of_given_doubles()
        {
            //arrange
            var math = new Mathematics();

            //act
            double result = math.Add(16.1d, 6.1d);

            //assert
            Assert.Equal(22.2, result, 2);
        }

        [Fact]
        public void Method_substract_returns_substraction_of_given_integers()
        {
            //arrange
            var math = new Mathematics();

            //act
            double result = math.Substract(20, 10);

            //assert
            Assert.Equal(10, result);
        }
        [Fact]
        public void Method_substract_returns_substraction_of_given_doubles()
        {
            //arrange
            var math = new Mathematics();

            //act
            double result = math.Substract(16.1, 6.1);

            //assert
            Assert.Equal(10, result, 4);
        }

        [Fact]
        public void Method_multiply_returns_multiplication_of_given_integers()
        {
            //arrange
            var math = new Mathematics();

            //act
            double result = math.Multiply(10, 20);

            //assert
            Assert.Equal(200, result);
        }

        [Fact]
        public void Method_multiply_returns_multiplication_of_given_doubles()
        {
            //arrange
            var math = new Mathematics();

            //act
            double result = math.Multiply(6.1, 10.1);

            //assert
            Assert.Equal(61.61, result,2);
        }

        [Fact]
        public void Method_divide_returns_divison_of_given_integers()
        {
            //arrange
            var math = new Mathematics();

            //act
            double result = math.Divide(20, 2);

            //assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void Method_divide_returns_divison_of_given_doubless()
        {
            //arrange
            var math = new Mathematics();

            //act
            double result = math.Divide(12.2, 6.1);

            //assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Method_divide_by_zero_returns_exception()
        {
            //arrange
            var math = new Mathematics();

            //act

            //assert
            Assert.Throws<DivideByZeroException>(() => math.Divide(12.2, 0));
        }
    }
}
