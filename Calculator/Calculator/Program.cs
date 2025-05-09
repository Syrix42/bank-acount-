using System;


public interface IOperation
{
    double Calculate(double a, double b);
}

public class Addition : IOperation
{
    public double Calculate(double a, double b) => a + b;
}

public class Subtraction : IOperation
{
    public double Calculate(double a, double b) => a - b;
}

public class Multiplication : IOperation
{
    public double Calculate(double a, double b) => a * b;
}

public class Division : IOperation
{
    public double Calculate(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        return a / b;
    }
}


public class Calculator
{
    public double PerformOperation(IOperation operation, double a, double b)
    {
        return operation.Calculate(a, b);
    }
}


class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();

        
        Console.Write("Enter first number: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Choose operation (+, -, *, /): ");
        string op = Console.ReadLine();

        IOperation operation = op switch
        {
            "+" => new Addition(),
            "-" => new Subtraction(),
            "*" => new Multiplication(),
            "/" => new Division(),
            _ => throw new InvalidOperationException("Invalid operator")
        };

        try
        {
            double result = calc.PerformOperation(operation, a, b);
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
