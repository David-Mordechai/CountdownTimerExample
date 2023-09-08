using CountdownTimerDemo;

ICountdownTimer countdownTimer = new CountdownTimer
{
    OnCountdownFinished = () =>
    {
        Console.WriteLine("Countdown finished...");
    }
};

var restarted = false;
countdownTimer.OnTick = secondsRemaining =>
{
    Console.WriteLine(secondsRemaining.ToString(@"mm\:ss"));
    if (secondsRemaining.Seconds != 2) return;
    if (restarted) return;
    
    Console.WriteLine("Restarting the countdown timer to 5 seconds");
    countdownTimer.StartOrRestart(TimeSpan.FromSeconds(5));
    restarted = true;
};

countdownTimer.StartOrRestart(TimeSpan.FromSeconds(10));

Console.WriteLine("Press any key to stop the countdown timer...");
Console.ReadKey();

countdownTimer.Stop();
Console.WriteLine("Countdown timer stopped");

Console.ReadKey();
