ProductService productService = new(new());
AbstractProduct abstractProduct = productService.GetProductName("Phone");
abstractProduct.KDV();
abstractProduct = productService.GetProductName("NONE");
abstractProduct.KDV();
abstract class AbstractProduct
{
    public abstract int ProductId { get; set; }
    public abstract string ProductName { get; set; }
    public abstract float Price { get; set;}
    public abstract void KDV();
}
class Product : AbstractProduct
{
    public override int ProductId { get; set; }
    public override string ProductName { get ; set ; }
    public override float Price { get ;  set ; }
    public override void KDV() =>
        Console.WriteLine((Price * 0.18f));
}
class NullProduct : AbstractProduct
{

    private NullProduct() {}
    public override int ProductId { get; set; }
    public override string ProductName { get; set; }
    public override float Price { get; set; }
    //Singleton
    public static NullProduct nullProduct;
    public static NullProduct instance => nullProduct ?? (nullProduct = new());
    public override void KDV()
    {
        Console.WriteLine("Product Null...");
    }
}
class ProductRepository
{
    List<AbstractProduct> products = new()
    {
        new Product() {ProductId=1,ProductName="Tablet",Price=100},
        new Product() {ProductId=2,ProductName="Laptop",Price=350},
        new Product() {ProductId=3,ProductName="Phone",Price=500}
    };
    public List<AbstractProduct> GetWhere(Func<AbstractProduct, bool> predicate)
        =>products.Where(predicate).ToList();
    public AbstractProduct GetSingle(Func<AbstractProduct, bool> predicate)
       => products.FirstOrDefault(predicate);
}
class ProductService
{
    readonly ProductRepository _productRepository;
    public ProductService(ProductRepository productRepository)
    {
        _productRepository= productRepository;
    }
    public AbstractProduct GetProductName(string productName)
        => _productRepository.GetSingle(e => e.ProductName == productName).NullCheck();
}
static class Extensions
{
    public static AbstractProduct NullCheck(this AbstractProduct instance)
        => instance ?? NullProduct.instance;
}