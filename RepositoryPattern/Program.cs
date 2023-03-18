/*
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
public interface IRepository<T>
{
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    IEnumerable<T> GetAll();
}
public class ProductRepository : IRepository<Product>
{
    private readonly DbContext _context;

    public ProductRepository(DbContext context)
    {
        _context = context;
    }

    public Product GetById(int id)
    {
        return _context.Products.Find(id);
    }

    public void Add(Product entity)
    {
        _context.Products.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Product entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(Product entity)
    {
        _context.Products.Remove(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }
}
public void UseProductRepository()
{
    using (var context = new DbContext())
    {
        var productRepository = new ProductRepository(context);
        var newProduct = new Product { Name = "Ürün 1", Price = 10 };
        productRepository.Add(newProduct);
        var existingProduct = productRepository.GetById(1);
        existingProduct.Name = "Ürün 2";
        existingProduct.Price = 20;
        productRepository.Update(existingProduct);
        var productToDelete = productRepository.GetById(1);
        productRepository.Delete(productToDelete);
        var allProducts = productRepository.GetAll();
    }
}*/
