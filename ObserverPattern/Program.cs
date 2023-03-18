WeatherData weatherData = new WeatherData();
Display display = new Display();
weatherData.RegisterObserver(display);
weatherData.SetMeasurements(25, 60, 1013);
public interface IObserver
{
    void Update(float temperature, float humidity, float pressure);
}
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}
public class WeatherData : ISubject
{
    private List<IObserver> _observers;
    private float _temperature;
    private float _humidity;
    private float _pressure;
    public WeatherData()
    {
        _observers = new List<IObserver>();
    }
    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }
    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_temperature, _humidity, _pressure);
        }
    }
    public void MeasurementsChanged()
    {
        NotifyObservers();
    }
    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        _pressure = pressure;
        MeasurementsChanged();
    }
}
public class Display : IObserver
{
    private float _temperature;
    private float _humidity;
    public void Update(float temperature, float humidity, float pressure)
    {
        _temperature = temperature;
        _humidity = humidity*1.5f;
        DisplayWeather();
    }
    private void DisplayWeather()
    {
        Console.WriteLine($"Temperature: {_temperature}");
        Console.WriteLine($"Humidity: {_humidity}");
    }
}