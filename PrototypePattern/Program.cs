
var product1 = new Product(1, "phone", "Phone description");
var product2 = (Product)product1.ProductClone() ;
var product3 = (Product) product1.Clone();

Console.WriteLine($"{product1.Name} = {product2.Name} = {product3.Name}");
product2.Name = "Laptop";
product3.Name = "Tablet";
Console.WriteLine($"{product1.Name} != {product2.Name} != {product3.Name}");
public abstract class IProduct
{
    public abstract Product ProductClone();
}

public class Product : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Product(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    public override Product ProductClone()
    {
        return MemberwiseClone() as Product;

    }
    public IProduct Clone() 
    {
        return new Product(Id = Id, Name = Name,Description = Description);
    }
   
}