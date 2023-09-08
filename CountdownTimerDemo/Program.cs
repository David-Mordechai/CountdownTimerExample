using CountdownTimerDemo;

ICountdownTimer countdownTimer = new CountdownTimer
{
    OnTick = secondsRemaining =>
    {
        Console.WriteLine(secondsRemaining.ToString(@"mm\:ss"));
    },

    OnCountdownFinished = () =>
    {
        Console.WriteLine("Countdown finished...");
    }
};

countdownTimer.StartOrRestart(TimeSpan.FromSeconds(10));

Console.ReadKey();
