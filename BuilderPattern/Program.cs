
IProductBuilder product = new PhoneBuilder();
var builder = new ProductBuild();
builder.Build(product);
Console.WriteLine(product.GetProduct.ToString());
product = new LaptopBuilder();
builder.Build(product);
Console.WriteLine(product.GetProduct.ToString());
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public override string ToString()
    {
        return $"{Id}  {Name}  {Description}  {Price}";
    }
}
public abstract class IProductBuilder
{
    protected Product product;
    public Product GetProduct
    {
        get { return product; }
    }
    public abstract void SetId();
    public abstract void SetName();
    public abstract void SetDescription();
    public abstract void SetPrice();
}

public class ProductBuild
{
    public void Build(IProductBuilder product)
    {
        product.SetId();
        product.SetName();
        product.SetDescription();
        product.SetPrice();
    }
}
public class PhoneBuilder : IProductBuilder
{
    public PhoneBuilder()
    {
        product = new Product();
    }
    public override void SetDescription()
        => product.Description = "phone Description";
    public override void SetId()
        => product.Id = 1;
    public override void SetName()
        => product.Name = "Phone";
    public override void SetPrice()
        => product.Price = 150;

}
public class LaptopBuilder : IProductBuilder
{
    public LaptopBuilder()
    {
        product = new Product();
    }
    public override void SetDescription()
        => product.Description = "laptop desciription";
    public override void SetId()
        => product.Id = 1;
    public override void SetName()
        => product.Name = "Laptop";
    public override void SetPrice()
        => product.Price = 1000;
}

/*
var productBuilder = new ProductBuilder();
var product = productBuilder
    .SetName("Name")
    .SetDescription("Description")
    .SetPrice(1000)
    .SetId(1)
    .Build();

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
}
public class ProductBuilder
{
    private Product _product = new Product();

    public ProductBuilder SetName(string name)
    {
        _product.Name = name;
        return this;
    }

    public ProductBuilder SetDescription(string description)
    {
        _product.Description = description;
        return this;
    }

    public ProductBuilder SetPrice(float price)
    {
        _product.Price = price;
        return this;
    }



    public ProductBuilder SetId(int id)
    {
        _product.Id = id;
        return this;
    }

    public Product Build()
    {
        return _product;
    }
}
*/


 