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

Console.WriteLine("Press any key to stop the countdown timer...");
Console.ReadKey();
countdownTimer.Stop();
Console.WriteLine("Countdown timer stopped");

Console.ReadKey();
