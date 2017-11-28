using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Automatyzacja2017
{
    public class MatematicsTests
    {
        [Fact]
        public void Method_add_returns_sum_of_given__integers()
        {
            //arrange
            var math = new Mathematics();

            //act
            double result = math.Add(10, 20);

            //assert
            Assert.Equal(30, result);
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
        public void Method_divide_returns_exception_becouse_of_zero()
        {
            //arrange
            var math = new Mathematics();

            //act

            //assert
            Assert.ThrowsAny<Exception>(() => math.Divide(12.2, 0));
        }
    }
}
