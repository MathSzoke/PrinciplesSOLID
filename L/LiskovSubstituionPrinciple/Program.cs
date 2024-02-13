namespace InterfaceSegregationPrinciple;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Choose your type payment:\n");
        Console.WriteLine("1 - Pix method\n");
        Console.WriteLine("2 - Credit Card method\n");
        Console.WriteLine("3 - Ticket method \n");

        var order = new Order();

        if (Enum.TryParse(Console.ReadLine(), out EPaymentType chosenPaymentType))
        {
            switch (chosenPaymentType)
            {
                case EPaymentType.Pix:
                    order.Payment = new PixPayment();
                    break;
                case EPaymentType.CreditCard:
                    order.Payment = new CreditCardPayment();
                    break;
                case EPaymentType.Ticket:
                    order.Payment = new TicketPayment();
                    break;
                default:
                    Console.WriteLine("You chose an invalid type payment");
                    break;
            }

            order.Payment.Pay();
        }
        else
        {
            Console.WriteLine("Invalid option");
        }
    }
}


/*
 * Este é um pequeno exemplo de como utilizar o Liskov Substitution Principle de um dos pílares do principio SOLID.
 * 
 * A definição neste exemplo é que ao invés de utilizar diversas interfaces definindo suas assinaturas, a classe Pai pode muito bem ter um método completamente vázio e sem retorno,
 * utilizando da assinatura "Virtual", permite que o método seja alterado pelo Filho, realizando a execução do método utilizando da assinatura Override.
 * 
 * Utilizando o termo 'base.Pay()' permite o sistema reutilizar o conteúdo do método Pai e ainda assim implementar novos conteúdos após a chamada do base.Pay na classe Filho...
 */

public abstract class Payment // Classes abstratas não podem ter instancias! Por exemplo o "new Payment()", daria erro.
{
    public DateTime PaymentDate { get; private set; }

    public virtual void Pay()
    {
        Console.WriteLine("\nNice! Your chose is:\n");
    }

    public virtual bool IsExpired()
    {
        return DateTime.Now > this.PaymentDate.AddDays(30);
    }
}

public enum EPaymentType
{
    Pix = 1, // Pix
    CreditCard = 2, // Cartão de crédito
    Ticket = 3, // Boleto
}

public class PixPayment : Payment
{
    public override void Pay()
    {
        base.Pay();
        Console.WriteLine("Pix method!\n");
    }
    public override bool IsExpired()
    {
        return base.Equals(this);
    }
}

public class CreditCardPayment : Payment
{
    public override void Pay()
    {
        base.Pay();
        Console.WriteLine("Credit Card method!\n");
    }
}

public class TicketPayment : Payment
{
    public override void Pay()
    {
        base.Pay();
        Console.WriteLine("Ticket method!\n");
    }
    public override bool IsExpired()
    {
        return base.Equals(this);
    }
}

public class Order
{
    public Payment Payment { get; set; }
}