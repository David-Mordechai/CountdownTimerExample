namespace CountdownTimerDemo;

public class CountdownTimer : ICountdownTimer
{
    public Action? OnCountdownFinished { get; set; }
    public Action<TimeSpan>? OnTick { get; set; }
    
    private double _secondsRemaining;
    private Timer? _timer;

    public void StartOrRestart(TimeSpan newMinutes)
    {
        _secondsRemaining = newMinutes.TotalSeconds;
        if (_secondsRemaining <= 0)
        {
            throw new ArgumentException("Minutes must be greater than 0.");
        }

        _timer?.Dispose();
        _timer = new Timer(_ =>
        {
            _secondsRemaining--;

            if (_secondsRemaining >= 0)
                OnTick?.Invoke(TimeSpan.FromSeconds(_secondsRemaining));

            if (_secondsRemaining != 0) return;

            OnCountdownFinished?.Invoke();
            
            _timer?.Dispose();
        }, state: null, dueTime: 0, period: 1000);
    }

    public void Stop()
    {
        _timer?.Dispose();
        _timer = null;
    }
}