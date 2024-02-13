namespace InterfaceSegregationPrinciple; // ISP

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
        }
        else
        {
            Console.WriteLine("Invalid option");
        }

        order.Payment.Pay();
    }
}


/*
 * Este é um pequeno exemplo de como utilizar o Interface Segregation Principle de um dos pílares do principio SOLID.
 * 
 * A definição neste exemplo é que o Boleto possui uma expiração para o pagamento, quanto o cartão de crédito não.
 * Quando implementado uma assinatura na interface (um método ou propriedade sem corpo no método), obrigatóriamente deve-se ser utilizado naquela classe que se herda da interface.
 * 
 * Caso a classe PixPayment herde da interface IExpiredPayment, obrigatóriamente deverá implementar o método filho (IsExpired) em seu corpo.
 */

public interface IPayment
{
    void Pay();
}

public interface IExpiredPayment
{
    bool IsExpired();
}

public enum EPaymentType
{
    Pix = 1, // Pix
    CreditCard = 2, // Cartão de crédito
    Ticket = 3, // Boleto
}

public class PixPayment : IPayment, IExpiredPayment
{
    public void Pay()
    {
        Console.WriteLine("Pix method!\n");
    }
    public bool IsExpired()
    {
        return base.Equals(this);
    }
}

public class CreditCardPayment : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Credit Card method!\n");
    }
}

public class TicketPayment : IPayment, IExpiredPayment
{
    public void Pay()
    {
        Console.WriteLine("Ticket method!\n");
    }
    public bool IsExpired()
    {
        return base.Equals(this);
    }
}

public class Order
{
    public IPayment Payment { get; set; }
}