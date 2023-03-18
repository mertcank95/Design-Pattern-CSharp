Pizza pizza1 = new PepperoniPizza();
pizza1.Make();

Pizza pizza2 = new VeggiePizza();
pizza2.Make();
abstract class Pizza
{
    public void Make()
    {
        PrepareDough();
        AddSauce();
        AddToppings();
        Bake();
    }
    protected void PrepareDough()
    {
        Console.WriteLine("Preparing dough...");
    }
    protected void AddSauce()
    {
        Console.WriteLine("Adding sauce...");
    }
    protected abstract void AddToppings();
    protected void Bake()
    {
        Console.WriteLine("Baking...");
    }
}
class PepperoniPizza : Pizza
{
    protected override void AddToppings()
    {
        Console.WriteLine("Adding pepperoni toppings...");
    }
}
class VeggiePizza : Pizza
{
    protected override void AddToppings()
    {
        Console.WriteLine("Adding veggies toppings...");
    }
}

