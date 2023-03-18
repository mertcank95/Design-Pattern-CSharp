OrderHandler approvalHandler = new ApprovalHandler();
OrderHandler pricingHandler = new PricingHandler();
OrderHandler shippingHandler = new ShippingHandler();

approvalHandler.SetNextHandler(pricingHandler);
pricingHandler.SetNextHandler(shippingHandler);

CustomerOrder order = new CustomerOrder
{
    ProductName = "Product 1",
    Price = 100,
    Department = "approval"
};


approvalHandler.HandleOrder(order);
Console.WriteLine($"Order processed, approved: {order.IsApproved}, price: {order.Price}");

public class CustomerOrder
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public string Department { get; set; }
    public bool IsApproved { get; set; }
}
public abstract class OrderHandler
{
    protected OrderHandler nextHandler;

    public void SetNextHandler(OrderHandler handler)
    {
        nextHandler = handler;
    }

    public virtual void HandleOrder(CustomerOrder order)
    {
        if (nextHandler != null)
        {
            nextHandler.HandleOrder(order);
        }
    }
}
public class ApprovalHandler : OrderHandler
{
    public override void HandleOrder(CustomerOrder order)
    {
        if (order.Department.Equals("approval"))
        {
            order.IsApproved = true;
            Console.WriteLine("Order approved by Approval Department");
        }
        else
        {
            base.HandleOrder(order);
        }
    }
}

public class PricingHandler : OrderHandler
{
    public override void HandleOrder(CustomerOrder order)
    {
        if (order.Department.Equals("pricing"))
        {
            order.Price *= 1.2;
            Console.WriteLine("Order price increased by 20% by Pricing Department");
        }
        else
        {
            base.HandleOrder(order);
        }
    }
}
public class ShippingHandler : OrderHandler
{
    public override void HandleOrder(CustomerOrder order)
    {
        if (order.Department.Equals("shipping"))
        {
            Console.WriteLine("Order shipped by Shipping Department");
        }
        else
        {
            base.HandleOrder(order);
        }
    }
}
