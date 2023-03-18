public abstract class Product
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract float GetPrice();
}
public abstract class Detail
{
    public abstract void GetDetail(string productName);
}

public abstract class ProductFactory
{
    public abstract Product CreateProduct();
    public abstract Detail CreateDetail(string productName);
}
public class PhoneFactory : ProductFactory 
{
    public override Product CreateProduct()
    {
        return new Phone();
    }
    public override Detail CreateDetail(string productName)
    {
        return new PhoneDetail();
    }
}

//ProductManager productManager = new TabletFactory();
public class ProductManager
{
    private ProductFactory _createProductFactory;
    private Detail _detail;

    public ProductManager(ProductFactory createProductFactory)
    {
        _createProductFactory= createProductFactory;
        _detail = createProductFactory.CreateDetail("produtname");
    }
}


public class TabletFactory:ProductFactory
{
    public override Product CreateProduct()
    {
        return new Tablet();
    }

    public override Detail CreateDetail(string productName)
    {
        return new TabletDetail();
    }
}
public class PhoneDetail : Detail
{
    public override void GetDetail(string productName)
    {
        Console.WriteLine(productName);
    }
}

public class TabletDetail : Detail
{
    public override void GetDetail(string productName)
    {
        Console.WriteLine(productName);
    }
}
public class Phone : Product
{
    public override string Name => "Phone";
    public override string Description => "Bir telefon cihazı";
    public override float GetPrice() => 3200;
}
public class Tablet : Product
{
    public override string Name => "Tablet";
    public override string Description => "Bir tablet cihazı";
    public override float GetPrice() => 1200;
}
