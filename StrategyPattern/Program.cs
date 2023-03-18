
var creditCardPayment = new CreditCardStrategy("1234567890123456", "12/24", "123");
var order = new Order(creditCardPayment);
order.Process(100);

var payPalPayment = new PaypalStrategy("user@gmail.com", "password123");
order = new Order(payPalPayment);
order.Process(50);
public abstract class PaymentStrategy
{
    public abstract void Pay(float amount);
}

public class CreditCardStrategy : PaymentStrategy
{
    private readonly string _cardNumber;
    private readonly string _expirationDate;
    private readonly string _cvv;
    public CreditCardStrategy(string cardNumber, string expirationDate, string cvv)
    {
        _cardNumber = cardNumber;
        _expirationDate = expirationDate;
        _cvv = cvv;
    }
    public override void Pay(float amount)
    {
        Console.WriteLine($"Paying {amount} using credit card {_cardNumber}");
    }
}

public class PaypalStrategy : PaymentStrategy
{
    private readonly string _email;
    private readonly string _password;

    public PaypalStrategy(string email, string password)
    {
        _email = email;
        _password = password;
    }

    public override void Pay(float amount)
    {
        Console.WriteLine($"Paying {amount} using paypal account {_email}");
    }
}

public class Order
{
    private readonly PaymentStrategy _paymentStrategy;

    public Order(PaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void Process(float amount)
    {
        _paymentStrategy.Pay(amount);
    }
}