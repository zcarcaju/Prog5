using System;

namespace TesteUnitario
{
    class Program
    {   
        public static void Main(string[] args)
        {

        }

        public int Somar(int value1, int value2)
        {
            return value1 + value2;
        }

        public float DividirFloat(float value1, float value2)
        {
            return value1 / value2;    
        }

        public int DividirInt(int value1, int value2)
        {
            return value1 / value2;
        }

        /*
        // Arrange
        int n1 = 10, n2 = 20;
        Calculator calculator = new Calculator();
        // Act
        int result = calculator.Sum(n1, n2);
        // Assert
        Assert.Equal(30, result);
        */

    }
}
