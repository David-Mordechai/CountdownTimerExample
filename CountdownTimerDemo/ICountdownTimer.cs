namespace CountdownTimerDemo;

public interface ICountdownTimer
{
    Action? OnCountdownFinished { get; set; }
    Action<TimeSpan>? OnTick { get; set; }
    void StartOrRestart(TimeSpan period);
}