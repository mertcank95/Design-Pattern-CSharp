var creditCardPayment = new CreditCardPayment();
IPaymnetGateway paymentGateway = new PaymentGatewat(creditCardPayment);
paymentGateway.ProcessPayment("credit card");

var paypalPayment = new PaypalPayment();
paymentGateway = new PaymentGatewat(paypalPayment);
paymentGateway.ProcessPayment("Credit Card");
public interface IPaymentMethod
{
    void ProcessPayment();
}
public class CreditCardPayment : IPaymentMethod
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing credit card payment");
    }
}
public class PaypalPayment : IPaymentMethod
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing paypal card payment");
    }
}
public interface IPaymnetGateway
{
    void ProcessPayment(string paymentMethod);
}
public class PaymentGatewat : IPaymnetGateway
{
    protected readonly IPaymentMethod _paymentMethod;
    public PaymentGatewat(IPaymentMethod paymentMethod)
    {
        _paymentMethod = paymentMethod;
    }

    public virtual void ProcessPayment(string paymentMethod)
    {
        Console.WriteLine($"Processing payment using {paymentMethod} method");
        _paymentMethod.ProcessPayment();
    }
}
