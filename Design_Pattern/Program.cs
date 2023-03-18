Product product = new Product(1,"Laptop",1000);
var priceA = new ACountryAdapter().CalculatePrice(product);
var priceB = new BCountryAdapter().CalculatePrice(product);
Console.WriteLine("A : {0} B : {1}", priceA, priceB);
class AContry : ICalculate
{
    public float CalculatePrice(Product product)
    {
        Console.WriteLine(GetType().Name);
        return (float)(product.ProductPrice + (product.ProductPrice * 0.18));
    }
}
class ACountryAdapter :ICalculate
{
    private readonly AContry _aCountry;
    public ACountryAdapter()
    {
        _aCountry = new();
    }
    public float CalculatePrice(Product product)
    {
        return _aCountry.CalculatePrice(product);
    }
}

class BContry : ICalculate
{
    public float CalculatePrice(Product product)
    {
        Console.WriteLine(GetType().Name);
        return (float)(product.ProductPrice * 3);
    }
}
class BCountryAdapter : ICalculate
{
    private readonly BContry _bCountry;

    public BCountryAdapter()
    {
        _bCountry = new();
    }
    public float CalculatePrice(Product product)
    {
        return _bCountry.CalculatePrice(product);
    }
}
interface ICalculate
{
    float CalculatePrice(Product product);
}
class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public float  ProductPrice { get; set; }
    public Product(int id, string productName, float productPrice)
    {
        Id = id;
        ProductName = productName;
        ProductPrice = productPrice;
    }
}
