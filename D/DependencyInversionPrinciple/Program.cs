namespace DependencyInversionPrinciple; // DIP

/*
 * O Princípio da Inversão de Dependência (Dependency Inversion Principle - DIP) do SOLID estabelece que:
 * 
 * 1 - Módulos de alto nível não devem depender de módulos de baixo nível. Ambos devem depender de abstrações.
 * 2 - Abstrações não devem depender de detalhes. Detalhes devem depender de abstrações.
 * 
 * Em outras palavras, o DIP propõe que as classes de nível superior não devem depender diretamente das classes de nível inferior, mas sim de abstrações.
 * Isso promove a flexibilidade e a capacidade de alterar as implementações sem modificar o código de alto nível.
 * 
 * No exemplo fornecido, a classe de nível superior seria a Notification, enquanto as classes de nível inferior seriam EmailMessage e SmsMessage. Aqui está a razão:
 * 
 * Classe de Nível Superior (Alto Nível):
 * 
 * Notification: Esta classe é responsável por enviar notificações e é onde a lógica principal de notificação é implementada.
 * Ela depende de uma abstração (IMessage) para enviar mensagens, mas não está diretamente envolvida na implementação específica de como as mensagens são enviadas.
 * Classes de Nível Inferior (Baixo Nível):
 * 
 * EmailMessage: Esta classe é uma implementação concreta de IMessage e é responsável por enviar mensagens por e-mail.
 * SmsMessage: Similar ao EmailMessage, esta classe é uma implementação concreta de IMessage e é responsável por enviar mensagens por SMS.
 */

// Interface para definir o contrato de uma mensagem
public interface IMessage
{
    void Send(string message);
}

// Implementação concreta de mensagem por e-mail
public class EmailMessage : IMessage
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending email: {message}");
        // Lógica para enviar email
    }
}

// Implementação concreta de mensagem por SMS
public class SmsMessage : IMessage
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
        // Lógica para enviar SMS
    }
}

// Classe de alto nível que depende de abstrações (IMessage)
public class Notification(IMessage message)
{
    private readonly IMessage _message = message;

    // Aqui, Notification chama o método abstrato Send() de IMessage
    public void SendNotification(string message) => this._message.Send(message);
}

// Classe principal para testar o código
class Program
{
    static void Main(string[] args)
    {
        // Exemplo de uso de Notification com EmailMessage
        var emailMessage = new EmailMessage();
        var emailNotification = new Notification(emailMessage);
        emailNotification.SendNotification("This is an email notification");

        // Exemplo de uso de Notification com SmsMessage
        var smsMessage = new SmsMessage();
        var smsNotification = new Notification(smsMessage);
        smsNotification.SendNotification("This is an SMS notification");
    }
}
