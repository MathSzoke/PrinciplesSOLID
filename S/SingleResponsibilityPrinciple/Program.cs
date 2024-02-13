namespace SingleResponsibilityPrinciple; // SRP

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Choose your method to calculate:\n");
        Console.WriteLine("1 - Sum\n");
        Console.WriteLine("2 - Subtraction\n");
        Console.WriteLine("3 - Division\n");
        Console.WriteLine("4 - Multiplier\n");

        var inputHandler = new InputHandler();
        var calculator = new Calculator();
        var chosenOperator = inputHandler.GetChosenOperator();

        if (chosenOperator != EOperators.Invalid)
        {
            var operands = inputHandler.GetOperands();
            int result = calculator.PerformOperation(chosenOperator, operands.Item1, operands.Item2);
            Console.WriteLine($"Result: {result}");
        }
        else
        {
            Console.WriteLine("Invalid option");
        }
    }
}

/*
 * Este é um exemplo que ilustra o Single Responsibility Principle (SRP) dentro do conjunto de princípios SOLID.
 * O SRP postula que cada classe ou método deve ter apenas uma razão para mudar, ou seja, deve ter apenas uma responsabilidade.
 * Isso promove a coesão e a facilidade de manutenção do código.
 * 
 * No código fornecido, o SRP é aplicado ao garantir que cada método na classe Calculator tenha uma única responsabilidade:
 * - O método de Sum é responsável apenas pela soma de dois valores.
 * - O método de Subtraction é responsável apenas pela subtração de dois valores.
 * - O método de Division é responsável apenas pela divisão de dois valores.
 * - O método de Multiplier é responsável apenas pela multiplicação de dois valores.
 * 
 * Além disso, a classe Calculator tem a única responsabilidade de realizar cálculos matemáticos, mantendo-se coesa e de fácil manutenção.
 * 
 * Ao seguir o SRP, este código promove um design mais robusto e flexível, facilitando a extensão e modificação futuras.
 */


public enum EOperators
{
    Invalid = 0,
    Sum = 1,
    Subtraction = 2,
    Division = 3,
    Multiplier = 4
}

public class InputHandler
{
    public EOperators GetChosenOperator() => Enum.TryParse(Console.ReadLine(), out EOperators chosenOperator) ? chosenOperator : EOperators.Invalid;

    public (int, int) GetOperands()
    {
        Console.WriteLine("Enter the first operand:");
        int a = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter the second operand:");
        int b = int.Parse(Console.ReadLine()!);
        return (a, b);
    }
}

public class Calculator
{
    public int PerformOperation(EOperators chosenOperator, int a, int b) => chosenOperator switch
    {
        EOperators.Sum => this.Sum(a, b),
        EOperators.Subtraction => this.Subtraction(a, b),
        EOperators.Division => this.Division(a, b),
        EOperators.Multiplier => this.Multiplier(a, b),
        _ => throw new ArgumentException("Invalid operator"),
    };

    public int Sum(int a, int b) => a + b;

    public int Subtraction(int a, int b) => a - b;

    public int Division(int a, int b) => a / b;

    public int Multiplier(int a, int b) => a * b;
}
