
var product = Product.GetInstance();
Console.WriteLine($"{product.Id}  {product.Name} ");
public class Product
{
    public static Product _productInstance;
	public int Id { get => 1; }
	public string Name { get => "product Name";  }
	public static Product GetInstance()
	{
        if (_productInstance == null)
            _productInstance = new Product();
		return _productInstance;
    }
} 