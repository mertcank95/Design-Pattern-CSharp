var instance1 = Multiton.GetInstance("key1");
var instance2 = Multiton.GetInstance("key2");
var instance3 = Multiton.GetInstance("key1");

Console.WriteLine(instance1.Key); // Output: "key1"
Console.WriteLine(instance2.Key); // Output: "key2"
Console.WriteLine(instance3.Key); // Output: "key1"

Console.WriteLine(instance1 == instance2); // Output: "False"
Console.WriteLine(instance1 == instance3); // Output: "True"
public class Multiton
{
    private static Dictionary<string, Multiton> _instances = new Dictionary<string, Multiton>();
    private static object _lockObject = new object();
    private string _key;

    private Multiton(string key)
    {
        _key = key;
    }

    public static Multiton GetInstance(string key)
    {
        lock (_lockObject)
        {
            if (!_instances.ContainsKey(key))
            {
                _instances.Add(key, new Multiton(key));
            }
            return _instances[key];
        }
    }

    public string Key
    {
        get { return _key; }
    }
}
