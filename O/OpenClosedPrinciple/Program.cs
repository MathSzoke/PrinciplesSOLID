namespace OpenClosedPrinciple; // OCP

/*
 * O Princípio Aberto/Fechado (Open/Closed Principle - OCP) do SOLID 
 * estabelece que as entidades de software (classes, módulos, métodos, etc.) devem estar abertas para extensão, mas fechadas para modificação. 
 * Isso significa que você deve estender o comportamento de uma classe sem modificar seu código fonte.
 * 
 * Por exemplo, o método deve ter o código fonte com a definição e a funcionalidade garantida para funcionamento,
 * e caso necessário ADICIONAR algo nesta função, o código fonte não deverá ser alterado, e sim adicionado/extendido.
 */

// Interface para definir o contrato para diferentes tipos de pagamento
public interface IPaymentMethod
{
    void ProcessPayment(double amount);
}

// Implementação para pagamento com cartão de crédito
public class CreditCardPayment : IPaymentMethod
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing credit card payment of ${amount}");
        // Lógica para processar pagamento com cartão de crédito
    }
}

// Implementação para pagamento com PayPal
public class PayPalPayment : IPaymentMethod
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing PayPal payment of ${amount}");
        // Lógica para processar pagamento com PayPal
    }
}

// Classe que realiza uma compra
public class Purchase(IPaymentMethod paymentMethod)
{
    // Lógica de checkout da compra
    public void Checkout(double amount) => paymentMethod.ProcessPayment(amount);
}

// Classe principal para testar o código
class Program
{
    static void Main(string[] args)
    {
        // Exemplo de uso com pagamento via cartão de crédito
        var creditCardPayment = new CreditCardPayment();
        var purchaseWithCreditCard = new Purchase(creditCardPayment);
        purchaseWithCreditCard.Checkout(100);

        // Exemplo de uso com pagamento via PayPal
        var payPalPayment = new PayPalPayment();
        var purchaseWithPayPal = new Purchase(payPalPayment);
        purchaseWithPayPal.Checkout(50);
    }
}
