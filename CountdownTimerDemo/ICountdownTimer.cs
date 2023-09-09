namespace CountdownTimerDemo;

public interface ICountdownTimer
{
    Action? OnCountdownFinished { get; set; }
    Action<TimeSpan>? OnTick { get; set; }
    Action? OnStop { get; set; }
    void Start(TimeSpan time);
    void Stop();
}