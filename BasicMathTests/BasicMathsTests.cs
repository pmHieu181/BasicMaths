using Xunit;
using BasicMath; // Đảm bảo using namespace của project BasicMath
using System;    // Cần cho DivideByZeroException

namespace BasicMathTests
{
    public class BasicMathsTests
    {
        // Test cho phương thức Add
        [Theory]
        [InlineData(1, 1, 2)]       // EP: Positive numbers
        [InlineData(-1, -1, -2)]    // EP: Negative numbers
        [InlineData(0, 0, 0)]       // EP: Zero
        // Nên sử dụng kiểu double cho tất cả các tham số để nhất quán với lớp BasicMaths
        [InlineData(2147483647.0, 1.0, 2147483648.0)] // BVA: Upper boundary (sử dụng double)
        [InlineData(-2147483648.0, -1.0, -2147483649.0)] // BVA: Lower boundary (sử dụng double)
        public void Test_Add(double a, double b, double expected)
        {
            // Arrange
            BasicMaths bm = new BasicMaths();

            // Act
            double actual = bm.Add(a, b);

            // Assert
            Assert.Equal(expected, actual);
        }

        // Test cho phương thức Subtract
        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(10, 20, -10)]
        [InlineData(0, 0, 0)]
        [InlineData(3.5, 1.2, 2.3)]
        public void Test_Subtract(double a, double b, double expected)
        {
            // Arrange
            BasicMaths bm = new BasicMaths();

            // Act
            double actual = bm.Subtract(a, b);

            // Assert
            // xUnit có thể yêu cầu độ chính xác cho số thực dấu phẩy động
            Assert.Equal(expected, actual, precision: 5); // Ví dụ: kiểm tra với 5 chữ số thập phân
        }

        // Test cho phương thức Multiply
        [Theory]
        [InlineData(5, 3, 15)]
        [InlineData(10, -2, -20)]
        [InlineData(0, 100, 0)]
        [InlineData(2.5, 2.0, 5.0)]
        public void Test_Multiply(double a, double b, double expected)
        {
            // Arrange
            BasicMaths bm = new BasicMaths();

            // Act
            double actual = bm.Multiply(a, b);

            // Assert
            Assert.Equal(expected, actual, precision: 5);
        }

        // Test cho phương thức Divide (trường hợp hợp lệ)
        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(10, -2, -5)]
        [InlineData(0, 5, 0)]
        [InlineData(7.5, 2.5, 3.0)]
        public void Test_Divide_ValidInput(double a, double b, double expected)
        {
            // Arrange
            BasicMaths bm = new BasicMaths();

            // Act
            double actual = bm.Divide(a, b);

            // Assert
            Assert.Equal(expected, actual, precision: 5);
        }

        // Test cho phương thức Divide (trường hợp chia cho 0, mong đợi lỗi)
        [Theory]
        [InlineData(5, 0)]
        [InlineData(-10, 0)]
        [InlineData(0, 0)] // Cũng là trường hợp chia cho 0
        public void Test_Divide_ByZero_ThrowsException(double a, double b)
        {
            // Arrange
            BasicMaths bm = new BasicMaths();

            // Act & Assert
            // Kiểm tra xem một ngoại lệ DivideByZeroException có được ném ra hay không
            Assert.Throws<DivideByZeroException>(() => bm.Divide(a, b));
        }
    }
}