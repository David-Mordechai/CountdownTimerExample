namespace CountdownTimerDemo;

public class CountdownTimer : ICountdownTimer
{
    public Action? OnCountdownFinished { get; set; }
    public Action<TimeSpan>? OnTick { get; set; }
    public Action? OnStop { get; set; }

    private double _secondsRemaining;
    private Timer? _timer;

    public void Start(TimeSpan time)
    {
        ClearTimer();
        _secondsRemaining = time.TotalSeconds;
        if (_secondsRemaining <= 0) _secondsRemaining = 0;
        _timer = new Timer(callback: TickCallback, state: null, dueTime: 0, period: 1000);
    }

    public void Stop()
    {
        ClearTimer();
        OnStop?.Invoke();
    }

    private void TickCallback(object? _)
    {
        _secondsRemaining--;

        if (_secondsRemaining >= 0)
            OnTick?.Invoke(TimeSpan.FromSeconds(_secondsRemaining));

        if (_secondsRemaining != 0) return;

        OnCountdownFinished?.Invoke();
    }

    private void ClearTimer()
    {
        _timer?.Dispose();
        _timer = null;
    }
}