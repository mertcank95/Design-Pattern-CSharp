TrafficLight trafficLight = new TrafficLight();
trafficLight.Change(); // Traffic light changed to green
trafficLight.Change(); // Traffic light changed to yellow
trafficLight.Change(); // Traffic light changed to red
interface ITrafficLightState
{
    void Change(TrafficLight light);
}
class RedLightState : ITrafficLightState
{
    public void Change(TrafficLight light)
    {
        Console.WriteLine("Traffic light changed to green");
        light.SetState(new GreenLightState());
    }
}
class GreenLightState : ITrafficLightState
{
    public void Change(TrafficLight light)
    {
        Console.WriteLine("Traffic light changed to yellow");
        light.SetState(new YellowLightState());
    }
}
class YellowLightState : ITrafficLightState
{
    public void Change(TrafficLight light)
    {
        Console.WriteLine("Traffic light changed to red");
        light.SetState(new RedLightState());
    }
}
class TrafficLight
{
    private ITrafficLightState _state;
    public TrafficLight()
    {
        _state = new RedLightState();
    }
    public void SetState(ITrafficLightState state)
    {
        _state = state;
    }
    public void Change()
    {
        _state.Change(this);
    }
}