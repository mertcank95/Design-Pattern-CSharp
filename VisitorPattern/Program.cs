Player player = new Player
{
    Health = 100,
    Attack = 50,
    Defense = 25
};

PlayerVisitor visitor = new PlayerVisitor();
player.Accept(visitor);
interface IVisitor
{
    void Visit(Player player);
}

class Player
{
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
class PlayerVisitor : IVisitor
{
    public void Visit(Player player)
    {
        Console.WriteLine($"Player Health: {player.Health}");
        Console.WriteLine($"Player Attack: {player.Attack}");
        Console.WriteLine($"Player Defense: {player.Defense}");
    }
}

